import { ConstructionPlanDetailServiceProxy, DisposalPlanServiceProxy, DisposalPlanDetailServiceProxy} from './../../shared/service-proxies/service-proxies';
import { LoaiNhaCungCapServiceProxy, NhaCungCapHangHoaServiceProxy, SanPhamServiceProxy, ProductTypeServiceProxy } from './../../shared/service-proxies/service-proxies';
import { RealEstateServiceProxy, AssetController_9ServiceProxy, RealEstateTypeServiceProxy, RealEstateRepairServiceProxy, PlanServiceProxy, ConstructionServiceProxy, BidManagerServiceProxy, ContractorServiceProxy } from './../../shared/service-proxies/service-proxies';
import {
    AssetDashboardServiceProxy,
    AssetGroupController_05ServiceProxy, AssetController_05ServiceProxy, TransferringAssetServiceProxy, ExportingUsedAssetServiceProxy
} from './../../shared/service-proxies/service-proxies';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { GWebsiteRoutingModule } from './gwebsite-routing.module';

import {
    CategoryComponent, ViewCategoryModalComponent, CreateOrEditCategoryModalComponent,
    CategoryTypeComponent, CreateOrEditTypeModalComponent, ViewCategoryTypeModalComponent,
    DirectorShoppingPlanComponent, ViewDirectorShoppingPlanModalComponent, CreateOrEditDirectorShoppingPlanModalComponent,
    CreateOrEditPlanModalComponent, PlanComponent, PlanModalComponent, SelectionConstructionInPlanModalComponent,
    ConstructionComponent, CreateOrEditConstructionModalComponent, ConstructionModalComponent, ViewConstructionModalComponent,
    SelectionConstructionModalComponent, ViewBidManagerModalComponent, CreateOrEditBidManagerModalComponent, BidManagerComponent
} from './index';

import { CategoryServiceProxy, CategoryTypeServiceProxy,
    ShoppingPlanServiceProxy, DirectorShoppingPlanServiceProxy, ShoppingPlanDetailServiceProxy, ConstructionPlanServiceProxy,
    LoaiBatDongSanServiceProxy, NhomTaiSanServiceProxy, LoaiSoHuuServiceProxy, MucDichSuDungDatServiceProxy, BatDongSanServiceProxy,
    HienTrangPhapLyServiceProxy, TinhTrangSuDungDatServiceProxy, TaiSanServiceProxy, SuaChuaBatDongSanServiceProxy, KeHoachXayDungServiceProxy, CongTrinhServiceProxy, HoSoThauN13ServiceProxy,
    ComputerServiceProxy, SoftwareServiceProxy, FixedAssetServiceProxy, 
    AssetServiceProxy
} from '@shared/service-proxies/service-proxies';

