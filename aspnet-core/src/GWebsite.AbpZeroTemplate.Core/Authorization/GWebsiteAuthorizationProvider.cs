using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class GWebsiteAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public GWebsiteAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public GWebsiteAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(GWebsitePermissions.Pages) ?? context.CreatePermission(GWebsitePermissions.Pages, L("Pages"));
            var gwebsite = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_GWebsite, L("GWebsite"));

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            var categoryType = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General, L("CategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Create, L("CreatingNewCategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Edit, L("EditingCategoryType"));
            categoryType.CreateChildPermission(GWebsitePermissions.Pages_CategoryTypes_General_Delete, L("DeletingCategoryType"));

            var category = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Categories_General, L("Category"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Create, L("CreatingNewCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Edit, L("EditingCategory"));
            category.CreateChildPermission(GWebsitePermissions.Pages_Categories_General_Delete, L("DeletingCategory"));

            var orderPackages = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage, L("OrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Create, L("CreatingNewOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Edit, L("EditingOrderPackage"));
            orderPackages.CreateChildPermission(GWebsitePermissions.Pages_Administration_OrderPackage_Delete, L("DeletingOrderPackage"));

            var videoInstructions = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction, L("VideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Create, L("CreatingNewVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Edit, L("EditingVideoInstruction"));
            videoInstructions.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstruction_Delete, L("DeletingVideoInstruction"));

            var VideoInstructionCategories = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory, L("VideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Create, L("CreatingNewVVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Edit, L("EditingVideoInstructionCategory"));
            VideoInstructionCategories.CreateChildPermission(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Delete, L("DeletingVideoInstructionCategory"));
            ///project
            var duan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project, L("Project"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Create, L("CreatingNewProject"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Edit, L("EditingProject"));
            duan.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Delete, L("DeletingProject"));

            ///bid
            var thau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid, L("Bid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Create, L("CreatingNewBid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Edit, L("EditingBid"));
            thau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Delete, L("DeletingBid"));

            ///supplier
            var nhacungcap = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier, L("Supplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Create, L("CreatingNewSupplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Edit, L("EditingSupplier"));
            nhacungcap.CreateChildPermission(GWebsitePermissions.Pages_Administration_Supplier_Delete, L("DeletingSupplier"));

            ///contract
            var hopdongthau = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract, L("Contract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Create, L("CreatingNewContract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Edit, L("EditingContract"));
            hopdongthau.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Delete, L("DeletingContract"));

            ///goodsInvoice
            var phieugoihang = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice, L("GoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Create, L("CreatingNewGoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Edit, L("EditingGoodsInvoice"));
            phieugoihang.CreateChildPermission(GWebsitePermissions.Pages_Administration_GoodsInvoice_Delete, L("DeletingGoodsInvoice"));

            ///goods
            var hanghoa = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods, L("Goods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Create, L("CreatingNewGoods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Edit, L("EditingGoods"));
            hanghoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_Goods_Delete, L("DeletingGoods"));

            ///contractPayment
            var contractpayment = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPayment, L("ContractPayment"));
            contractpayment.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPayment_Create, L("CreatingNewContractPayment"));
            contractpayment.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPayment_Edit, L("EditingContractPayment"));
            contractpayment.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPayment_Delete, L("DeletingContractPayment"));

            var shoppingPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan, L("ShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Create, L("CreatingNewShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Edit, L("EditingShoppingPlan"));
            shoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlan_Delete, L("DeletingShoppingPlan"));

            var shoppingPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail, L("ShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Create, L("CreatingNewShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Edit, L("EditingShoppingPlanDetail"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Delete, L("DeletingShoppingPlanDetail"));

            var directorShoppingPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan, L("DirectorShoppingPlan"));
            directorShoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Create, L("CreatingNewDirectorShoppingPlan"));
            directorShoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Edit, L("EditingDirectorShoppingPlan"));
            directorShoppingPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Delete, L("DeletingDirectorShoppingPlan"));
            var computer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Computer, L("Computer"));
            computer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Computer_Create, L("CreatingNewComputer"));
            computer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Computer_Edit, L("EditingComputer"));
            computer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Computer_Delete, L("DeletingComputer"));

            var software = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Software, L("Software"));
            software.CreateChildPermission(GWebsitePermissions.Pages_Administration_Software_Create, L("CreatingNewSoftware"));
            software.CreateChildPermission(GWebsitePermissions.Pages_Administration_Software_Edit, L("EditingSoftware"));
            software.CreateChildPermission(GWebsitePermissions.Pages_Administration_Software_Delete, L("DeletingSoftware"));
            shoppingPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Check, L("CheckingShoppingPlanDetail"));


            var constructionPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan, L("ConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Create, L("CreatingNewConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Edit, L("EditingConstructionPlan"));
            constructionPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlan_Delete, L("DeletingConstructionPlan"));
            var assetActivity = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity, L("AssetActivity"));
            assetActivity.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity_Create, L("CreatingNewAssetActivity"));
            assetActivity.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity_Edit, L("EditingAssetActivity"));
            assetActivity.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetActivity_Delete, L("DeletingAssetActivity"));

            var constructionPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail, L("ConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Create, L("CreatingNewConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Edit, L("EditingConstructionPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Delete, L("DeletingConstructionPlanDetail"));
        
            var loaibds = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan, L("LoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Create, L("CreatingNewLoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Edit, L("EditingLoaiBatDongSan"));
            loaibds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Delete, L("DeletingLoaiBatDongSan"));

            var loaish = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu, L("LoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Create, L("CreatingNewLoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Edit, L("EditingLoaiSoHuu"));
            loaish.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Delete, L("DeletingLoaiSoHuu"));
            //Khu Vuc
            var kv = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc, L("KhuVuc"));
            kv.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc_Create, L("CreatingNewKhuVuc"));
            kv.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc_Edit, L("EditingKhuVuc"));
            kv.CreateChildPermission(GWebsitePermissions.Pages_Administration_KhuVuc_Delete, L("DeletingKhuVuc"));
            //Tinh trang su dung dat
            var ttsdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat, L("TinhTrangSuDungDat"));
            ttsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Create, L("CreatingNewTinhTrangSuDungDat"));
            ttsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Edit, L("EditingTinhTrangSuDungDat"));
            ttsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Delete, L("DeletingTinhTrangSuDungDat"));
            //Tinh trang xay dung 
            var ttxd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung, L("TinhTrangXayDung"));
            ttxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Create, L("CreatingNewTinhTrangXayDung"));
            ttxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Edit, L("EditingTinhTrangXayDung"));
            ttxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Delete, L("DeletingTinhTrangXayDung"));
            //Hien trang phap ly
            var htpl = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy, L("HienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Create, L("CreatingNewHienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Edit, L("EditingHienTrangPhapLy"));
            htpl.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Delete, L("DeletingHienTrangPhapLy"));
            //Muc dich su dung dat
            var mdsdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat, L("MucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Create, L("CreatingNewMucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Edit, L("EditingMucDichSuDungDat"));
            mdsdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Delete, L("DeletingMucDichSuDungDat"));

            var realestate_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9, L("RealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Create, L("CreatingNewRealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Edit, L("EditingRealEstate"));
            realestate_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstate9_Delete, L("DeletingRealEstate"));


            var asset_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9, L("Asset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Create, L("CreatingNewAsset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Edit, L("EditingAsset"));
            asset_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset9_Delete, L("DeletingAsset"));

            var realestatetype_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9, L("RealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Create, L("CreatingNewRealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Edit, L("EditingRealEstateType9"));
            realestatetype_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateType9_Delete, L("DeletingRealEstateType9"));

            var realestaterepair_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9, L("RealEstateRepair9"));
            realestaterepair_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Create, L("CreatingNewRealEstateRepair9"));
            realestaterepair_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Edit, L("EditingRealEstateRepair9"));
            realestaterepair_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Delete, L("DeletingRealEstateRepair9"));

            var disposalPlan = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan, L("DisposalPlan"));
            disposalPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan_Create, L("CreatingNewDisposalPlan"));
            disposalPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan_Edit, L("EditingDisposalPlan"));
            disposalPlan.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlan_Delete, L("DeletingDisposalPlan"));
            var vehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle, L("Vehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Create, L("CreatingNewVehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Edit, L("EditingVehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Delete, L("DeletingVehicle"));

            var typevehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle, L("TypeVehicle"));
            typevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle_Create, L("CreatingNewTypeVehicle"));
            typevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle_Edit, L("EditingTypeVehicle"));
            typevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_TypeVehicle_Delete, L("DeletingTypeVehicle"));


            var modelvehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle, L("ModelVehicle"));
            modelvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle_Create, L("CreatingNewModelVehicle"));
            modelvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle_Edit, L("EditingModelVehicle"));
            modelvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_ModelVehicle_Delete, L("DeletingModelVehicle"));

            var ts_8 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset, L("Asset"));
            ts_8.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset_Create, L("CreatingNewAsset"));
            ts_8.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset_Edit, L("EditingAsset"));
            ts_8.CreateChildPermission(GWebsitePermissions.Pages_QuanLyXe_Asset_Delete, L("DeletingAsset"));

            var brandvehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle, L("BrandVehicle"));
            brandvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle_Create, L("CreatingNewBrandVehicle"));
            brandvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle_Edit, L("EditingBrandVehicle"));
            brandvehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_BrandVehicle_Delete, L("DeletingBrandVehicle"));

            var operatevehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle, L("OperateVehicle"));
            operatevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle_Create, L("CreatingNewOperateVehicle"));
            operatevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle_Edit, L("EditingOperateVehicle"));
           operatevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_OperateVehicle_Delete, L("DeletingOperateVehicle"));

            var roadfeevehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle, L("RoadFeeVehicle"));
            roadfeevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Create, L("CreatingNewRoadFeeVehicle"));
            roadfeevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Edit, L("EditingRoadFeeVehicle"));
            roadfeevehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Delete, L("DeletingRoadFeeVehicle"));

            var LoaiNhaCungCap = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap, L("LoaiNhaCungCap"));
            LoaiNhaCungCap.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Create, L("CreatingNewLoaiNhaCungCap"));
            LoaiNhaCungCap.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Edit, L("EditingLoaiNhaCungCap"));
            LoaiNhaCungCap.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Delete, L("DeletingLoaiNhaCungCap"));

            var NhaCungCapHangHoa = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa, L("NhaCungCapHangHoa"));
            NhaCungCapHangHoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Create, L("CreatingNewNhaCungCapHangHoa"));
            NhaCungCapHangHoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Edit, L("EditingNhaCungCapHangHoa"));
            NhaCungCapHangHoa.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Delete, L("DeletingNhaCungCapHangHoa"));
            var bidmanager_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9, L("BidManager9"));
            bidmanager_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9_Create, L("CreatingNewBidManager9"));
            bidmanager_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9_Edit, L("EditingBidManager9"));
            bidmanager_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidManager9_Delete, L("DeletingBidManager9"));

            var construction_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9, L("Construction9"));
            construction_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9_Create, L("CreatingNewConstruction9"));
            construction_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9_Edit, L("EditingConstruction9"));
            construction_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Construction9_Delete, L("DeletingConstruction9"));

            var contractguarantee_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9, L("ContractGuarantee9"));
            contractguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Create, L("CreatingNewContractGuarantee9"));
            contractguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Edit, L("EditingContractGuarantee9"));
            contractguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Delete, L("DeletingContractGuarantee9"));

            var contractmanagement_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9, L("ContractManagement9"));
            contractmanagement_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9_Create, L("CreatingNewContractManagement9"));
            contractmanagement_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9_Edit, L("EditingContractManagement9"));
            contractmanagement_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractManagement9_Delete, L("DeletingContractManagement9"));

            var contractor_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9, L("Contractor9"));
            contractor_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9_Create, L("CreatingNewContractor9"));
            contractor_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9_Edit, L("EditingContractor9"));
            contractor_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contractor9_Delete, L("DeletingContractor9"));

            var paymentdetail_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9, L("PaymentDetail9"));
            paymentdetail_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9_Create, L("CreatingNewPaymentDetail9"));
            paymentdetail_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9_Edit, L("EditingPaymentDetail9"));
            paymentdetail_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_PaymentDetail9_Delete, L("DeletingPaymentDetail9"));

            var plan_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9, L("Plan9"));
            plan_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9_Create, L("CreatingNewPlan9"));
            plan_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9_Edit, L("EditingPlan9"));
            plan_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_Plan9_Delete, L("DeletingPlan9"));

            var warrantyguarantee_9 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9, L("WarrantyGuarantee9"));
            warrantyguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Create, L("CreatingNewWarrantyGuarantee9"));
            warrantyguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Edit, L("EditingWarrantyGuarantee9"));
            warrantyguarantee_9.CreateChildPermission(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Delete, L("DeletingWarrantyGuarantee9"));
            
            var ProductType = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType, L("ProductType"));
            ProductType.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType_Create, L("CreatingNewProductType"));
            ProductType.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType_Edit, L("EditingProductType"));
            ProductType.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductType_Delete, L("DeletingProductType"));

            var SanPham = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product, L("Product"));
            SanPham.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Create, L("CreatingNewProduct"));
            SanPham.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Edit, L("EditingProduct"));
            SanPham.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Delete, L("DeletingProduct"));

            var insurrance = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance, L("Insurrance"));
            insurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance_Create, L("CreatingNewInsurrance"));
            insurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance_Edit, L("EditingInsurrance"));
            insurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_Insurrance_Delete, L("DeletingInsurrance"));

            var insurrancetype = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType, L("InsurranceType"));
            insurrancetype.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType_Create, L("CreatingNewInsurranceType"));
            insurrancetype.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType_Edit, L("EditingInsurranceType"));
            insurrancetype.CreateChildPermission(GWebsitePermissions.Pages_Administration_InsurranceType_Delete, L("DeletingInsurranceType"));

            var disposalPlanDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail, L("DisposalPlanDetail"));
            disposalPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail_Create, L("CreatingNewDisposalPlanDetail"));
            disposalPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail_Edit, L("EditingDisposalPlanDetail"));
            disposalPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_DisposalPlanDetail_Delete, L("DeletingDisposalPlanDetail"));
            constructionPlanDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Check, L("CheckingConstructionPlanDetail"));

            var loaits = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan, L("LoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Create, L("CreatingNewLoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Edit, L("EditingLoaiTaiSan"));
            loaits.CreateChildPermission(GWebsitePermissions.Pages_Administration_LoaiTaiSan_Delete, L("DeletingLoaiTaiSan"));

            var nhomts = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan, L("NhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Create, L("CreatingNewNhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Edit, L("EditingNhomTaiSan"));
            nhomts.CreateChildPermission(GWebsitePermissions.Pages_Administration_NhomTaiSan_Delete, L("DeletingNhomTaiSan"));


            var bds = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan, L("BatDongSan"));
            bds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Create, L("CreatingNewBatDongSan"));
            bds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Edit, L("EditingBatDongSan"));
            bds.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Delete, L("DeletingBatDongSan"));

            var ts = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan, L("TaiSan"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Create, L("CreatingNewTaiSan"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Edit, L("EditingTaiSan"));
            ts.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Delete, L("DeletingTaiSan"));


            var scBDS = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan, L("SuaChuaBatDongSan"));
            scBDS.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Create, L("CreatingNewSuaChuaBatDongSan"));
            scBDS.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Edit, L("EditingSuaChuaBatDongSan"));
            scBDS.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Delete, L("DeletingSuaChuaBatDongSan"));

            var khxd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung, L("KeHoachXayDung"));
            khxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Create, L("CreatingNewKeHoachXayDung"));
            khxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Edit, L("EditingKeHoachXayDung"));
            khxd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Delete, L("DeletingKeHoachXayDung"));

            var ctdd = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang, L("CongTrinhDoDang"));
            ctdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Create, L("CreatingNewCongTrinhDoDang"));
            ctdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Edit, L("EditingCongTrinhDoDang"));
            ctdd.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_CongTrinhDoDang_Delete, L("DeletingCongTrinhDoDang"));

            var dvtN13 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau, L("HoSoThau"));
            dvtN13.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Create, L("CreatingNewHoSoThau"));
            dvtN13.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Edit, L("EditingHoSoThau"));
            dvtN13.CreateChildPermission(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Delete, L("DeletingHoSoThau"));
            var fixedAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset, L("FixedAsset"));
            fixedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset_Create, L("CreatingNewFixedAsset"));
            fixedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset_Edit, L("EditingFixedAsset"));
            fixedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_FixedAsset_Delete, L("DeletingFixedAsset"));

            var assetDashboard = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetDashboard, L("AssetDashboard"));

            var asset11 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset11, L("Asset11"));
            asset11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset11_Create, L("CreatingNewAsset11"));
            asset11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset11_CreateDebit11, L("CreatingDebit11"));
            asset11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset11_Edit, L("EditingAsset11"));
            asset11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset11_Delete, L("DeletingAsset11"));

            var debit11 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Debit11, L("Debit11"));
            debit11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Debit11_Create, L("CreatingNewDebit11"));
            debit11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Debit11_Edit, L("EditingDebit11"));
            debit11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Debit11_Delete, L("DeletingDebit11"));

            var credit11 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Credit11, L("Credit11"));
            credit11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Credit11_Create, L("CreatingNewCredit11"));
            credit11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Credit11_Edit, L("EditingCredit11"));
            credit11.CreateChildPermission(GWebsitePermissions.Pages_Administration_Credit11_Delete, L("DeletingCredit11"));

            var Asset_05 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05, L("Asset_05"));
            Asset_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05_Create, L("CreatingNewAsset_05"));
            Asset_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05_Edit, L("EditingAsset_05"));
            Asset_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_05_Delete, L("DeletingAsset_05"));

            var AssetType_05 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetType_05, L("AssetType_05"));

            var AssetGroup_05 = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05, L("AssetGroup_05"));
            AssetGroup_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05_Create, L("CreatingNewAssetGroup_05"));
            AssetGroup_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05_Edit, L("EditingAssetGroup_05"));
            AssetGroup_05.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssetGroup_05_Delete, L("DeletingAssetGroup_05"));

            var transferringAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset, L("TransferringAsset"));
            transferringAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset_Create, L("CreatingNewTransferringAsset"));
            transferringAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset_Edit, L("EditingTransferringAsset"));
            transferringAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_TransferringAsset_Delete, L("DeletingTransferringAsset"));

            var exportingUsedAsset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset, L("ExportingUsedAsset"));
            exportingUsedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Create, L("CreatingNewExportingUsedAsset"));
            exportingUsedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Edit, L("EditingExportingUsedAsset"));
            exportingUsedAsset.CreateChildPermission(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Delete, L("DeletingExportingUsedAsset"));

            var warranty = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Warranty_05, L("Warranty"));

            var purchaseOrder = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_PurchaseOrder_05, L("PurchaseOrder"));


        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
