# Web3 Backend - Netlify Functions

Backend cho Unity FarmingEngine game, chạy trên Netlify Functions.

## ⚠️ QUAN TRỌNG: Cấu hình Netlify

Netlify cần build từ thư mục `web3-backend/`. Có 2 cách:

### Cách 1: Dùng file `netlify.toml` (Khuyến nghị)

File `netlify.toml` đã có ở **root của repo**. Netlify sẽ tự đọc file này.

**NHƯNG** nếu trong Netlify UI bạn đã set Base directory, cần **XÓA** các settings trong UI để dùng file config:

1. Vào **Site settings** → **Build & deploy** → **Build settings**
2. **XÓA** hoặc để trống:
   - Base directory
   - Build command  
   - Publish directory
3. Netlify sẽ tự đọc `netlify.toml` ở root

### Cách 2: Set trong Netlify UI

Nếu không dùng `netlify.toml`, set trong UI:

1. Vào **Site settings** → **Build & deploy** → **Build settings**
2. Set:
   - **Base directory**: `web3-backend`
   - **Build command**: `npm install && npm run build`
   - **Publish directory**: `dist`

## Deploy

1. Push code lên GitHub
2. Netlify sẽ tự động deploy (nếu đã kết nối repo)
3. Hoặc trigger manual: **Deploys** → **Trigger deploy**

## Test Endpoints

Sau khi deploy:
- Health: `https://YOUR-SITE.netlify.app/.netlify/functions/health`
- Mint: `POST https://YOUR-SITE.netlify.app/.netlify/functions/mint`
- NFTs: `GET https://YOUR-SITE.netlify.app/.netlify/functions/nfts?wallet=0x1234...`

## Cấu hình Unity

Trong Unity, tìm GameObject có component `Web3BackendClient` và set:

**backendBaseUrl** = `https://YOUR-SITE.netlify.app/.netlify/functions`

## Sui Blockchain Integration

✅ **Backend đã sẵn sàng tích hợp Sui!**

- Code đã được implement với Sui SDK
- Auto fallback về fake data nếu Sui chưa setup
- Xem `DEPLOY_SUI.md` để biết cách deploy contract và setup
- Quick start: Xem `QUICK_START_SUI.md` (5 phút)

### Environment Variables (cho Sui):

- `SUI_NETWORK`: `testnet` hoặc `mainnet`
- `SUI_PACKAGE_ID`: Package ID của smart contract
- `SUI_PRIVATE_KEY`: Private key để mint (optional)

## Local Development

```bash
npm install
npm run build
npm run dev  # Chạy local với Netlify CLI
```