import { LoaiBatDongSanComponent } from './loaibatdongsan/loaibatdongsan.component';
import { CreateOrEditLoaiBatDongSanModalComponent } from './loaibatdongsan/create-or-edit-loaibatdongsan-modal.component';
import { ViewLoaiBatDongSanModalComponent } from './loaibatdongsan/view-loaibatdongsan-modal.component';
import { LoaiSoHuuComponent } from './loaisohuu/loaisohuu.component';
import { CreateOrEditLoaiSoHuuModalComponent } from './loaisohuu/create-or-edit-loaisohuu-modal.component';
import { ViewLoaiSoHuuModalComponent } from './loaisohuu/view-loaisohuu-modal.component';
import { BatDongSanComponent } from './batdongsan/batdongsan.component';
import { CreateOrEditBatDongSanModalComponent } from './batdongsan/create-or-edit-batdongsan-modal.component';
import { ViewBatDongSanModalComponent } from './batdongsan/view-batdongsan-modal.component';
import { HienTrangPhapLyComponent } from './hientrangphaply/hientrangphaply.component';
import { ViewHienTrangPhapLyModalComponent } from './hientrangphaply/view-hientrangphaply-modal.component';
import { TinhTrangSuDungDatComponent } from './tinhtrangsudungdat/tinhtrangsudungdat.component';
import { CreateOrEditTinhTrangSuDungDatModalComponent } from './tinhtrangsudungdat/create-or-edit-tinhtrangsudungdat-modal.component';
import { ViewTinhTrangSuDungDatModalComponent } from './tinhtrangsudungdat/view-tinhtrangsudungdat-modal.component';
import { TaiSanComponent } from './taisan/taisan.component';
import { ViewTaiSanModalComponent } from './taisan/view-taisan-modal.component';
import { CreateOrEditTaiSanModalComponent } from './taisan/create-or-edit-taisan-modal.component';
import { SelectTaiSanModalComponent } from './taisan/select-taisan-modal.component';
import { SuaChuaBatDongSanComponent } from './suachuabatdongsan/suachuabatdongsan.component';
import { CreateOrEditSuaChuaBatDongSanModalComponent } from './suachuabatdongsan/createSuachuabatdongsan-modal.component';
import { ViewSuaChuaBatDongSanModalComponent } from './suachuabatdongsan/view-suachuabatdongsan-modal.component';
import { KeHoachXayDungComponent } from './kehoachxaydung/kehoachxaydung.component';
import { CreateOrEditKeHoachXayDungModalComponent } from './kehoachxaydung/create-or-edit-kehoachxaydung-modal.component';
import { ViewKeHoachXayDungModalComponent } from './kehoachxaydung/view-kehoachxaydung-modal.component';
import { EditSuaChuaBatDongSanModalComponent } from './suachuabatdongsan/edit-suachuabatdongsan-modal.component';
import { DuyetBatDongSanModalComponent } from './suachuabatdongsan/duyet-suachuabatdongsan-modal.component';
import { CongTrinhComponent } from './congtrinhN13/congtrinh.component';
import { CreateOrEditCongTrinhModalComponent } from './congtrinhN13/create-or-edit-congtrinh-modal.component';
import { ViewCongTrinhModalComponent } from './congtrinhN13/view-congtrinh-modal.component';
import { SelectKeHoachXayDungModalComponent } from './kehoachxaydung/select-kehoachxaydung-modal.component';
import { SelectCongTrinhModalComponent } from './congtrinhN13/select-congtrinh-modal.component';
import { SelectKHCongTrinhModalComponent } from './kehoachxaydung/select-khcongtrinh-modal.component';
import { CreateCongTrinhModalComponent } from './congtrinhN13/create-congtrinh-modal.component';
import { HoSoThauN13Component } from './hosothauN13/hosothaun13.component';
import { CreateHoSoThauN13ModalComponent } from './hosothauN13/create-hosothau13-modal.component';

import { ComputerComponent } from './computer/computer.component';
import { CreateOrEditComputerModalComponent } from './computer/create-or-edit-computer-modal.component';
import { ViewComputerModalComponent } from './computer/view-computer-modal.component';
import { SoftwareComponent } from './software/software.component';
import { CreateOrEditSoftwareModalComponent } from './software/create-or-edit-software-modal.component';
import { ViewSoftwareModalComponent } from './software/view-software-modal.component';
import { FixedAssetComponent } from './fixed-asset/fixed-asset.component'
import { CreateOrEditFixedAssetModalComponent } from './fixed-asset/create-or-edit-fixed-asset-modal.component';
import { ViewFixedAssetModalComponent } from './fixed-asset/view-fixed-asset-modal.component';
import { AssetDashboardComponent } from './asset-dashboard/asset-dashboard.component';
import { AssetGroupComponent } from './asset-group/asset-group.component';
import { ViewAssetGroupModalComponent } from './asset-group/view-asset-group-modal.component';
import { CreateOrEditAssetGroupModalComponent } from './asset-group/create-or-edit-asset-group-modal.component';
import { CreateOrEditAssetModalComponent } from './asset/create-or-edit-asset-modal.component';
import { AssetComponent } from './asset/asset.component';
import { ViewAssetModalComponent } from './asset/view-asset-modal.component';

