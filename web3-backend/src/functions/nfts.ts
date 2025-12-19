import type { Handler } from "@netlify/functions";
import { getSuiClient, getPackageId, isValidSuiAddress } from "../lib/suiClient";

/**
 * GET /.netlify/functions/nfts?wallet=0x...
 *
 * Returns a list of NFTs owned by the given wallet.
 * Shape matches Web3BackendClient.NFTInfoList:
 * {
 *   "items": [
 *     {
 *       "objectId": "...",
 *       "itemId": "legendary_hoe_01",
 *       "nftType": "ITEM",
 *       "collection": "FarmingEngineDemo"
 *     }
 *   ]
 * }
 */
export const handler: Handler = async (event) => {
  if (event.httpMethod !== "GET") {
    return {
      statusCode: 405,
      body: "Method Not Allowed",
    };
  }

  const wallet = event.queryStringParameters?.wallet;
  if (!wallet) {
    return {
      statusCode: 400,
      body: JSON.stringify({ error: "Missing wallet query parameter" }),
    };
  }

  // Check if Sui is configured
  const useSui = !!process.env.SUI_PACKAGE_ID;
  
  // Validate wallet address format (only if using Sui)
  // Invalid addresses will return empty list
  const isValidAddress = isValidSuiAddress(wallet);
  
  if (useSui && isValidAddress) {
    // Query real NFTs from Sui blockchain
    try {
      const client = getSuiClient();
      const packageId = getPackageId();
      const nftType = `${packageId}::nft::NFT`;

      // Query owned objects
      const objects = await client.getOwnedObjects({
        owner: wallet,
        filter: {
          StructType: nftType,
        },
        options: {
          showContent: true,
          showType: true,
        },
      });

      // Parse objects to NFTInfo format
      const items = [];
      for (const obj of objects.data) {
        if (obj.data?.content && "fields" in obj.data.content) {
          const fields = obj.data.content.fields as any;
          items.push({
            objectId: obj.data.objectId,
            itemId: fields.item_id || "",
            nftType: fields.nft_type || "ITEM",
            collection: fields.collection || "FarmingEngineDemo",
          });
        }
      }

      return {
        statusCode: 200,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ items }),
      };
    } catch (suiError: any) {
      console.error("Sui query error:", suiError);
      // Return empty list on error instead of fake data
      console.log("Returning empty list due to Sui error");
    }
  } else if (useSui && !isValidAddress) {
    // Sui configured but invalid address format - return empty list
    console.log(`Invalid Sui address format: ${wallet}, returning empty list`);
  }

  // Sui not configured or error - return empty list instead of fake data
  console.warn("Sui not configured or query failed. Returning empty list.");
  return {
    statusCode: 200,
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ items: [] }),
  };
};


