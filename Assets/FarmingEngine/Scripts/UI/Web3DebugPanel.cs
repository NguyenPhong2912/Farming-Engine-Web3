using UnityEngine;

namespace FarmingEngine
{
    /// <summary>
    /// Simple debug UI for Web3 integration.
    /// Shows current wallet address and lets you manually trigger NFT sync.
    /// Intended for development/testing only.
    /// </summary>
    public class Web3DebugPanel : MonoBehaviour
    {
        public bool visible = true;
        public KeyCode toggleKey = KeyCode.F9;

        // Window size - content will be scrollable
        private Rect windowRect = new Rect(10, 10, 400, 300);
        private string walletInput = "";
        private Vector2 mainScrollPosition = Vector2.zero;
        private Vector2 textAreaScrollPosition = Vector2.zero;

        private void Update()
        {
            if (Input.GetKeyDown(toggleKey))
                visible = !visible;
        }

        private void OnGUI()
        {
            if (!visible)
                return;

            windowRect = GUI.Window(987654, windowRect, DrawWindow, "Web3 Debug");
        }

        private void DrawWindow(int id)
        {
            PlayerData pdata = PlayerData.Get();
            string wallet = pdata != null ? pdata.GetWalletAddress() : "";

            // Main scroll view for entire content
            mainScrollPosition = GUILayout.BeginScrollView(mainScrollPosition, GUILayout.ExpandHeight(true));
            
            GUILayout.BeginVertical();

            GUILayout.Label("Wallet address:");
            GUILayout.Label(string.IsNullOrEmpty(wallet) ? "<none>" : wallet, GUILayout.ExpandWidth(true));

            GUILayout.Space(4);
            GUILayout.Label("Set wallet (test):");
            
            // Use TextArea for better visibility of long addresses
            GUILayout.Label("(Paste full 66-char address here)", GUILayout.ExpandWidth(true));
            textAreaScrollPosition = GUILayout.BeginScrollView(textAreaScrollPosition, GUILayout.Height(40));
            walletInput = GUILayout.TextArea(string.IsNullOrEmpty(walletInput) ? wallet : walletInput, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
            GUILayout.EndScrollView();
            
            // Show wallet length for debugging
            if (!string.IsNullOrEmpty(walletInput))
            {
                string trimmed = walletInput.Trim();
                GUILayout.Label("Length: " + trimmed.Length + " (expected: 66)", GUILayout.ExpandWidth(true));
                if (trimmed.Length != 66)
                {
                    GUI.color = Color.red;
                    GUILayout.Label("⚠️ Invalid length! Must be 66 chars (0x + 64 hex)", GUILayout.ExpandWidth(true));
                    GUI.color = Color.white;
                }
                else
                {
                    GUI.color = Color.green;
                    GUILayout.Label("✅ Address length is correct!", GUILayout.ExpandWidth(true));
                    GUI.color = Color.white;
                }
            }

            GUILayout.Space(4);

            if (GUILayout.Button("Apply Wallet"))
            {
                if (pdata != null)
                {
                    // Validate wallet address format before applying
                    string trimmedWallet = walletInput.Trim();
                    if (string.IsNullOrEmpty(trimmedWallet))
                    {
                        Debug.LogError("[Web3] Cannot apply empty wallet address!");
                        return;
                    }
                    
                    // Check length (0x + 64 hex = 66 chars)
                    if (trimmedWallet.Length != 66)
                    {
                        Debug.LogError("[Web3] Invalid wallet address length: " + trimmedWallet.Length + " (expected 66). Address: " + trimmedWallet);
                        return;
                    }
                    
                    // Check format (0x followed by hex)
                    if (!trimmedWallet.StartsWith("0x") || !System.Text.RegularExpressions.Regex.IsMatch(trimmedWallet, @"^0x[a-fA-F0-9]{64}$"))
                    {
                        Debug.LogError("[Web3] Invalid wallet address format. Must be: 0x followed by 64 hex characters. Got: " + trimmedWallet);
                        return;
                    }
                    
                    string oldWallet = pdata.GetWalletAddress();
                    pdata.SetWalletAddress(trimmedWallet);
                    Debug.Log("[Web3] Wallet address set in PlayerData: " + trimmedWallet + " (length: " + trimmedWallet.Length + ")");
                    
                    // Reset sync status if wallet changed
                    if (oldWallet != trimmedWallet)
                    {
                        Web3WalletValidator.ResetSyncStatus();
                    }
                }
            }

            GUILayout.Space(4);

            if (GUILayout.Button("Sync NFT Inventory"))
            {
                if (TheGame.Get() != null)
                {
                    Debug.Log("[Web3] Manual SyncNFTInventory triggered from Web3DebugPanel.");
                    TheGame.Get().SyncNFTInventory();
                }
            }

            GUILayout.Space(4);

            GUILayout.Label("Toggle: " + toggleKey, GUILayout.ExpandWidth(true));

            GUILayout.EndVertical();
            
            GUILayout.EndScrollView();

            GUI.DragWindow(new Rect(0, 0, 10000, 20));
        }
    }
}