import { CreateOrEditRealEstateModalComponent } from './real-estate-management/create-or-edit-real-estate-management-modal.component';
import { RealEstateManagementComponent } from './real-estate-management/real-estate-management.component';
import { RealEstateTypeComponent } from './real-estate-type/real-estate-type.component';
import { CreateOrEditRealEstateTypeModalComponent } from './real-estate-type/create-or-edit-real-estate-type';
import { ViewRealEstateModalComponent } from './real-estate-management/view-real-estate-management-modal.component';
import { AssetComponent9 } from './real-estate-management/asset-component';
import { ViewRealEstateRepairModalComponent } from './real-estate-repair/view-real-estate-repair-modal.component';
import { CreateOrEditRealEstateRepairModalComponent } from './real-estate-repair/create-or-edit-real-estate-repair-modal.component';
import { RealEstateRepairComponent } from './real-estate-repair/real-estate-repair.component';
import { RealEstateModalComponent } from './real-estate-repair/real-estate-modal';
import { ApprovedRealEstateRepairModalComponent } from './real-estate-repair/approved-real-estate-repair';
import { UpdateRealEstateRepairModalComponent } from './real-estate-repair/update-real-estate-repair-modal.component';

import {
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
} from '@angular/material';

import { AssetActivityServiceProxy, Asset11ServiceProxy, Debit11ServiceProxy, Credit11ServiceProxy } from '@shared/service-proxies/service-proxies';
import { PurchasedAssetsComponent } from './asset-investment-efficiency/pages/purchased-assets/purchased-assets.component';
import { SoleAssetsComponent } from './asset-investment-efficiency/pages/sole-assets/sole-assets.component';
import { MaintainedAssetsComponent } from './asset-investment-efficiency/pages/maintained-assets/maintained-assets.component';
import { PlannedToSellAssetsComponent } from './asset-investment-efficiency/pages/planned-to-sell-assets/planned-to-sell-assets.component';
import { PlannedToPurchaseAssetsComponent } from './asset-investment-efficiency/pages/planned-to-purchase-assets/planned-to-purchase-assets.component';
import { PlannedToMaintainAssetsComponent } from './asset-investment-efficiency/pages/planned-to-maintain-assets/planned-to-maintain-assets.component';
import { OperatingAssetsComponent } from './asset-investment-efficiency/pages/operating-assets/operating-assets.component';
import { ChartsModule } from 'ng2-charts';
import { Asset11Component } from './asset11/asset11.component';
import { CreateOrEditAsset11ModalComponent } from './asset11/create-or-edit-asset11-modal.component';
import { ViewAsset11ModalComponent } from './asset11/view-asset11-modal.component';
import { Debit11Component } from './debit11/debit11.component';
import { Credit11Component } from './credit11/credit11.component';

import { ShoppingPlanComponent } from './shoppingPlan/shoppingPlan.component';
import { ViewShoppingPlanModalComponent } from './shoppingPlan/view-shoppingPlan-modal.component';
import { CreateOrEditShoppingPlanModalComponent } from './shoppingPlan/create-or-edit-shoppingPlan-modal.component';

import { ShoppingPlanDetailComponent } from './shoppingPlan/shoppingPlanDetail.component';
import { CreateOrEditShoppingPlanDetailModalComponent } from './shoppingPlan/create-or-edit-shoppingPlanDetail-modal.component';

import { ConstructionPlanComponent } from './constructionPlan/constructionPlan.component';
import { ViewConstructionPlanModalComponent } from './constructionPlan/view-constructionPlan-modal.component';
import { CreateOrEditConstructionPlanModalComponent } from './constructionPlan/create-or-edit-constructionPlan-modal.component';

import { DisposalPlanComponent } from './disposalPlan/disposalPlan.component';
import { ViewDisposalPlanModalComponent } from './disposalPlan/view-disposalPlan-modal.component';
import { CreateOrEditDisposalPlanModalComponent } from './disposalPlan/create-or-edit-disposalPlan-modal.component';

