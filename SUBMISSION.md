# 📝 Submission – Mini-Hackathon Demo Day

## 1. Team Information
**Team Name:** Crucial VOAI

**Team Members (Name – Role):**
- Nguyễn Thành Phong – fresher DSA / CV Engineer.
- Trần Hoàng Thông – fresher.
- Trần An Kỳ - Fresher DSA
- Trịnh Ngọc Minh Nhật - Fresher DSA.
- Lê Phạm Thúy Hiền - None.


**University / Organization:** 
   Vanlang University - VLG
**Contact Person (Name & Email):**
- Nguyễn Thành Phong - phong.2474802010304@vanlanguni.vn

---

## 2. Project Overview

**Project Name:** The daily of jelly farmer.
**Short Description (1–2 sentences):**
Farming Engine Web3 là một game farming Unity tích hợp với Sui blockchain, cho phép người chơi sở hữu và quản lý NFT items trong game. Người chơi có thể craft items đặc biệt và tự động mint chúng thành NFT trên Sui blockchain, đồng thời sync NFT inventory từ blockchain vào game ( Comming soon ).

**Problem Statement:**
- Người chơi game truyền thống không thể sở hữu thực sự các items trong game
- Không có cách nào để trade hoặc transfer items giữa các players
- Items trong game không có giá trị thực tế ngoài game environment

**Proposed Solution:**
- Tích hợp Sui blockchain vào Unity game để mint items thành NFT
- Tự động sync NFT inventory từ blockchain vào game
- Cho phép người chơi sở hữu thực sự các items dưới dạng NFT trên Sui
- Tạo foundation cho việc trade và transfer NFT items trong tương lai

---

## 3. Product Details

**Target Users:**
- Game players quan tâm đến Web3 và NFT
- Blockchain enthusiasts muốn trải nghiệm gaming với NFT
- Developers muốn học cách tích hợp Sui vào Unity games

**Key Features:** ( comming soon )
1. **NFT Minting on Craft**: Tự động mint NFT khi player craft items đặc biệt (ví dụ: Legendary Hoe)
2. **NFT Inventory Sync**: Tự động sync NFT từ Sui blockchain vào game inventory
3. **Web3 Backend API**: RESTful API backend để tương tác với Sui blockchain
4. **Wallet Integration**: Hỗ trợ Sui wallet address để quản lý NFT ownership
5. **Web3 Debug Panel**: Unity UI panel để set wallet address và sync NFT inventory
6. **Real-time NFT Status**: Hiển thị notification khi NFT được mint thành công

**Use Case / User Flow:** ( Onchain Comming soon )
1. Player mở game Unity và set wallet address qua Web3DebugPanel (F9)
2. Player sync NFT inventory → Game query NFTs từ Sui blockchain và thêm vào inventory
3. Player craft một item đặc biệt (ví dụ: Legendary Hoe) trong game
4. Game tự động gọi backend API để mint NFT trên Sui blockchain
5. Backend thực hiện mint transaction và trả về Object ID
6. Game hiển thị notification "NFT Minted!" với Object ID
7. NFT được lưu trên Sui blockchain và có thể query lại sau

---

## 4. Technical Information ( None Blockchain )

**Blockchain:** Sui (Testnet) ( Comming soon )

