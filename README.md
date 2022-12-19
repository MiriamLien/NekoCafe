# NekoCafe
## ネコカフェ予約システム開発
#### 基本功能
- 前台是貓咪咖啡廳的官方網站，有主頁、公告/活動頁面、貓咪頁面、菜單頁面和預約頁面可以觀看
- 主頁是介紹咖啡廳的經營理念、收費方案以及入店須知
- 公告/活動頁面是顯示咖啡廳的公告以及近期置辦的活動訊息
- 貓咪頁面是店內貓咪的簡單介紹
- 菜單頁面是依照類別顯示所有咖啡廳內的餐點品項
- 預約頁面有著餐廳的介紹、注意事項以及位置，並可進行預約及事先點餐的動作
- 登入後台可分成店長與店員兩種身份的管理頁面，皆可觀看與搜尋所有帳號、預約內容、貓咪、公告以及菜單的資訊。另外，店長的管理頁面則多了一個權限管理
- 後台可對帳號、預約內容、貓咪、公告以及菜單的資訊進行管理(新增、修改和刪除)，還有變更該帳號之密碼的動作
<br />

#### 資料庫(MSSQL)
<br />

#### 環境依賴
ASP.NET Framwork 4.7.2
<br />
<br />

#### 起始頁面
`index.aspx` 前台首頁
<br />
<br />

#### 目錄結構描述
前台
>`Main.Master` 前台主版
>
>`Event.aspx` 公告/活動頁面
>
>`Cats.aspx` 貓咪頁面
>
>`Menu.aspx` 菜單頁面
>
>`ReservationPage.aspx` 預約頁面
>
>`Login.aspx` (前往後台)登入頁面
>
>`NewAccount.aspx` 新創會員頁面
>
>`Account_Info.aspx` 會員個人資訊頁面
<br />

後台 BackAdmin <br />
>`index.Master` 後台主版
>
>`adminHome.aspx` 後台首頁
>
>`adminAccount.aspx` 帳號管理頁面
>
>`adminReservation.aspx` 預約管理頁面
>
>`adminCats.aspx` 貓咪管理頁面(可對貓咪資訊、狀態和品種進行新增、修改以及刪除)
>
>`adminNews.aspx` 公告管理頁面(可對公告與公告內的圖片進行新增、修改以及刪除)
>
>`adminMenu.aspx` 餐點管理頁面
>
>`adminSetting.aspx` 設定頁面(密碼變更)
>
>`adminPermissions.aspx` 權限管理頁面
<br />

Models
>`AccountModel.cs` 帳號Model
>
>`ALModel.cs` 帳號和權限Model
>
>`ArticleModel.cs` 公告(文章內容和圖片)Model
>
>`BPModel.cs` 公告和餐點Model
>
>`BulletinModel.cs` 公告資訊Model
>
>`CatBreedModel.cs` 貓咪品種Model
>
>`CatModel.cs` 貓咪資訊Model
>
>`CatStateModel.cs` 貓咪狀態Model
>
>`CCModel.cs` 貓咪資訊和狀態Model
>
>`ItemAndPriceModel.cs` 餐點和價格Model
>
>`ItemModel.cs` 餐點品項資訊Model
>
>`MemberInfoModel.cs` 會員資訊Model
>
>`MRModel.cs` 會員和預訂資訊Model
>
>`OIModel.cs` 預訂餐點資訊Model
>
>`OrderItemModel.cs` 訂單(含餐點)資訊Model
>
>`OrderModel.cs` 預約資訊Model
>
>`ORModel.cs` 預約和訂位人資訊Model
>
>`PictureModel.cs` 圖片Model
>
>`ReservationModel.cs` 訂位人資訊Model
<br />

Managers (與資料庫溝通的方法)
>`AccountManager.cs` 帳號管理
>
>`BulletinManager.cs` 公告管理
>
>`CatBreedManager.cs` 貓咪品種管理
>
>`CatManager.cs` 貓咪資訊管理
>
>`CatStateManager.cs` 貓咪狀態管理
>
>`ItemClassManager.cs` 餐點品項類別管理
>
>`ItemManager.cs` 餐點品項管理
>
>`MemberManager.cs` 會員管理
>
>`NewsFromBulletinManager.cs` 公告內的消息管理
>
>`OrderItemManager.cs` 訂單品項管理
>
>`OrderManager.cs` 訂單管理
>
>`PermissionsManager.cs` 權限管理
>
>`PictureManager.cs` 圖片管理
>
>`ReservationManager.cs` 預約管理
<br />

Helpers
>`AccountHelper.cs` 密碼進行雜湊
>
>`configHelper.cs` 讀取設定檔中的連線字串
>
>`FileHelper.cs` 檢查圖片檔的副檔名是否在允許清單中
>
>`Logger.cs` 記錄錯誤訊息
<br />

#### 後台登入帳密(店長)
- 帳號: Admin
- 密碼: 123456789
