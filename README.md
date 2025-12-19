# Farming Engine Web3 - Unity Game với Sui Blockchain

Farming game tích hợp Web3, cho phép người chơi sở hữu và trade NFT items trên Sui blockchain.

## 🎮 Tính năng

- ✅ **NFT Inventory Sync**: Tự động sync NFT từ blockchain vào game inventory
- ✅ **Auto Mint on Craft**: Tự động mint NFT khi craft item đặc biệt
- ✅ **Backend API**: Netlify Functions backend để tương tác với Sui
- ✅ **Unity Integration**: Tích hợp hoàn chỉnh với FarmingEngine

## 📁 Cấu trúc Project

```
MiniHackathon/
├── Assets/
│   └── FarmingEngine/          # Unity game engine
│       ├── Scripts/
│       │   ├── Web3BackendClient.cs    # HTTP client cho backend
│       │   ├── TheGame.cs              # NFT sync logic
│       │   └── PlayerCharacterCraft.cs # Mint NFT khi craft
│       └── Resources/
│           └── Items/
│               └── Equipment/
│                   └── LegendaryHoe.asset  # NFTItemData example
│
└── web3-backend/                # Netlify Functions backend
    ├── src/functions/
    │   ├── health.ts            # Health check
    │   ├── mint.ts              # Mint NFT endpoint
    │   └── nfts.ts              # Query owned NFTs
    ├── netlify.toml             # Netlify config
    └── package.json
```

## 🚀 Quick Start

### 1. Backend Setup

```bash
cd web3-backend
npm install
npm run build
```

### 2. Deploy Backend lên Netlify

1. Push code lên GitHub
2. Vào [Netlify](https://app.netlify.com) → Import project
3. Set Base directory: `web3-backend`
4. Deploy!

Backend sẽ có URL: `https://YOUR-SITE.netlify.app`

### 3. Unity Setup

1. Mở project trong Unity 2022.3.38f1
2. Tìm GameObject có `Web3BackendClient` component
3. Set **backendBaseUrl** = `https://YOUR-SITE.netlify.app/.netlify/functions`
4. Set wallet address trong `PlayerData` (hoặc dùng Web3DebugPanel)

### 4. Test

1. Chạy game trong Unity
2. Nhấn phím toggle để mở Web3DebugPanel
3. Set wallet address: `0xabc123` (hoặc bất kỳ)
4. Click "Sync NFT Inventory"
5. Kiểm tra inventory - item "Legendary Hoe" sẽ xuất hiện!

## 🎯 Cách sử dụng

### Sync NFT vào Inventory

Game tự động sync NFT khi:
- Game start
- Manual sync từ Web3DebugPanel

### Mint NFT khi Craft

1. Tạo NFTItemData trong Unity với:
   - `craftable = true`
   - `autoMintOnCraft = true`
2. Craft item đó trong game
3. NFT sẽ tự động được mint và hiển thị notification

### Tạo NFTItemData mới

1. Trong Unity: `Assets` → `Create` → `Web3` → `NFT Item Data`
2. Set properties:
   - **Id**: `unique_item_id` (phải match với backend)
   - **Title**: Tên hiển thị
   - **autoMintOnCraft**: true nếu muốn auto-mint
3. Đặt file trong `Resources/Items/` để được load

## 🔧 API Endpoints

### Health Check
```
GET /.netlify/functions/health
```

### Get Owned NFTs
```
GET /.netlify/functions/nfts?wallet=0x...
Response: { "items": [...] }
```

### Mint NFT
```
POST /.netlify/functions/mint
Body: { "walletAddress": "0x...", "itemId": "legendary_hoe_01" }
Response: { "objectId": "0x..." }
```

## 🔗 Tích hợp Sui Blockchain

Xem file `web3-backend/SUI_INTEGRATION.md` để biết cách tích hợp Sui blockchain thật.

Hiện tại backend đang dùng fake data cho demo. Để dùng Sui thật:
1. Deploy smart contract lên Sui
2. Update backend code theo `SUI_INTEGRATION.md`
3. Set environment variables trong Netlify

## 📝 Development

### Local Development

```bash
cd web3-backend
npm run dev  # Chạy Netlify CLI local
```

Test endpoints:
- `http://localhost:8888/.netlify/functions/health`
- `http://localhost:8888/.netlify/functions/nfts?wallet=0x123`

### Unity Development

- Debug logs: Xem Console trong Unity
- Web3DebugPanel: Nhấn phím toggle (mặc định có thể là một phím nào đó)
- Test wallet: Dùng bất kỳ address nào (ví dụ: `0xabc123`)

## 🎨 Customization

### Thêm NFT Items

1. Tạo NFTItemData trong Unity
2. Update `web3-backend/src/functions/nfts.ts` để trả về item mới
3. Deploy backend

### Thay đổi Backend URL

Trong Unity, set `Web3BackendClient.backendBaseUrl` hoặc dùng environment variable.

## 📚 Documentation

- `web3-backend/README.md` - Backend setup
- `web3-backend/SUI_INTEGRATION.md` - Sui integration guide
- `web3-backend/TEST.md` - Testing guide

## 🐛 Troubleshooting

### NFT không xuất hiện trong inventory

- Kiểm tra item ID có match giữa backend và Unity không
- Kiểm tra file NFTItemData có trong `Resources/` không
- Xem Console logs để debug

### Backend không hoạt động

- Kiểm tra Netlify deploy logs
- Test endpoints bằng curl hoặc Postman
- Đảm bảo `netlify.toml` config đúng

### Mint NFT failed

- Kiểm tra wallet address đã set chưa
- Xem Console logs để biết lỗi cụ thể
- Kiểm tra backend logs trên Netlify

## 📄 License

FarmingEngine asset có license riêng. Xem `Assets/FarmingEngine/Licence.txt`

## 🙏 Credits

- **FarmingEngine**: Game engine template
- **Sui**: Blockchain platform
- **Netlify**: Hosting platform

## 📞 Support

Nếu có vấn đề, xem:
- Unity Console logs
- Netlify Function logs
- Backend README files

---

**Happy Farming! 🌾**