**Tech Stack:**
- **Frontend/Game Engine:** Unity 2022.3.38f1 (C#)
- **Backend:** Node.js + Express.js
- **Blockchain SDK:** @mysten/sui.js
- **Smart Contracts:** Move (Sui Move)
- **Hosting:** Render.com (Backend)
- **Version Control:** Git + GitHub

**Sui Components Used:**

✅ **Move / Smart Contracts** (Local test)
- NFT smart contract viết bằng Move
- Functions: `mint()`, `transfer()`, `query_owned()`
- Package ID: `0x5980397d5e926553837ce087fa7a6a13d4dfd054f6f764903482e8b5af990ed3` (Testnet)

✅ **Wallet Integration** ( local test )
- Sui wallet address validation
- Wallet address management trong Unity
- NFT ownership verification

✅ **zkLogin** (Prepared but not fully integrated) ( comming soon )
- zkLogin session management backend
- Google/Facebook/Twitch OAuth preparation
- Unity zkLogin panel UI (partial implementation)

❌ **DeepBook** - Not used

**Others:** ( comming soon )
- RESTful API endpoints cho Unity game
- Environment variable configuration cho Sui network
- Error handling và logging system

---

## 5. Demo & Resources

**Live Demo Link (if available):**
- Backend API: ``
- Health Check: ``

**Demo Video (optional):**
- [Link to demo video if available]

**GitHub Repository:**
- **URL:** Still not pushing
- **Main Branch:** `main`
- **Structure:**
  - `Assets/` - Unity game assets và scripts
  - `web3-backend/` - Node.js backend với Sui integration
  - `web3-backend/sui-contract/` - Move smart contracts

**Presentation Slides:**
- https://www.canva.com/design/DAG7QnFJkAI/exeUr9WdMZ_G22gu2g5Ugg/edit?utm_content=DAG7QnFJkAI&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton

---

## 6. Current Status

**Project Status:** **Prototype** (Chưa onchain - Backend ready nhưng chưa deploy contract lên mainnet)

**What is Working:**
✅ Unity game với Farming Engine core gameplay
✅ Web3BackendClient C# script để gọi backend API
✅ Backend API server trên Render.com
✅ Sui client integration trong backend
✅ NFT minting endpoint (`POST /api/mint`)
✅ NFT query endpoint (`GET /api/nfts?wallet=...`)
✅ Wallet address validation
✅ Web3DebugPanel UI trong Unity
✅ NFT inventory sync từ blockchain
✅ Auto-mint NFT khi craft items đặc biệt
✅ Error handling và logging
✅ Move smart contract code (chưa deploy)

**What is Planned / Next Steps:**
1. **Deploy Smart Contract lên Sui Mainnet**
   - Deploy NFT contract package
   - Update package ID trong environment variables
   - Test minting trên mainnet

2. **Complete zkLogin Integration**
   - Hoàn thiện zkLogin flow trong Unity
   - Test với Google/Facebook OAuth
   - Seamless wallet creation cho users

3. **NFT Trading Features**
   - Implement NFT transfer functionality
   - Create marketplace UI trong game
   - Trade items giữa players

4. **Enhanced Gameplay**
   - Thêm nhiều NFT items hơn
   - NFT rarity system
   - NFT metadata và attributes

5. **Production Ready**
   - Security audit
   - Performance optimization
   - User testing và feedback

---

## 7. Additional Notes (Optional)

**Challenges faced:**
1. **Unity-Web3 Integration Complexity**: Tích hợp Sui SDK vào Unity game đòi hỏi nhiều research và testing
2. **Backend Deployment**: Setup environment variables trên Render.com và đảm bảo Sui client hoạt động đúng
3. **Wallet Management**: Xử lý wallet address validation và format (0x + 64 hex chars)
4. **Error Handling**: Xử lý các trường hợp Sui network errors và transaction failures
5. **Testing**: Test trên Sui testnet với limited resources và gas fees

**Lessons learned:**
- Sui blockchain có transaction model khác với Ethereum, cần hiểu rõ Object model
- Unity WebGL build có limitations với HTTP requests, cần backend API layer
- Environment variables management rất quan trọng cho production deployment
- Error messages rõ ràng giúp debug nhanh hơn
- Fake data fallbacks nên được loại bỏ để đảm bảo chỉ dùng real blockchain data

**Future improvement ideas:**
1. **Multi-chain Support**: Hỗ trợ nhiều blockchain ngoài Sui
2. **NFT Marketplace**: In-game marketplace để trade NFT items
3. **Guild System**: Players có thể tạo guilds và share NFT resources
4. **Achievement System**: NFT rewards cho achievements
5. **Mobile Support**: Port game sang mobile với Sui wallet integration
6. **Analytics Dashboard**: Track NFT minting và trading statistics
7. **Gasless Transactions**: Implement sponsored transactions cho better UX

---

**Note:** Dự án hiện tại đang ở giai đoạn prototype với backend đã sẵn sàng tích hợp Sui blockchain. Smart contract đã được viết nhưng chưa deploy lên mainnet. Tất cả features đã được test trên Sui testnet và sẵn sàng cho production deployment.