import { DisposalPlanDetailComponent } from './disposalPlan/disposalPlanDetail.component';
import { CreateOrEditDisposalPlanDetailModalComponent } from './disposalPlan/create-or-edit-disposalPlanDetail-modal.component';

import { ConstructionPlanDetailComponent } from './constructionPlan/constructionPlanDetail.component';
import { CreateOrEditConstructionPlanDetailModalComponent } from './constructionPlan/create-or-edit-constructionPlanDetail-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { BidServiceProxy } from '@shared/service-proxies/service-proxies';
import { SupplierServiceProxy } from '@shared/service-proxies/service-proxies';
import { ContractServiceProxy } from '@shared/service-proxies/service-proxies';
import { GoodsInvoiceServiceProxy } from '@shared/service-proxies/service-proxies';
import { GoodsServiceProxy } from '@shared/service-proxies/service-proxies';
import { ContractPaymentServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { DuAnComponent } from './duan/duan.component';
import { ViewDuAnModalComponent } from './duan/view-duan-modal.component';
import { CreateOrEditDuAnModalComponent } from './duan/create-or-edit-duan-modal.component';
import { HoSoThauComponent } from './hosothau/hosothau.component';
import { ViewHoSoThauModalComponent } from './hosothau/view-hosothau-modal.component';
import { CreateOrEditHoSoThauModalComponent } from './hosothau/create-or-edit-hosothau-modal.component';
import { NhaCungCapComponent } from './nhacungcap/nhacungcap.component';
import { ViewNhaCungCapModalComponent } from './nhacungcap/view-nhacungcap-modal.component';
import { CreateOrEditNhaCungCapModalComponent } from './nhacungcap/create-or-edit-nhacungcap-modal.component';
import { HopDongThauComponent } from './hopdongthau/hopdongthau.component';
import { ViewHopDongThauModalComponent } from './hopdongthau/view-hopdongthau-modal.component';
import { CreateOrEditHopDongThauModalComponent } from './hopdongthau/create-or-edit-hopdongthau-modal.component';
import { PhieuGoiHangComponent } from './phieugoihang/phieugoihang.component';
import { ViewPhieuGoiHangModalComponent } from './phieugoihang/view-phieugoihang-modal.component';
import { CreateOrEditPhieuGoiHangModalComponent } from './phieugoihang/create-or-edit-phieugoihang-modal.component';
import { HangHoaComponent } from './hanghoa/hanghoa.component';
import { ViewHangHoaModalComponent } from './hanghoa/view-hanghoa-modal.component';
import { CreateOrEditHangHoaModalComponent } from './hanghoa/create-or-edit-hanghoa-modal.component';

// cubill
import {
    InsurranceServiceProxy,
    InsurranceTypeServiceProxy
} from './../../shared/service-proxies/service-proxies';
import { VehicleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { TypeVehicleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { BrandVehicleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ModelVehicleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { OperateVehicleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { RoadFeeVehicleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { Asset_8ServiceProxy } from './../../shared/service-proxies/service-proxies';

import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';

import { VehicleComponent } from './vehicle/vehicle.component';
import { ViewVehicleModalComponent } from './vehicle/view-vehicle-modal.componenent';
import { CreateOrEditVehicleModalComponent } from './vehicle/create-or-edit-vehicle-modal.components';

import { ModelVehicleComponent } from './modelvehicle/modelvehicle.component';
import { ViewModelVehicleModalComponent } from './modelvehicle/view-modelvehicle-modal.component';
import { CreateOrEditModelVehicleModalComponent } from './modelvehicle/create-or-edit-modelvehicle-modal.component';

import { TypeVehicleComponent } from './typevehicle/typevehicle.component';
import { ViewTypeVehicleModalComponent } from './typevehicle/view-typevehicle-modal.componenent';
import { CreateOrEditTypeVehicleModalComponent } from './typevehicle/create-or-edit-typevehicle-modal.components';

import { Asset_8Component } from './asset_8/asset_8.component';
import { ViewAsset_8ModalComponent } from './asset_8/view-asset_8-modal.component';
import { CreateOrEditAsset_8ModalComponent } from './asset_8/create-or-edit-asset_8-modal.component';
import { SelectAsset_8ModalComponent } from './asset_8/select-asset_8-modal.component';

import { BrandVehicleComponent } from './brandvehicle/brandvehicle.component';
import { ViewBrandVehicleModalComponent } from './brandvehicle/view-brandvehicle-modal.component';
import { CreateOrEditBrandVehicleModalComponent } from './brandvehicle/create-or-edit-brandvehicle-modal.component';

import { OperateVehicleComponent } from './operatevehicle/operatevehicle.component';
import { ViewOperateVehicleModalComponent } from './operatevehicle/view-operatevehicle-modal.component';
import { CreateOrEditOperateVehicleModalComponent } from './operatevehicle/create-or-edit-operatevehicle-modal.component';
import { RoadFeeVehicleComponent } from './roadfeevehicle/roadfeevehicle.component';
import { ViewRoadFeeVehicleModalComponent } from './roadfeevehicle/view-roadfeevehicle-modal.component';
import { CreateOrEditRoadFeeVehicleModalComponent } from './roadfeevehicle/create-or-edit-roadfeevehicle-modal.component';
import { SelectVehicleModalComponent } from './vehicle/select-vehicle-modal.component';
import { InsurranceComponent } from './insurrance/insurrance.component';
import { ViewInsurranceModalComponent } from './insurrance/view-insurrance-modal.component';
import { CreateOrEditInsurranceModalComponent } from './insurrance/create-or-edit-insurrance-modal.component';
import { InsurranceTypeComponent } from './insurrancetype/insurrancetype.component';
import { ViewInsurranceTypeModalComponent } from './insurrancetype/view-insurrancetype-modal.component';
import { CreateOrEditInsurranceTypeModalComponent } from './insurrancetype/create-or-edit-insurrancetype-modal.component';
import { LoaiNhaCungCapComponent } from './LoaiNhaCungCap/LoaiNhaCungCap.component';
import { ViewLoaiNhaCungCapModalComponent } from './LoaiNhaCungCap/view-LoaiNhaCungCap-modal.component';
import { CreateOrEditLoaiNhaCungCapModalComponent } from './LoaiNhaCungCap/create-or-edit-LoaiNhaCungCap-modal.component';
import { NhaCungCapHangHoaComponent } from './NhaCungCapHangHoa/NhaCungCapHangHoa.component';
import { CreateOrEditNhaCungCapHangHoaModalComponent } from './NhaCungCapHangHoa/create-or-edit-NhaCungCapHangHoa-modal.component';
import { ViewNhaCungCapHangHoaModalComponent } from './NhaCungCapHangHoa/view-NhaCungCapHangHoa-modal.component';
import { ProductComponent } from './Product/Product.component';
import { CreateOrEditProductModalComponent } from './Product/create-or-edit-Product-modal.component';
import { ViewProductModalComponent } from './Product/view-Product-modal.component';
import { ProductTypeComponent } from './ProductType/ProductType.component';
import { ViewProductTypeModalComponent } from './ProductType/view-ProductType-modal.component';
import { CreateOrEditProductTypeModalComponent } from './ProductType/create-or-edit-ProductType-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import {NgxPaginationModule} from 'ngx-pagination';
import { ExcelService } from './services/excel.service';
import { CreateOrEditContractorModalComponent } from './bid-manager/create-or-edit-contractor-modal.component';
import { TransferringAssetComponent } from './transferring-asset/transferring-asset.component';
import { ViewTransferringAssetModalComponent } from './transferring-asset/view-transferring-asset-modal.component';
import { CreateOrEditTransferringAssetModalComponent } from './transferring-asset/create-or-edit-transferring-asset-modal.component';
import { SearchAssetComponent } from './transferring-asset/search-asset.component';
import { SearchUnitComponent } from './transferring-asset/search-unit.component';
import { SearchUserComponent } from './transferring-asset/search-user.component';
import { ExportingUsedAssetComponent } from './exporting-used-asset/exporting-used-asset.component';
import { SearchAssetComponent2 } from './exporting-used-asset/search-asset.component';
import { CreateOrEditExportingUsedAssetModalComponent } from './exporting-used-asset/create-or-edit-exporting-used-asset-modal.component';
import { ViewExportingUsedAssetModalComponent } from './exporting-used-asset/view-exporting-used-asset-modal.component';


@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule,
        MatAutocompleteModule,
        MatBadgeModule,
        MatBottomSheetModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatCheckboxModule,
        MatChipsModule,
        MatDatepickerModule,
        MatDialogModule,
        MatDividerModule,
        MatExpansionModule,
        MatGridListModule,
        MatIconModule,
        MatInputModule,
        MatListModule,
        MatMenuModule,
        MatNativeDateModule,
        MatPaginatorModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatRadioModule,
        MatRippleModule,
        MatSelectModule,
        MatSidenavModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        MatSortModule,
        MatStepperModule,
        MatTableModule,
        MatTabsModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTreeModule,
        ChartsModule,
        NgxPaginationModule
    ],
    declarations: [
        DuAnComponent, CreateOrEditDuAnModalComponent, ViewDuAnModalComponent,
        HoSoThauComponent, CreateOrEditHoSoThauModalComponent, ViewHoSoThauModalComponent,
        NhaCungCapComponent, CreateOrEditNhaCungCapModalComponent, ViewNhaCungCapModalComponent,
        HopDongThauComponent, CreateOrEditHopDongThauModalComponent, ViewHopDongThauModalComponent,
        PhieuGoiHangComponent, CreateOrEditPhieuGoiHangModalComponent, ViewPhieuGoiHangModalComponent,
        HangHoaComponent, CreateOrEditHangHoaModalComponent, ViewHangHoaModalComponent,
        CategoryComponent, ViewCategoryModalComponent, CreateOrEditCategoryModalComponent,
        CategoryTypeComponent, ViewCategoryTypeModalComponent, CreateOrEditTypeModalComponent,
        ShoppingPlanComponent, ViewShoppingPlanModalComponent, CreateOrEditShoppingPlanModalComponent,
        DirectorShoppingPlanComponent, ViewDirectorShoppingPlanModalComponent, CreateOrEditDirectorShoppingPlanModalComponent,
        ShoppingPlanDetailComponent, CreateOrEditShoppingPlanDetailModalComponent,
        ConstructionPlanComponent, ViewConstructionPlanModalComponent, CreateOrEditConstructionPlanModalComponent,
        LoaiBatDongSanComponent, CreateOrEditLoaiBatDongSanModalComponent, ViewLoaiBatDongSanModalComponent,
        LoaiSoHuuComponent, CreateOrEditLoaiSoHuuModalComponent, ViewLoaiSoHuuModalComponent,
        BatDongSanComponent, CreateOrEditBatDongSanModalComponent, ViewBatDongSanModalComponent,
        HienTrangPhapLyComponent, ViewHienTrangPhapLyModalComponent,
        TinhTrangSuDungDatComponent, CreateOrEditTinhTrangSuDungDatModalComponent, ViewTinhTrangSuDungDatModalComponent,
        TaiSanComponent, CreateOrEditTaiSanModalComponent, ViewTaiSanModalComponent, SelectTaiSanModalComponent,
        SuaChuaBatDongSanComponent, CreateOrEditSuaChuaBatDongSanModalComponent, ViewSuaChuaBatDongSanModalComponent, EditSuaChuaBatDongSanModalComponent, DuyetBatDongSanModalComponent,
        KeHoachXayDungComponent, CreateOrEditKeHoachXayDungModalComponent, ViewKeHoachXayDungModalComponent, SelectKHCongTrinhModalComponent,
        CongTrinhComponent, CreateOrEditCongTrinhModalComponent, ViewCongTrinhModalComponent, SelectKeHoachXayDungModalComponent,
        CreateCongTrinhModalComponent, HoSoThauN13Component, CreateHoSoThauN13ModalComponent,
        ComputerComponent, CreateOrEditComputerModalComponent, ViewComputerModalComponent,
        SoftwareComponent, CreateOrEditSoftwareModalComponent, ViewSoftwareModalComponent,
        FixedAssetComponent, CreateOrEditFixedAssetModalComponent, ViewFixedAssetModalComponent,
        AssetDashboardComponent,
        AssetGroupComponent, CreateOrEditAssetGroupModalComponent, ViewAssetGroupModalComponent,
        AssetComponent, CreateOrEditAssetModalComponent, ViewAssetModalComponent,
        PurchasedAssetsComponent, SoleAssetsComponent, MaintainedAssetsComponent, PlannedToSellAssetsComponent, OperatingAssetsComponent,
        PlannedToPurchaseAssetsComponent, PlannedToMaintainAssetsComponent,
        RealEstateManagementComponent, CreateOrEditRealEstateModalComponent, ViewRealEstateModalComponent, AssetComponent9,
        RealEstateTypeComponent, CreateOrEditRealEstateTypeModalComponent,
        RealEstateRepairComponent, CreateOrEditRealEstateRepairModalComponent, ViewRealEstateRepairModalComponent,
        RealEstateModalComponent, ApprovedRealEstateRepairModalComponent, UpdateRealEstateRepairModalComponent,
        ShoppingPlanComponent, ViewShoppingPlanModalComponent, CreateOrEditShoppingPlanModalComponent,
        ShoppingPlanDetailComponent, CreateOrEditShoppingPlanDetailModalComponent,
        ConstructionPlanComponent, ViewConstructionPlanModalComponent, CreateOrEditConstructionPlanModalComponent,
        DisposalPlanComponent, ViewDisposalPlanModalComponent, CreateOrEditDisposalPlanModalComponent,
        DisposalPlanDetailComponent, CreateOrEditDisposalPlanDetailModalComponent,
        ConstructionPlanDetailComponent, CreateOrEditConstructionPlanDetailModalComponent,
        Asset11Component,
        CreateOrEditAsset11ModalComponent,
        ViewAsset11ModalComponent,
        Debit11Component,
        Credit11Component,
        CustomerComponent,
        CreateOrEditCustomerModalComponent,
        ViewCustomerModalComponent,
        VehicleComponent,
        CreateOrEditVehicleModalComponent,
        ViewVehicleModalComponent,
        TypeVehicleComponent,
        CreateOrEditTypeVehicleModalComponent,
        ViewTypeVehicleModalComponent,
        Asset_8Component,
        CreateOrEditAsset_8ModalComponent,
        ViewAsset_8ModalComponent,
        SelectAsset_8ModalComponent,
        BrandVehicleComponent,
        CreateOrEditBrandVehicleModalComponent,
        ViewBrandVehicleModalComponent,
        ModelVehicleComponent,
        CreateOrEditModelVehicleModalComponent,
        ViewModelVehicleModalComponent,
        OperateVehicleComponent,
        CreateOrEditOperateVehicleModalComponent,
        ViewOperateVehicleModalComponent,
        RoadFeeVehicleComponent,
        CreateOrEditRoadFeeVehicleModalComponent,
        ViewRoadFeeVehicleModalComponent,
        SelectVehicleModalComponent,
        InsurranceComponent,
        CreateOrEditInsurranceModalComponent,
        ViewInsurranceModalComponent,
        InsurranceTypeComponent,
        CreateOrEditInsurranceTypeModalComponent,
        ViewInsurranceTypeModalComponent,
        LoaiNhaCungCapComponent, CreateOrEditLoaiNhaCungCapModalComponent, ViewLoaiNhaCungCapModalComponent,
        ProductComponent,CreateOrEditProductModalComponent,ViewProductModalComponent,
        ProductTypeComponent,CreateOrEditProductTypeModalComponent,ViewProductTypeModalComponent,
        NhaCungCapHangHoaComponent, CreateOrEditNhaCungCapHangHoaModalComponent, ViewNhaCungCapHangHoaModalComponent,
        CreateOrEditPlanModalComponent, PlanComponent, PlanModalComponent, SelectionConstructionInPlanModalComponent,
        ConstructionComponent, CreateOrEditConstructionModalComponent, ConstructionModalComponent, ViewConstructionModalComponent,
        SelectionConstructionModalComponent, ViewBidManagerModalComponent, CreateOrEditBidManagerModalComponent, BidManagerComponent, CreateOrEditContractorModalComponent,
    
        AssetComponent, CreateOrEditAssetModalComponent, ViewAssetModalComponent, TransferringAssetComponent, CreateOrEditTransferringAssetModalComponent, ViewTransferringAssetModalComponent,
        SearchAssetComponent, SearchUnitComponent, SearchUserComponent,
        SearchAssetComponent2, ExportingUsedAssetComponent, CreateOrEditExportingUsedAssetModalComponent,
        ViewExportingUsedAssetModalComponent,

    ],
    providers: [
        CategoryServiceProxy,
        CategoryTypeServiceProxy,
        ProjectServiceProxy,
        BidServiceProxy,
        SupplierServiceProxy,
        ContractServiceProxy,
        GoodsInvoiceServiceProxy,
        GoodsServiceProxy,
        ShoppingPlanServiceProxy,
        DirectorShoppingPlanServiceProxy,
        ShoppingPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        LoaiBatDongSanServiceProxy,
        LoaiSoHuuServiceProxy,
        MucDichSuDungDatServiceProxy,
        BatDongSanServiceProxy,
        HienTrangPhapLyServiceProxy,
        TinhTrangSuDungDatServiceProxy,
        TaiSanServiceProxy,
        SuaChuaBatDongSanServiceProxy,
        KeHoachXayDungServiceProxy,
        CongTrinhServiceProxy,
        HoSoThauN13ServiceProxy,
        ComputerServiceProxy,
        SoftwareServiceProxy,
        FixedAssetServiceProxy,
        AssetDashboardServiceProxy,
        AssetGroupController_05ServiceProxy,
        AssetController_05ServiceProxy,
        AssetActivityServiceProxy,
        RealEstateServiceProxy,
        AssetServiceProxy,
        RealEstateTypeServiceProxy,
        RealEstateRepairServiceProxy,
        ShoppingPlanServiceProxy,
        ShoppingPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        ConstructionPlanDetailServiceProxy,
        ConstructionPlanServiceProxy,
        DisposalPlanServiceProxy,
        DisposalPlanDetailServiceProxy,
        ContractPaymentServiceProxy,
        Asset11ServiceProxy,
        Debit11ServiceProxy,
        Credit11ServiceProxy,
        DemoModelServiceProxy,
        VehicleServiceProxy,
        TypeVehicleServiceProxy,
        Asset_8ServiceProxy,
        BrandVehicleServiceProxy,
        ModelVehicleServiceProxy,
        OperateVehicleServiceProxy,
        RoadFeeVehicleServiceProxy,
        InsurranceServiceProxy,
        InsurranceTypeServiceProxy,
        LoaiNhaCungCapServiceProxy,
        NhaCungCapHangHoaServiceProxy,
        SanPhamServiceProxy,
        ProductTypeServiceProxy,
        ExcelService,
        WebApiServiceProxy,
        RealEstateServiceProxy,
        AssetController_9ServiceProxy,
        RealEstateTypeServiceProxy,
        RealEstateRepairServiceProxy,
        PlanServiceProxy,
        ConstructionServiceProxy,
        BidManagerServiceProxy,
        ContractorServiceProxy,
        AssetDashboardServiceProxy,
        AssetGroupController_05ServiceProxy,
        AssetController_05ServiceProxy,
        TransferringAssetServiceProxy,
        ExportingUsedAssetServiceProxy
    ]
})
export class GWebsiteModule {}
