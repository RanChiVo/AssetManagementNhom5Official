using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.Zero.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Core;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using GWebsite.AbpZeroTemplate.Core.Models.RealEstasAsset.QuanLyBDS;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;
using GWebsite.AbpZeroTemplate.Core.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.EntityFrameworkCore
{
    public abstract class GWebsiteDbContext<TTenant, TRole, TUser, TSelf> : AbpZeroDbContext<TTenant, TRole, TUser, TSelf>
        where TTenant : AbpTenant<TUser>
        where TRole : AbpRole<TUser>
        where TUser : AbpUser<TUser>
        where TSelf : GWebsiteDbContext<TTenant, TRole, TUser, TSelf>
    {
        public virtual DbSet<AdsPage> AdsPages { get; set; }
        public virtual DbSet<AlepayTransactionInfo> AlepayTransactionInfos { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppUserClaim> AppUserClaims { get; set; }
        public virtual DbSet<AppUserLogin> AppUserLogins { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footers> Footers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<MenuClient> MenuClients { get; set; }
        public virtual DbSet<DemoModel> DemoModels { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CategoryType> CategoryTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderPackage> OrderPackages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OwOverviewEcommerce> OwOverviewEcommerce { get; set; }
        public virtual DbSet<OwPageBehaviorEcommerce> OwPageBehaviorEcommerce { get; set; }
        public virtual DbSet<OwProductlistPerformanceEcommerce> OwProductlistPerformanceEcommerce { get; set; }
        public virtual DbSet<OwProductPerformace> OwProductPerformace { get; set; }
        public virtual DbSet<OwShoppingBehaviorEcommerce> OwShoppingBehaviorEcommerce { get; set; }
        public virtual DbSet<OwTrafficSourceEcommerce> OwTrafficSourceEcommerce { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<GoodsInvoice> GoodsInvoices { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<ShoppingPlan> ShoppingPlans { get; set; }
        public virtual DbSet<ShoppingPlanDetail> ShoppingPlanDetails { get; set; }
        public virtual DbSet<DirectorShoppingPlan> DirectorShoppingPlans { get; set; }
        public virtual DbSet<ConstructionPlan> ConstructionPlans { get; set; }
        public virtual DbSet<ConstructionPlanDetail> ConstructionPlanDetails { get; set; }


        public virtual DbSet<BatDongSan> BatDongSan_N13 { get; set; }
        public virtual DbSet<GiayPhepSuDung> GiayPhepSuDung_N13 { get; set; }
        public virtual DbSet<HienTrangPhapLy> HienTrangPhapLy_N13 { get; set; }
        public virtual DbSet<LoaiBatDongSan> LoaiBatDongSan_N13 { get; set; }

        public virtual DbSet<LoaiSoHuu> LoaiSoHuu_N13 { get; set; }

        public virtual DbSet<MucDinhSuDungDat> MucDinhSuDungDat_N13 { get; set; }

        public virtual DbSet<TinhTrangSuDungDat> TinhTrangSuDungDat_N13 { get; set; }

        public virtual DbSet<TinhTrangXayDung> TinhTrangXayDung_N13 { get; set; }

        public virtual DbSet<TaiSan_13> TaiSan_13 { get; set; }


        public virtual DbSet<SuaChuaBatDongSan> SuaChuaBatDongSan_N13 { get; set; }

        public virtual DbSet<KeHoachXayDung_N13> KeHoachXayDung_N13 { get; set; }

        public virtual DbSet<CongTrinh_N13> CongTrinh_N13 { get; set; }

        public virtual DbSet<HoSoThau_N13> HoSoThau_N13 { get; set; }

        public virtual DbSet<DonViThau_N13> DonViThau_N13 { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }

        public virtual DbSet<FixedAsset> FixedAssets { get; set; }
        public virtual DbSet<Asset_05> Assets_05 { get; set; }
       // public virtual DbSet<AssetDetail_05> AssetDetails_05 { get; set; }
        public virtual DbSet<AssetType_05> AssetTypes_05 { get; set; }
        public virtual DbSet<AssetGroup_05> AssetGroups_05 { get; set; }
        //public virtual DbSet<Depreciation_05> Depreciations_05 { get; set; }
        //public virtual DbSet<DepreciationDetail_05> DepreciationDetails_05 { get; set; }
        //public virtual DbSet<Liquidation_05> Liquidations_05 { get; set; }
        //public virtual DbSet<LiquidationDetail_05> LiquidationDetails_05 { get; set; }
        //public virtual DbSet<Repair_05> Repairs_05 { get; set; }
        //public virtual DbSet<RepairDetail_05> RepairDetails_05 { get; set; }
        //public virtual DbSet<UsingProcess_05> UsingProcess_05 { get; set; }
        //public virtual DbSet<UsingProcessDetail_05> UsingProcessDetail_05 { get; set; }
        //public virtual DbSet<Warranty_05> Warrantys_05 { get; set; }
        //public virtual DbSet<WarrantyDetail_05> WarrantyDetails_05 { get; set; }


        public virtual DbSet<AssetActivity> AssetActivities { get; set; }
        public virtual DbSet<DisposalPlan> DisposalPlans { get; set; }
        public virtual DbSet<DisposalPlanDetail> DisposalPlanDetails { get; set; }
        public virtual DbSet<ContractPayment> ContractPayments { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<TypeVehicle> TypeVehicles { get; set; }
        public virtual DbSet<ModelVehicle> ModelVehicles { get; set; }
        public virtual DbSet<Asset_8> Assets_8 { get; set; }
        public virtual DbSet<BrandVehicle> BrandVehicles { get; set; }
        public virtual DbSet<OperateVehicle> OperateeVehicles { get; set; }
        public virtual DbSet<RoadFeeVehicle> RoadFeeVehicles { get; set; }
        public virtual DbSet<Insurrance> Insurrances { get; set; }
        public virtual DbSet<InsurranceType> InsurranceTypes { get; set; }
        public virtual DbSet<Warranty_05> Warrantys_05 { get; set; }
        public virtual DbSet<PurchaseOder_05> PurchaseOders_05 { get; set; }
        public virtual DbSet<ExportingUsedAsset> ExportingUsedAsset { get; set; }
        public virtual DbSet<TransferringAsset> TransferringAsset { get; set; }
        public virtual DbSet<AssetUnitFather_05> AssetUnitFather_05 { get; set; }
        public virtual DbSet<AssetRegion_05> AssetRegion_05 { get; set; }
        public virtual DbSet<AssetUnit_05> AssetUnit_05 { get; set; }
        public virtual DbSet<AssetUser_05> AssetUser_05 { get; set; }
        public virtual DbSet<Liquidation_05> Liquidation_05 { get; set; }
        public virtual DbSet<UsingProcess_05> UsingProcess_05 { get; set; }
        /// <summary>
        /// GPermissions dùng cho bên Gwebsite
        /// </summary>
        public virtual DbSet<Permission> GPermissions { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductQuantity> ProductQuantities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<SupportOnline> SupportOnlines { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserManualCategory> UserManualCategories { get; set; }
        public virtual DbSet<UserManual> UserManuals { get; set; }
        public virtual DbSet<VideoInstructionCategory> VideoInstructionCategories { get; set; }
        public virtual DbSet<VideoInstruction> VideoInstructions { get; set; }
        public virtual DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        public virtual DbSet<Asset_test9> Assets_Test9 { get; set; }
        public virtual DbSet<RealEstate_9> RealEstates_9 { get; set; }

        public virtual DbSet<RealEstateType_9> RealEstateTypes_9 { get; set; }
        public virtual DbSet<RealEstateRepair_9> RealEstateRepairs_9 { get; set; }

        public virtual DbSet<BidManager_9> BidManagers_9 { get; set; }
        public virtual DbSet<Construction_9> Constructions_9 { get; set; }
        public virtual DbSet<Contractors_9> Contractors_9 { get; set; }
        public virtual DbSet<Plan_9> Plans_9 { get; set; }
        public virtual DbSet<ContractManagement> ContractManagements_9 { get; set; }
        public virtual DbSet<ContractGuarantee> ContractGuarantees_9 { get; set; }
        public virtual DbSet<PaymentDetails_9> PaymentDetails_9 { get; set; }
        public virtual DbSet<WarrantyGuarantee> WarrantyGuarantees_9 { get; set; }
        public virtual DbSet<Asset11> Asset11s { get; set; }
        public virtual DbSet<Debit11> Debit11s { get; set; }
        public virtual DbSet<Credit11> Credit11s { get; set; }
        public virtual DbSet<LoaiNhaCungCap> LoaiNhaCungCaps { get; set; }
        public virtual DbSet<NhaCungCapHangHoa> NhaCungCapHangHoas { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected GWebsiteDbContext(DbContextOptions<TSelf> options)
            : base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlepayTransactionInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlepayToken).HasColumnName("alepayToken");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.BankCode).HasColumnName("bankCode");

                entity.Property(e => e.BankHotline).HasColumnName("bankHotline");

                entity.Property(e => e.BankName).HasColumnName("bankName");

                entity.Property(e => e.BuyerEmail).HasColumnName("buyerEmail");

                entity.Property(e => e.BuyerName).HasColumnName("buyerName");

                entity.Property(e => e.BuyerPhone).HasColumnName("buyerPhone");

                entity.Property(e => e.Cancel).HasColumnName("cancel");

                entity.Property(e => e.CardNumber).HasColumnName("cardNumber");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.ErrorCode).HasColumnName("errorCode");

                entity.Property(e => e.Installment).HasColumnName("installment");

                entity.Property(e => e.Is3D).HasColumnName("is3D");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.OrderCode).HasColumnName("orderCode");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SuccessTime).HasColumnName("successTime");

                entity.Property(e => e.TransactionCode).HasColumnName("transactionCode");

                entity.Property(e => e.TransactionTime).HasColumnName("transactionTime");
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                //entity.HasIndex(e => e.UserId)
                //    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Announcements_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AnnouncementUser>(entity =>
            {
                entity.HasKey(e => new { e.AnnouncementId, e.UserId });

                //entity.HasIndex(e => e.AnnouncementId)
                //    .HasName("IX_AnnouncementId");

                //entity.HasIndex(e => e.UserId)
                //    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.AnnouncementId)
                    .HasConstraintName("FK_dbo.AnnouncementUsers_dbo.Announcements_AnnouncementId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AnnouncementUsers_dbo.AppUsers_UserId");
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);
            });


            modelBuilder.Entity<AppUserClaim>(entity =>
            {
                entity.HasKey(e => e.UserId);

                //entity.HasIndex(e => e.AppUserId)
                //    .HasName("IX_AppUser_Id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppUserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                //entity.HasIndex(e => e.AppUserId)
                //    .HasName("IX_AppUser_Id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserLogins)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserLogins_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                //entity.HasIndex(e => e.AppUserId)
                //    .HasName("IX_AppUser_Id");

                //entity.HasIndex(e => e.IdentityRoleId)
                //    .HasName("IX_IdentityRole_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.IdentityRoleId)
                    .HasColumnName("IdentityRole_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserRoles_dbo.AppUsers_AppUser_Id");

                entity.HasOne(d => d.IdentityRole)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.IdentityRoleId)
                    .HasConstraintName("FK_dbo.AppUserRoles_dbo.AppRoles_IdentityRole_Id");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveDt)
                    .HasColumnName("ActiveDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("ApproveDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.ChargeDt)
                    .HasColumnName("ChargeDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckId).HasColumnName("CheckID");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CreateDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.DxcontactPerson).HasColumnName("DXContactPerson");

                entity.Property(e => e.Dxsurrogate).HasColumnName("DXSurrogate");

                entity.Property(e => e.EditorDt)
                    .HasColumnName("EditorDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EditorID");

                entity.Property(e => e.ExpireDt)
                    .HasColumnName("ExpireDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.MakerId).HasColumnName("MakerID");

                entity.Property(e => e.SignContractDt)
                    .HasColumnName("SignContractDT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(250);
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Footers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<Function>(entity =>
            {
                //entity.HasIndex(e => e.ParentId)
                //    .HasName("IX_ParentId");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Functions_dbo.Functions_ParentId");
            });

            modelBuilder.Entity<MenuClient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                //entity.HasIndex(e => e.ColorId)
                //    .HasName("IX_ColorId");

                //entity.HasIndex(e => e.OrderId)
                //    .HasName("IX_OrderID");

                //entity.HasIndex(e => e.ProductId)
                //    .HasName("IX_ProductID");

                //entity.HasIndex(e => e.SizeId)
                //    .HasName("IX_SizeId");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Colors_ColorId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Orders_OrderID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Products_ProductID");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Sizes_SizeId");
            });

            modelBuilder.Entity<OrderPackage>(entity =>
                        {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.AuthStatus1).HasColumnName("AuthStatus");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CheckId).HasColumnName("CheckID");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.ExpireDt)
                    .HasColumnName("ExpireDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(256);

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.SumCheckout).HasColumnType("money");

                entity.Property(e => e.SumRegister).HasColumnType("money");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                //entity.HasIndex(e => e.CustomerId)
                //    .HasName("IX_CustomerId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerId).HasMaxLength(128);

                entity.Property(e => e.CustomerMessage)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerMobile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PaymentMethod).HasMaxLength(256);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Orders_dbo.AppUsers_CustomerId");
            });

            modelBuilder.Entity<OwOverviewEcommerce>(entity =>
            {
                entity.HasKey(e => e.OverviewEcommerceId);

                entity.ToTable("OW_OVERVIEW_ECOMMERCE");

                entity.Property(e => e.OverviewEcommerceId).HasColumnName("OVERVIEW_ECOMMERCE_ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Domain).HasColumnName("DOMAIN");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.NewsUsers).HasColumnName("NEWS_USERS");

                entity.Property(e => e.Pageviews).HasColumnName("PAGEVIEWS");

                entity.Property(e => e.Productaddstocart).HasColumnName("PRODUCTADDSTOCART");

                entity.Property(e => e.Productcheckouts).HasColumnName("PRODUCTCHECKOUTS");

                entity.Property(e => e.Productdetailviews).HasColumnName("PRODUCTDETAILVIEWS");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.Sessions).HasColumnName("SESSIONS");

                entity.Property(e => e.Timeonpage).HasColumnName("TIMEONPAGE");

                entity.Property(e => e.Transactionrevenue).HasColumnName("TRANSACTIONREVENUE");

                entity.Property(e => e.Users).HasColumnName("USERS");

                entity.Property(e => e.Version).HasColumnName("VERSION");

                entity.Property(e => e.VersionInt).HasColumnName("VERSION_INT");
            });

            modelBuilder.Entity<OwPageBehaviorEcommerce>(entity =>
            {
                entity.HasKey(e => e.PageBehaviorEcommerceId);

                entity.ToTable("OW_PAGE_BEHAVIOR_ECOMMERCE");

                entity.Property(e => e.PageBehaviorEcommerceId).HasColumnName("PAGE_BEHAVIOR_ECOMMERCE_ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dimensions).HasColumnName("DIMENSIONS");

                entity.Property(e => e.Domain).HasColumnName("DOMAIN");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.ExitRate).HasColumnName("EXIT_RATE");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.PagePath).HasColumnName("PAGE_PATH");

                entity.Property(e => e.PageValue).HasColumnName("PAGE_VALUE");

                entity.Property(e => e.PageView).HasColumnName("PAGE_VIEW");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.TimeOnPage).HasColumnName("TIME_ON_PAGE");

                entity.Property(e => e.VersionInt).HasColumnName("VERSION_INT");
            });

            modelBuilder.Entity<OwProductlistPerformanceEcommerce>(entity =>
            {
                entity.HasKey(e => e.ProductlistPerformanceEcommerceId);

                entity.ToTable("OW_PRODUCTLIST_PERFORMANCE_ECOMMERCE");

                entity.Property(e => e.ProductlistPerformanceEcommerceId).HasColumnName("PRODUCTLIST_PERFORMANCE_ECOMMERCE_ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dimensions).HasColumnName("DIMENSIONS");

                entity.Property(e => e.Domain).HasColumnName("DOMAIN");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.ItemRevenue).HasColumnName("ITEM_REVENUE");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.ProductDetailViews).HasColumnName("PRODUCT_DETAIL_VIEWS");

                entity.Property(e => e.Productlist).HasColumnName("PRODUCTLIST");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.QuantityAddedToCart).HasColumnName("QUANTITY_ADDED_TO_CART");

                entity.Property(e => e.QuantityCheckedOut).HasColumnName("QUANTITY_CHECKED_OUT");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.VersionInt).HasColumnName("VERSION_INT");
            });

            modelBuilder.Entity<OwProductPerformace>(entity =>
            {
                entity.HasKey(e => e.OverviewEcommerceId);

                entity.ToTable("OW_PRODUCT_PERFORMACE");

                entity.Property(e => e.OverviewEcommerceId).HasColumnName("OVERVIEW_ECOMMERCE_ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dimensions).HasColumnName("DIMENSIONS");

                entity.Property(e => e.Domain).HasColumnName("DOMAIN");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.ItemRevenue).HasColumnName("ITEM_REVENUE");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.ProductDetailViews).HasColumnName("PRODUCT_DETAIL_VIEWS");

                entity.Property(e => e.ProductName).HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.QuantityAddedToCart).HasColumnName("QUANTITY_ADDED_TO_CART");

                entity.Property(e => e.QuantityCheckedOut).HasColumnName("QUANTITY_CHECKED_OUT");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.Version).HasColumnName("VERSION");

                entity.Property(e => e.VersionInt).HasColumnName("VERSION_INT");
            });

            modelBuilder.Entity<OwShoppingBehaviorEcommerce>(entity =>
            {
                entity.HasKey(e => e.ShoppingBehaviorEcommerceId);

                entity.ToTable("OW_SHOPPING_BEHAVIOR_ECOMMERCE");

                entity.Property(e => e.ShoppingBehaviorEcommerceId).HasColumnName("SHOPPING_BEHAVIOR_ECOMMERCE_ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dimensions).HasColumnName("DIMENSIONS");

                entity.Property(e => e.Domain).HasColumnName("DOMAIN");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.ItemRevenue).HasColumnName("ITEM_REVENUE");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.ProductDetailViews).HasColumnName("PRODUCT_DETAIL_VIEWS");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.QuantityAddedToCart).HasColumnName("QUANTITY_ADDED_TO_CART");

                entity.Property(e => e.QuantityCheckedOut).HasColumnName("QUANTITY_CHECKED_OUT");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.UserType).HasColumnName("USER_TYPE");

                entity.Property(e => e.VersionInt).HasColumnName("VERSION_INT");
            });

            modelBuilder.Entity<OwTrafficSourceEcommerce>(entity =>
            {
                entity.HasKey(e => e.TrafficSourceEcommerceId);

                entity.ToTable("OW_TRAFFIC_SOURCE_ECOMMERCE");

                entity.Property(e => e.TrafficSourceEcommerceId).HasColumnName("TRAFFIC_SOURCE_ECOMMERCE_ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Domain).HasColumnName("DOMAIN");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.Exits).HasColumnName("EXITS");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.Medium).HasColumnName("MEDIUM");

                entity.Property(e => e.Pageviews).HasColumnName("PAGEVIEWS");

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.Sessionduration).HasColumnName("SESSIONDURATION");

                entity.Property(e => e.Sessions).HasColumnName("SESSIONS");

                entity.Property(e => e.Source).HasColumnName("SOURCE");

                entity.Property(e => e.Transactionrevenue).HasColumnName("TRANSACTIONREVENUE");

                entity.Property(e => e.Transactions).HasColumnName("TRANSACTIONS");

                entity.Property(e => e.Version).HasColumnName("VERSION");

                entity.Property(e => e.VersionInt).HasColumnName("VERSION_INT");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdPackagePrices).HasMaxLength(100);

                entity.Property(e => e.MaAdmin).HasMaxLength(128);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.SoTaiKhoan).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                //entity.HasIndex(e => e.FunctionId)
                //    .HasName("IX_FunctionId");

                //entity.HasIndex(e => e.RoleId)
                //    .HasName("IX_RoleId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FunctionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.Functions_FunctionId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.AppRoles_RoleId");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                //entity.HasIndex(e => e.CategoryId)
                //    .HasName("IX_CategoryID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Posts_dbo.PostCategories_CategoryID");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId });

                //entity.HasIndex(e => e.PostId)
                //    .HasName("IX_PostID");

                //entity.HasIndex(e => e.TagId)
                //    .HasName("IX_TagID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_dbo.PostTags_dbo.Posts_PostID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.PostTags_dbo.Tags_TagID");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                //entity.HasIndex(e => e.ProductId)
                //    .HasName("IX_ProductId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caption).HasMaxLength(250);

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.ProductImages_dbo.Products_ProductId");
            });

            modelBuilder.Entity<ProductQuantity>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SizeId, e.ColorId });

                //entity.HasIndex(e => e.ColorId)
                //    .HasName("IX_ColorId");

                //entity.HasIndex(e => e.ProductId)
                //    .HasName("IX_ProductId");

                //entity.HasIndex(e => e.SizeId)
                //    .HasName("IX_SizeId");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_dbo.ProductQuantities_dbo.Colors_ColorId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.ProductQuantities_dbo.Products_ProductId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductQuantities)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_dbo.ProductQuantities_dbo.Sizes_SizeId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                //entity.HasIndex(e => e.CategoryId)
                //    .HasName("IX_CategoryID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IncludedVat).HasColumnName("IncludedVAT");

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ThumbnailImage).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_dbo.Products_dbo.ProductCategories_CategoryID");
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.TagId });

                //entity.HasIndex(e => e.ProductId)
                //    .HasName("IX_ProductID");

                //entity.HasIndex(e => e.TagId)
                //    .HasName("IX_TagID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.ProductTags_dbo.Products_ProductID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.ProductTags_dbo.Tags_TagID");
            });


            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Url).HasMaxLength(256);
            });

            modelBuilder.Entity<SupportOnline>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Facebook).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.Yahoo).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserManualCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserManual>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VideoInstructionCategory>(entity =>
            {
                //entity.HasIndex(e => e.PriceId)
                //    .HasName("IX_PriceId");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.VideoInstructionCategories)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK_dbo.VideoInstructionCategories_dbo.Prices_PriceId");
            });

            modelBuilder.Entity<VideoInstruction>(entity =>
            {
                //entity.HasIndex(e => e.VideoInstructionCategoryId)
                //    .HasName("IX_VideoInstructionCategoryId");

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("APPROVE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");

                entity.Property(e => e.CheckerId).HasColumnName("CHECKER_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditDt)
                    .HasColumnName("EDIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EDITOR_ID");

                entity.Property(e => e.MakerId).HasColumnName("MAKER_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.HasOne(d => d.VideoInstructionCategory)
                    .WithMany(p => p.VideoInstructions)
                    .HasForeignKey(d => d.VideoInstructionCategoryId)
                    .HasConstraintName("FK_dbo.VideoInstructions_dbo.VideoInstructionCategories_VideoInstructionCategoryId");
            });

            modelBuilder.Entity<VisitorStatistic>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.VisitedDate).HasColumnType("datetime");
            });
        }
    }
}
