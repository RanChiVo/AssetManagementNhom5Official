using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.Computers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Softwares.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;
using GWebsite.AbpZeroTemplate.Core.Models.RealEstasAsset.QuanLyBDS;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.CongTrinh_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Debit11s.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Credit11s.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets;

namespace GWebsite.AbpZeroTemplate.Applications
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Slide, SlideDto>();
            configuration.CreateMap<CreateSlideInput, Slide>();
            configuration.CreateMap<UpdateSlideInput, Slide>();

            configuration.CreateMap<VideoInstruction, VideoInstructionDto>();
            configuration.CreateMap<CreateVideoInstructionInput, VideoInstruction>();
            configuration.CreateMap<UpdateVideoInstructionInput, VideoInstruction>();

            configuration.CreateMap<OrderPackage, OrderPackageDto>();
            configuration.CreateMap<CreateOrderPackageInput, OrderPackage>();
            configuration.CreateMap<UpdateOrderPackageInput, OrderPackage>();

            configuration.CreateMap<VideoInstructionCategory, VideoInstructionCategoryDto>();
            configuration.CreateMap<CreateVideoInstructionCategoryInput, VideoInstructionCategory>();
            configuration.CreateMap<UpdateVideoInstructionCategoryInput, VideoInstructionCategory>();

            // Category type
            configuration.CreateMap<CategoryType, CategoryTypeDto>();
            configuration.CreateMap<CategoryTypeInput, CategoryType>();
            configuration.CreateMap<CategoryType, CategoryTypeInput>();
            configuration.CreateMap<CategoryType, CategoryTypeForViewDto>();

            // Category 
            configuration.CreateMap<Category, CategoryDto>();
            configuration.CreateMap<CategoryInput, Category>();
            configuration.CreateMap<Category, CategoryInput>();
            configuration.CreateMap<Category, CategoryForViewDto>();
            //project
            configuration.CreateMap<Project, ProjectDto>();
            configuration.CreateMap<ProjectInput, Project>();
            configuration.CreateMap<Project, ProjectInput>();
            configuration.CreateMap<Project, ProjectForViewDto>();

            //bid
            configuration.CreateMap<Bid, BidDto>();
            configuration.CreateMap<BidInput, Bid>();
            configuration.CreateMap<Bid, BidInput>();
            configuration.CreateMap<Bid, BidForViewDto>();

            //supplier
            configuration.CreateMap<Supplier, SupplierDto>();
            configuration.CreateMap<SupplierInput, Supplier>();
            configuration.CreateMap<Supplier, SupplierInput>();
            configuration.CreateMap<Supplier, SupplierForViewDto>();

            //contract
            configuration.CreateMap<Contract, ContractDto>();
            configuration.CreateMap<ContractInput, Contract>();
            configuration.CreateMap<Contract, ContractInput>();
            configuration.CreateMap<Contract, ContractForViewDto>();

            //goodsInvoice
            configuration.CreateMap<GoodsInvoice, GoodsInvoiceDto>();
            configuration.CreateMap<GoodsInvoiceInput, GoodsInvoice>();
            configuration.CreateMap<GoodsInvoice, GoodsInvoiceInput>();
            configuration.CreateMap<GoodsInvoice, GoodsInvoiceForViewDto>();

            //goods
            configuration.CreateMap<Goods, GoodsDto>();
            configuration.CreateMap<GoodsInput, Goods>();
            configuration.CreateMap<Goods, GoodsInput>();
            configuration.CreateMap<Goods, GoodsForViewDto>();

            //ShoppingPlan
            configuration.CreateMap<ShoppingPlan, ShoppingPlanDto>();
            configuration.CreateMap<ShoppingPlanInput, ShoppingPlan>();
            configuration.CreateMap<ShoppingPlan, ShoppingPlanInput>();
            configuration.CreateMap<ShoppingPlan, ShoppingPlanForViewDto>();

            //DirectorShoppingPlan
            configuration.CreateMap<DirectorShoppingPlan, DirectorShoppingPlanDto>();
            configuration.CreateMap<DirectorShoppingPlanInput, DirectorShoppingPlan>();
            configuration.CreateMap<DirectorShoppingPlan, DirectorShoppingPlanInput>();
            configuration.CreateMap<DirectorShoppingPlan, DirectorShoppingPlanForViewDto>();

            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailDto>();
            configuration.CreateMap<ShoppingPlanDetailInput, ShoppingPlanDetail>();
            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailInput>();

            //ConstructionPlan
            configuration.CreateMap<ConstructionPlan, ConstructionPlanDto>();
            configuration.CreateMap<ConstructionPlanInput, ConstructionPlan>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanInput>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanForViewDto>();

            //ConstructionPlanDetail
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailDto>();
            configuration.CreateMap<ConstructionPlanDetailInput, ConstructionPlanDetail>();
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailInput>();

            // LoaiBDS
            configuration.CreateMap<LoaiBatDongSan, LoaiBatDongSanDto>();
            configuration.CreateMap<LoaiBatDongSanInput, LoaiBatDongSan>();
            configuration.CreateMap<LoaiBatDongSan, LoaiBatDongSanInput>();
            configuration.CreateMap<LoaiBatDongSan, LoaiBatDongSanForViewDto>();

            // LoaiSH
            configuration.CreateMap<LoaiSoHuu, LoaiSoHuuDto>();
            configuration.CreateMap<LoaiSoHuuInput, LoaiSoHuu>();
            configuration.CreateMap<LoaiSoHuu, LoaiSoHuuInput>();
            configuration.CreateMap<LoaiSoHuu, LoaiSoHuuForViewDto>();

            //Khu Vuc
            configuration.CreateMap<KhuVuc, KhuVucDto>();
            configuration.CreateMap<KhuVucInput, KhuVuc>();
            configuration.CreateMap<KhuVuc, KhuVucInput>();
            configuration.CreateMap<KhuVuc, KhuVucForViewDto>();
            //Tinh trang su dung dat 
            configuration.CreateMap<TinhTrangSuDungDat, TinhTrangSuDungDatDto>();
            configuration.CreateMap<TinhTrangSuDungDatInput, TinhTrangSuDungDat>();
            configuration.CreateMap<TinhTrangSuDungDat, TinhTrangSuDungDatInput>();
            configuration.CreateMap<TinhTrangSuDungDat, TinhTrangSuDungDatForViewDto>();
            // Tinh trang xay dung 
            configuration.CreateMap<TinhTrangXayDung, TinhTrangXayDungDto>();
            configuration.CreateMap<TinhTrangXayDungInput, TinhTrangXayDung>();
            configuration.CreateMap<TinhTrangXayDung, TinhTrangXayDungInput>();
            configuration.CreateMap<TinhTrangXayDung, TinhTrangXayDungForViewDto>();
            //Hien trang phap ly
            configuration.CreateMap<HienTrangPhapLy, HienTrangPhapLyDto>();
            configuration.CreateMap<HienTrangPhapLyInput, HienTrangPhapLy>();
            configuration.CreateMap<HienTrangPhapLy, HienTrangPhapLyInput>();
            configuration.CreateMap<HienTrangPhapLy, HienTrangPhapLyForViewDto>();
            //Muc dich su dung dat 
            configuration.CreateMap<MucDichSuDungDat, MucDichSuDungDatDto>();
            configuration.CreateMap<MucDichSuDungDatInput, MucDichSuDungDat>();
            configuration.CreateMap<MucDichSuDungDat, MucDichSuDungDatInput>();
            configuration.CreateMap<MucDichSuDungDat, MucDichSuDungDatForViewDto>();

          

            configuration.CreateMap<BatDongSan, BatDongSanDto>();
            configuration.CreateMap<BatDongSanInput, BatDongSan>();
            configuration.CreateMap<BatDongSan, BatDongSanInput>();
            configuration.CreateMap<BatDongSan, BatDongSanForViewDto>();

            //ts
            configuration.CreateMap<TaiSan_13, TaiSanDto>();
            configuration.CreateMap<TaiSanInput, TaiSan_13>();
            configuration.CreateMap<TaiSan_13, TaiSanInput>();
            configuration.CreateMap<TaiSan_13, TaiSanForViewDto>();

            //sc bds
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanDto>();
            configuration.CreateMap<SuaChuaBatDongSanInput, SuaChuaBatDongSan>();
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanInput>();
            configuration.CreateMap<SuaChuaBatDongSan, SuaChuaBatDongSanForViewDto>();

            //cong trinh
            configuration.CreateMap<CongTrinh_N13, CongTrinhDto>();
            configuration.CreateMap<CongTrinhInput, CongTrinh_N13>();
            configuration.CreateMap<CongTrinh_N13, CongTrinhInput>();
            configuration.CreateMap<CongTrinh_N13, CongTrinhForViewDto>();


            //ke hoach
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungDto>();
            configuration.CreateMap<KeHoachXayDungInput, KeHoachXayDung_N13>();
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungInput>();
            configuration.CreateMap<KeHoachXayDung_N13, KeHoachXayDungForViewDto>();

            //ho so thau
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13Dto>();
            configuration.CreateMap<HoSoThauN13Input, HoSoThau_N13>();
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13Input>();
            configuration.CreateMap<HoSoThau_N13, HoSoThauN13ForViewDto>();


            //don vi thau
            configuration.CreateMap<DonViThau_N13, DonViThauDto>();
            configuration.CreateMap<DonViThauInput, DonViThau_N13>();
            configuration.CreateMap<DonViThau_N13, DonViThauInput>();
            configuration.CreateMap<DonViThau_N13, DonViThauForViewDto>();

            //computer
            configuration.CreateMap<Computer, ComputerDto>();
            configuration.CreateMap<ComputerInput, Computer>();
            configuration.CreateMap<Computer, ComputerInput>();
            configuration.CreateMap<Computer, ComputerForViewDto>();

            //software
            configuration.CreateMap<Software, SoftwareDto>();
            configuration.CreateMap<SoftwareInput, Software>();
            configuration.CreateMap<Software, SoftwareInput>();
            configuration.CreateMap<Software, SoftwareForViewDto>();

            // Asset
            configuration.CreateMap<FixedAsset, FixedAssetDto>();
            configuration.CreateMap<FixedAssetInput, FixedAsset>();
            configuration.CreateMap<FixedAsset, FixedAssetInput>();
            configuration.CreateMap<FixedAsset, FixedAssetForViewDto>();//view

           // AssetGroup
            configuration.CreateMap<AssetGroup_05, AssetGroupDto_05>();//get filter assetGroup
            configuration.CreateMap<AssetGroupDto_05, AssetGroup_05>();//create
            configuration.CreateMap<AssetGroup_05, AssetGroupInput_05>();//get for edit
            configuration.CreateMap<AssetGroup_05, AssetGroupOutput_05>();//get for edit
            configuration.CreateMap<AssetGroup_05, AssetGroupForViewDto_05>();//view

           // Asset_05
            configuration.CreateMap<Asset_05, AssetDto_05>();
            configuration.CreateMap<AssetDto_05, Asset_05>();
            configuration.CreateMap<Asset_05, AssetForViewDto_05>();
            configuration.CreateMap<Asset_05, AssetOutput_05>();//get for edit

            //AssetType_05
            configuration.CreateMap<AssetType_05, AssetTypeDto_05>();
            configuration.CreateMap<AssetType_05, AssetForViewDto_05>();
            configuration.CreateMap<MenuClient, MenuClientDto>();
            configuration.CreateMap<MenuClient, MenuClientListDto>();
            configuration.CreateMap<CreateMenuClientInput, MenuClient>();
            configuration.CreateMap<UpdateMenuClientInput, MenuClient>();

            // DemoModel
            configuration.CreateMap<DemoModel, DemoModelDto>();
            configuration.CreateMap<DemoModelInput, DemoModel>();
            configuration.CreateMap<DemoModel, DemoModelInput>();
            configuration.CreateMap<DemoModel, DemoModelForViewDto>();

            // Customer
            configuration.CreateMap<Customer, CustomerDto>();
            configuration.CreateMap<CustomerInput, Customer>();
            configuration.CreateMap<Customer, CustomerInput>();
            configuration.CreateMap<Customer, CustomerForViewDto>();

            // AssetActivity
            configuration.CreateMap<AssetActivity, AssetActivityDto>();
            configuration.CreateMap<AssetActivityInput, AssetActivity>();
            configuration.CreateMap<AssetActivity, AssetActivityInput>();
            configuration.CreateMap<AssetActivity, AssetActivityForViewDto>();

            configuration.CreateMap<Asset_test9, AssetDto_9>();
            configuration.CreateMap<AssetInput_9, Asset_test9>();
            configuration.CreateMap<Asset_test9, AssetInput_9>();
            configuration.CreateMap<Asset_test9, AssetForViewDto_9>();

            configuration.CreateMap<RealEstate_9, RealEstateDto_9>();
            configuration.CreateMap<RealEstateInput_9, RealEstate_9>();
            configuration.CreateMap<RealEstate_9, RealEstateInput_9>();
            configuration.CreateMap<RealEstate_9, RealEstateForViewDto_9>();

            configuration.CreateMap<RealEstateType_9, RealEstateTypeDto_9>();
            configuration.CreateMap<RealEstateTypeInput_9, RealEstateType_9>();
            configuration.CreateMap<RealEstateType_9, RealEstateTypeInput_9>();
            configuration.CreateMap<RealEstateType_9, RealEstateTypeForViewDto_9>();

            configuration.CreateMap<RealEstateRepair_9, RealEstateRepairDto_9>();
            configuration.CreateMap<RealEstateRepairInput_9, RealEstateRepair_9>();
            configuration.CreateMap<RealEstateRepair_9, RealEstateRepairInput_9>();
            configuration.CreateMap<RealEstateRepair_9, RealEstateRepairForViewDto_9>();

            configuration.CreateMap<BidManager_9, BidManagerDto>();
            configuration.CreateMap<BidManagerInput, BidManager_9>();
            configuration.CreateMap<BidManager_9, BidManagerInput>();
            configuration.CreateMap<BidManager_9, BidManagerForViewDto>();

            configuration.CreateMap<Construction_9, ConstructionDto>();
            configuration.CreateMap<ConstructionInput, Construction_9>();
            configuration.CreateMap<Construction_9, ConstructionInput>();
            configuration.CreateMap<Construction_9, ConstructionForViewDto>();

            configuration.CreateMap<ContractGuarantee, ContractGuaranteeDto>();
            configuration.CreateMap<ContractGuaranteeInput, ContractGuarantee>();
            configuration.CreateMap<ContractGuarantee, ContractGuaranteeInput>();
            configuration.CreateMap<ContractGuarantee, ContractGuaranteeForViewDto>();

            configuration.CreateMap<ContractManagement, ContractManagementDto>();
            configuration.CreateMap<ContractManagementInput, ContractManagement>();
            configuration.CreateMap<ContractManagement, ContractManagementInput>();
            configuration.CreateMap<ContractManagement, ContractManagementForViewDto>();

            configuration.CreateMap<Contractors_9, ContractorDto>();
            configuration.CreateMap<ContractorInput, Contractors_9>();
            configuration.CreateMap<Contractors_9, ContractorInput>();
            configuration.CreateMap<Contractors_9, ContractorForViewDto>();

            configuration.CreateMap<PaymentDetails_9, PaymentDetailDto>();
            configuration.CreateMap<PaymentDetailInput, PaymentDetails_9>();
            configuration.CreateMap<PaymentDetails_9, PaymentDetailInput>();
            configuration.CreateMap<PaymentDetails_9, PaymentDetailForViewDto>();

            configuration.CreateMap<Plan_9, PlanDto>();
            configuration.CreateMap<PlanInput, Plan_9>();
            configuration.CreateMap<Plan_9, PlanInput>();
            configuration.CreateMap<Plan_9, PlanForViewDto>();

            configuration.CreateMap<WarrantyGuarantee, WarrantyGuaranteeDto>();
            configuration.CreateMap<WarrantyGuaranteeInput, WarrantyGuarantee>();
            configuration.CreateMap<WarrantyGuarantee, WarrantyGuaranteeInput>();
            configuration.CreateMap<WarrantyGuarantee, WarrantyGuaranteeForViewDto>();

            //ShoppingPlan
            configuration.CreateMap<ShoppingPlan, ShoppingPlanDto>();
            configuration.CreateMap<ShoppingPlanInput, ShoppingPlan>();
            configuration.CreateMap<ShoppingPlan, ShoppingPlanInput>();
            configuration.CreateMap<ShoppingPlan, ShoppingPlanForViewDto>();

            //ShoppingPlanDetail
            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailDto>();
            configuration.CreateMap<ShoppingPlanDetailInput, ShoppingPlanDetail>();
            configuration.CreateMap<ShoppingPlanDetail, ShoppingPlanDetailInput>();

            //ConstructionPlan
            configuration.CreateMap<ConstructionPlan, ConstructionPlanDto>();
            configuration.CreateMap<ConstructionPlanInput, ConstructionPlan>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanInput>();
            configuration.CreateMap<ConstructionPlan, ConstructionPlanForViewDto>();

            //ConstructionPlanDetail
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailDto>();
            configuration.CreateMap<ConstructionPlanDetailInput, ConstructionPlanDetail>();
            configuration.CreateMap<ConstructionPlanDetail, ConstructionPlanDetailInput>();

            //DisposalPlan
            configuration.CreateMap<DisposalPlan, DisposalPlanDto>();
            configuration.CreateMap<DisposalPlanInput, DisposalPlan>();
            configuration.CreateMap<DisposalPlan, DisposalPlanInput>();
            configuration.CreateMap<DisposalPlan, DisposalPlanForViewDto>();

            //DisposalPlanDetail
            configuration.CreateMap<DisposalPlanDetail, DisposalPlanDetailDto>();
            configuration.CreateMap<DisposalPlanDetailInput, DisposalPlanDetail>();
            configuration.CreateMap<DisposalPlanDetail, DisposalPlanDetailInput>();
            //contractPayment
            configuration.CreateMap<ContractPayment, ContractPaymentDto>();
            configuration.CreateMap<ContractPaymentInput, ContractPayment>();
            configuration.CreateMap<ContractPayment, ContractPaymentInput>();
            configuration.CreateMap<ContractPayment, ContractPaymentForViewDto>();
            configuration.CreateMap<Asset11, Asset11Dto>();
            configuration.CreateMap<Asset11Input, Asset11>();
            configuration.CreateMap<Asset11, Asset11Input>();
            configuration.CreateMap<Asset11, Asset11ForViewDto>();

            configuration.CreateMap<Debit11, Debit11Dto>();
            configuration.CreateMap<Debit11Input, Debit11>();
            configuration.CreateMap<Debit11, Debit11Input>();
            configuration.CreateMap<Debit11, Debit11ForViewDto>();

            configuration.CreateMap<Credit11, Credit11Dto>();
            configuration.CreateMap<Credit11Input, Credit11>();
            configuration.CreateMap<Credit11, Credit11Input>();
            configuration.CreateMap<Credit11, Credit11ForViewDto>();
            //Vehicle
            configuration.CreateMap<Vehicle, VehicleDto>();
            configuration.CreateMap<VehicleInput, Vehicle>();
            configuration.CreateMap<Vehicle, VehicleInput>();
            configuration.CreateMap<Vehicle, VehicleForViewDto>();
            //TypeVehcile
            configuration.CreateMap<TypeVehicle, TypeVehicleDto>();
            configuration.CreateMap<TypeVehicleInput, TypeVehicle>();
            configuration.CreateMap<TypeVehicle, TypeVehicleInput>();
            configuration.CreateMap<TypeVehicle, TypeVehicleForViewDto>();
            //ModelVehicle
            configuration.CreateMap<ModelVehicle, ModelVehicleDto>();
            configuration.CreateMap<ModelVehicleInput, ModelVehicle>();
            configuration.CreateMap<ModelVehicle, ModelVehicleInput>();
            configuration.CreateMap<ModelVehicle, ModelVehicleForViewDto>();
            //Asset
            configuration.CreateMap<Asset_8, Asset_8Dto>();
            configuration.CreateMap<Asset_8Input, Asset_8>();
            configuration.CreateMap<Asset_8, Asset_8Input>();
            configuration.CreateMap<Asset_8, Asset_8ForViewDto>();
            //brand
            configuration.CreateMap<BrandVehicle, BrandVehicleDto>();
            configuration.CreateMap<BrandVehicleInput, BrandVehicle>();
            configuration.CreateMap<BrandVehicle, BrandVehicleInput>();
            configuration.CreateMap<BrandVehicle, BrandVehicleForViewDto>();
            //operate
            configuration.CreateMap<OperateVehicle, OperateVehicleDto>();
            configuration.CreateMap<OperateVehicleInput, OperateVehicle>();
            configuration.CreateMap<OperateVehicle, OperateVehicleInput>();
            configuration.CreateMap<OperateVehicle, OperateVehicleForViewDto>();

            configuration.CreateMap<RoadFeeVehicle, RoadFeeVehicleDto>();
            configuration.CreateMap<RoadFeeVehicleInput, RoadFeeVehicle>();
            configuration.CreateMap<RoadFeeVehicle, RoadFeeVehicleInput>();
            configuration.CreateMap<RoadFeeVehicle, RoadFeeVehicleForViewDto>();


            // Insurrance
            configuration.CreateMap<Insurrance, InsurranceDto>();
            configuration.CreateMap<InsurranceInput, Insurrance>();
            configuration.CreateMap<Insurrance, InsurranceInput>();
            configuration.CreateMap<Insurrance, InsurranceForViewDto>();

            // InsurranceType
            configuration.CreateMap<InsurranceType, InsurranceTypeDto>();
            configuration.CreateMap<InsurranceTypeInput, InsurranceType>();
            configuration.CreateMap<InsurranceType, InsurranceTypeInput>();
            configuration.CreateMap<InsurranceType, InsurranceTypeForViewDto>();
            //NhaCungCapHangHoa
            configuration.CreateMap<NhaCungCapHangHoa, NhaCungCapHangHoaDto>();
            configuration.CreateMap<NhaCungCapHangHoaInput, NhaCungCapHangHoa>();
            configuration.CreateMap<NhaCungCapHangHoa, NhaCungCapHangHoaInput>();
            configuration.CreateMap<NhaCungCapHangHoa, NhaCungCapHangHoaForViewDto>();

            //ProductType

            configuration.CreateMap<ProductType, ProductTypeDto>();
            configuration.CreateMap<ProductTypeInput, ProductType>();
            configuration.CreateMap<ProductType, ProductTypeInput>();
            configuration.CreateMap<ProductType, ProductTypeForViewDto>();

            //Product
            configuration.CreateMap<SanPham, SanPhamDto>();
            configuration.CreateMap<SanPhamInput, SanPham>();
            configuration.CreateMap<SanPham, SanPhamInput>();
            configuration.CreateMap<SanPham, SanPhamForViewDto>();

            // LoaiNhaCungCap
            configuration.CreateMap<LoaiNhaCungCap, LoaiNhaCungCapDto>();
            configuration.CreateMap<LoaiNhaCungCapInput, LoaiNhaCungCap>();
            configuration.CreateMap<LoaiNhaCungCap, LoaiNhaCungCapInput>();
            configuration.CreateMap<LoaiNhaCungCap, LoaiNhaCungCapForViewDto>();

            configuration.CreateMap<TransferringAssetDataInput, TransferringAsset>();
            configuration.CreateMap<TransferringAsset, TransferringAssetDataInput>();

            configuration.CreateMap<Warranty_05, WarrantyDto>();

            // ExportingUsedAsset
            configuration.CreateMap<ExportingUsedAsset, ExportingUsedAssetDto>();
            configuration.CreateMap<ExportingUsedAssetInput, ExportingUsedAsset>();
            configuration.CreateMap<ExportingUsedAsset, ExportingUsedAssetInput>();
            configuration.CreateMap<ExportingUsedAsset, ExportingUsedAssetForViewDto>();

        }
    }
}