import { Asset11Component } from './asset11/asset11.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CategoryComponent } from './category/category-general.component';
import { CategoryTypeComponent } from './category-type/category-type-general.component';
import { DuAnComponent } from './duan/duan.component';
import { HoSoThauComponent } from './hosothau/hosothau.component';
import { CreateOrEditHoSoThauModalComponent } from './hosothau/create-or-edit-hosothau-modal.component';
import { ViewHoSoThauModalComponent } from './hosothau/view-hosothau-modal.component';
import { NhaCungCapComponent } from './nhacungcap/nhacungcap.component';
import { HopDongThauComponent } from './hopdongthau/hopdongthau.component';
import { CreateOrEditHopDongThauModalComponent } from './hopdongthau/create-or-edit-hopdongthau-modal.component';
import { ViewHopDongThauModalComponent } from './hopdongthau/view-hopdongthau-modal.component';
import { PhieuGoiHangComponent } from './phieugoihang/phieugoihang.component';
import { CreateOrEditPhieuGoiHangModalComponent } from './phieugoihang/create-or-edit-phieugoihang-modal.component';
import { ViewPhieuGoiHangModalComponent } from './phieugoihang/view-phieugoihang-modal.component';
import { HangHoaComponent } from './hanghoa/hanghoa.component';
import { DirectorShoppingPlanComponent } from './directorShoppingPlan/directorShoppingPlan.component';
import { LoaiBatDongSanComponent } from './loaibatdongsan/loaibatdongsan.component';
import { LoaiSoHuuComponent } from './loaisohuu/loaisohuu.component';
import { HienTrangPhapLyComponent } from './hientrangphaply/hientrangphaply.component';
import { BatDongSanComponent } from './batdongsan/batdongsan.component';
import { TinhTrangSuDungDatComponent } from './tinhtrangsudungdat/tinhtrangsudungdat.component';
import { TaiSanComponent } from './taisan/taisan.component';
import { SuaChuaBatDongSanComponent } from './suachuabatdongsan/suachuabatdongsan.component';
import { KeHoachXayDungComponent } from './kehoachxaydung/kehoachxaydung.component';
import { CongTrinhComponent } from './congtrinhN13/congtrinh.component';
import { HoSoThauN13Component } from './hosothauN13/hosothaun13.component';
import { ComputerComponent } from './computer/computer.component';
import { SoftwareComponent } from './software/software.component';
import { FixedAssetComponent } from './fixed-asset/fixed-asset.component';
import { AssetDashboardComponent } from './asset-dashboard/asset-dashboard.component';
import { PurchasedAssetsComponent } from './asset-investment-efficiency/pages/purchased-assets/purchased-assets.component';
import { SoleAssetsComponent } from './asset-investment-efficiency/pages/sole-assets/sole-assets.component';
import { MaintainedAssetsComponent } from './asset-investment-efficiency/pages/maintained-assets/maintained-assets.component';
import { PlannedToSellAssetsComponent } from './asset-investment-efficiency/pages/planned-to-sell-assets/planned-to-sell-assets.component';
import { OperatingAssetsComponent } from './asset-investment-efficiency/pages/operating-assets/operating-assets.component';
import { PlannedToPurchaseAssetsComponent } from './asset-investment-efficiency/pages/planned-to-purchase-assets/planned-to-purchase-assets.component';
import { PlannedToMaintainAssetsComponent } from './asset-investment-efficiency/pages/planned-to-maintain-assets/planned-to-maintain-assets.component';
import { RealEstateManagementComponent } from './real-estate-management/real-estate-management.component';
import { RealEstateTypeComponent } from './real-estate-type/real-estate-type.component';
import { RealEstateRepairComponent } from './real-estate-repair/real-estate-repair.component';
import { ShoppingPlanComponent } from './shoppingPlan/shoppingPlan.component';
import { ShoppingPlanDetailComponent } from './shoppingPlan/shoppingPlanDetail.component';
import { ConstructionPlanComponent } from './constructionPlan/constructionPlan.component';
import { DisposalPlanComponent } from './disposalPlan/disposalPlan.component';
import { DisposalPlanDetailComponent } from './disposalPlan/disposalPlanDetail.component';
import { ConstructionPlanDetailComponent } from './constructionPlan/constructionPlanDetail.component';
import { Debit11Component } from './debit11/debit11.component';
import { Credit11Component } from './credit11/credit11.component';
import { CustomerComponent } from "./customer/customer.component";
import { TypeVehicleComponent } from "./typevehicle/typevehicle.component";
import { VehicleComponent } from "./vehicle/vehicle.component";
import { Asset_8Component } from "./asset_8/asset_8.component";
import { BrandVehicleComponent } from "./brandvehicle/brandvehicle.component";
import { ModelVehicleComponent } from "./modelvehicle/modelvehicle.component";
import { OperateVehicleComponent } from "./operatevehicle/operatevehicle.component";
import { RoadFeeVehicleComponent } from "./roadfeevehicle/roadfeevehicle.component";
import { InsurranceTypeComponent } from './insurrancetype/insurrancetype.component';
import { InsurranceComponent } from './insurrance/insurrance.component';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { LoaiNhaCungCapComponent } from './LoaiNhaCungCap/LoaiNhaCungCap.component';
import { NhaCungCapHangHoaComponent } from './NhaCungCapHangHoa/NhaCungCapHangHoa.component';
import { ProductComponent } from './Product/Product.component';
import { ProductTypeComponent } from './ProductType/ProductType.component';
import { PlanComponent, ConstructionComponent, BidManagerComponent } from '.';
import { AssetGroupComponent } from "./asset-group/asset-group.component";
import { AssetComponent } from "./asset/asset.component";
import { CreateOrEditAssetModalComponent } from "./asset/create-or-edit-asset-modal.component"
import { CreateOrEditAssetGroupModalComponent } from "./asset-group/create-or-edit-asset-group-modal.component"
import { TransferringAssetComponent } from './transferring-asset/transferring-asset.component';
import { CreateOrEditTransferringAssetModalComponent } from './transferring-asset/create-or-edit-transferring-asset-modal.component';
import { CreateOrEditExportingUsedAssetModalComponent } from './exporting-used-asset/create-or-edit-exporting-used-asset-modal.component';
import { ExportingUsedAssetComponent } from './exporting-used-asset/exporting-used-asset.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "",
                children: [
                    {
                        path: 'duan', component: DuAnComponent,
                        data: { permission: 'Pages.Administration.Project' }
                    },
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "customer",
                        component: CustomerComponent,
                        data: { permission: "Pages.Administration.Customer" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "vehicle",
                        component: VehicleComponent,
                        data: { permission: "Pages.Administration.Vehicle" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "typevehicle",
                        component: TypeVehicleComponent,
                        data: { permission: "Pages.Administration.TypeVehicle" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "asset",
                        component: Asset_8Component,
                        data: { permission: "Pages.QuanLyXe.Asset" }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "brandvehicle",
                        component: BrandVehicleComponent,
                        data: {
                            permission: "Pages.Administration.BrandVehicle"
                        }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "modelvehicle",
                        component: ModelVehicleComponent,
                        data: {
                            permission: "Pages.Administration.ModelVehicle"
                        }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "operatevehicle",
                        component: OperateVehicleComponent,
                        data: {
                            permission: "Pages.Administration.OperateVehicle"
                        }
                    }
                ]
            },
            {
                path: "",
                children: [
                    {
                        path: "roadfeevehicle",
                        component: RoadFeeVehicleComponent,
                        data: {
                            permission: "Pages.Administration.RoadFeeVehicle"
                        }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothau', component: HoSoThauComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'insurrance', component: InsurranceComponent,
                        data: { permission: 'Pages.Administration.Insurrance' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'nhacungcap', component: NhaCungCapComponent,
                        data: { permission: 'Pages.Administration.Supplier' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'insurrancetype', component: InsurranceTypeComponent,
                        data: { permission: 'Pages.Administration.InsurranceType' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hopdongthau', component: HopDongThauComponent,
                        data: { permission: 'Pages.Administration.Contract' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-management', component: RealEstateManagementComponent,
                        data: { permission: 'Pages.Administration.RealEstate9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothau_modal', component: CreateOrEditHoSoThauModalComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'view_hosothau_modal', component: ViewHoSoThauModalComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'nhacungcap', component: NhaCungCapComponent,
                        data: { permission: 'Pages.Administration.Supplier' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'fixed-asset', component: FixedAssetComponent,
                        data: { permission: 'Pages.Administration.FixedAsset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-type', component: RealEstateTypeComponent,
                        data: { permission: 'Pages.Administration.RealEstateType9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hopdongthau_modal', component: CreateOrEditHopDongThauModalComponent,
                        data: { permission: 'Pages.Administration.Contract' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-dashboard', component: AssetDashboardComponent,
                        data: { permission: 'Pages.Administration.AssetDashboard' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'view_hopdongthau_modal', component: ViewHopDongThauModalComponent,
                        data: { permission: 'Pages.Administration.Contract' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'phieugoihang', component: PhieuGoiHangComponent,
                        data: { permission: 'Pages.Administration.GoodsInvoice' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'phieugoihang_modal', component: CreateOrEditPhieuGoiHangModalComponent,
                        data: { permission: 'Pages.Administration.GoodsInvoice' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'view_phieugoihang_modal', component: ViewPhieuGoiHangModalComponent,
                        data: { permission: 'Pages.Administration.GoodsInvoice' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hanghoa', component: HangHoaComponent,
                        data: { permission: 'Pages.Administration.Goods' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'LoaiNhaCungCap', component: LoaiNhaCungCapComponent,
                        data: { permission: 'Pages.Administration.LoaiNhaCungCap' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-group', component: AssetGroupComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'NhaCungCapHangHoa', component: NhaCungCapHangHoaComponent,
                        data: { permission: 'Pages.Administration.NhaCungCapHangHoa' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'category', component: CategoryComponent,
                        data: { permission: 'Pages.Categories.General' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'Product', component: ProductComponent,
                        data: { permission: 'Pages.Administration.Product' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'category-type', component: CategoryTypeComponent,
                        data: { permission: 'Pages.CategoryTypes.General' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'shoppingPlan', component: ShoppingPlanComponent,
                        data: { permission: 'Pages.Administration.ShoppingPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'ShoppingPlan', component: ShoppingPlanDetailComponent,
                        data: { permission: 'Pages.Administration.ShoppingPlanDetail' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'directorShoppingPlan', component: DirectorShoppingPlanComponent,
                        data: { permission: 'Pages.Administration.DirectorShoppingPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'constructionPlan', component: ConstructionPlanComponent,
                        data: { permission: 'Pages.Administration.ConstructionPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'loaibatdongsan', component: LoaiBatDongSanComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.LoaiBatDongSan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'loaisohuu', component: LoaiSoHuuComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.LoaiSoHuu' }
                    },
                ]
            },
            //{
            //    path: '',
            //    children: [
            //        {
            //            path: 'mucdichsudungdat', component: MucDichSuDungDatComponent,
            //            data: { permission: 'Pages.Administration.MucDichSuDungDat' }
            //        },
            //    ]

            //},
            {
                path: '',
                children: [
                    {
                        path: 'batdongsan', component: BatDongSanComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.BatDongSan' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'hientrangphaply', component: HienTrangPhapLyComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.HienTrangPhapLy' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'tinhtrangsudungdat', component: TinhTrangSuDungDatComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.TinhTrangSuDungDat' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'taisan', component: TaiSanComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.TaiSan' }
                    },
                ]

            },
            {
                path: '',
                children: [
                    {
                        path: 'suachuabatdongsan', component: SuaChuaBatDongSanComponent,
                        data: { permission: 'Pages.Administration.QuanLyBatDongSan.SuaChuaBatDongSan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'constructionPlan', component: ConstructionPlanDetailComponent,
                        data: { permission: 'Pages.Administration.ConstructionPlanDetail' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {

                        path: 'asset-investment-efficiency/purchased-assets', component: PurchasedAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'kehoachxaydung', component: KeHoachXayDungComponent,
                        data: { permission: 'Pages.Administration.QuanLyKeHoachXayDung.KeHoachXayDung' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'disposalPlan', component: DisposalPlanComponent,
                        data: { permission: 'Pages.Administration.DisposalPlan' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {

                        path: 'asset-investment-efficiency/sole-assets', component: SoleAssetsComponent,
                        data: { permission: '' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'congtrinh', component: CongTrinhComponent,
                        data: { permission: 'Pages.Administration.QuanLyCongTrinhDoDang.CongTrinhDoDang' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {

                        path: 'asset-investment-efficiency/maintained-assets', component: MaintainedAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'hosothaun13', component: HoSoThauN13Component,
                        data: { permission: 'Pages.Administration.QuanLyCongTrinhDoDang.HoSoThau' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/planned-to-sell-assets', component: PlannedToSellAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'computer', component: ComputerComponent,
                        data: { permission: 'Pages.Administration.Computer'}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/operating-assets', component: OperatingAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'software', component: SoftwareComponent,
                        data: { permission: 'Pages.Administration.Software'}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/planned-to-purchase-assets', component: PlannedToPurchaseAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset', component: AssetComponent,
                        data: { permission: 'Pages.Administration.Asset_05' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-investment-efficiency/planned-to-maintain-assets', component: PlannedToMaintainAssetsComponent,
                        data: { permission: ''}
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-repair', component: RealEstateRepairComponent,
                        data: { permission: 'Pages.Administration.RealEstateRepair9' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset11', component: Asset11Component,
                        data: { permission: 'Pages.Administration.Asset11' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'debit11',
                        component: Debit11Component,
                        data: { permission: 'Pages.Administration.Debit11' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'DisposalPlan', component: DisposalPlanDetailComponent,
                        data: { permission: 'Pages.Administration.DisposalPlanDetail' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'credit11',
                        component: Credit11Component,
                        data: { permission: 'Pages.Administration.Credit11' }
                    }
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'ProductType', component: ProductTypeComponent,
                        data: { permission: 'Pages.Administration.ProductType' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-management', component: RealEstateManagementComponent,
                        data: { permission: 'Pages.Administration.RealEstate9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-type', component: RealEstateTypeComponent,
                        data: { permission: 'Pages.Administration.RealEstateType9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'real-estate-repair', component: RealEstateRepairComponent,
                        data: { permission: 'Pages.Administration.RealEstateRepair9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'plan', component: PlanComponent,
                        data: { permission: 'Pages.Administration.Plan9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'construction', component: ConstructionComponent,
                        data: { permission: 'Pages.Administration.Construction9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'bid-manager', component: BidManagerComponent,
                        data: { permission: 'Pages.Administration.BidManager9' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-dashboard', component: AssetDashboardComponent,
                        data: { permission: 'Pages.Administration.AssetDashboard' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset-group', component: AssetGroupComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset', component: AssetComponent,
                        data: { permission: 'Pages.Administration.Asset_05' }
                    },
                ]
            },
            {
                path: 'asset-group',
                children: [
                    {
                        path: 'create-or-edit-asset-group', component: CreateOrEditAssetGroupModalComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05.Create' }
                    },
                ]
            },
            {
                path: 'asset',
                children: [
                    {
                        path: 'create-or-edit-asset', component: CreateOrEditAssetModalComponent,
                        data: { permission: 'Pages.Administration.Asset_05.Create' }
                    },
                ]
            },
            {
                path: 'asset-group',
                children: [
                    {
                        path: 'create-or-edit-asset-group/:assetGroupId/:readOnly', component: CreateOrEditAssetGroupModalComponent,
                        data: { permission: 'Pages.Administration.AssetGroup_05.Create' }
                    },
                ]
            },
            {
                path: 'asset',
                children: [
                    {
                        path: 'create-or-edit-asset/:assetId/:readOnly', component: CreateOrEditAssetModalComponent,
                        data: { permission: 'Pages.Administration.Asset_05.Create' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'transferring-asset', component: TransferringAssetComponent,
                        data: { permission: 'Pages.Administration.TransferringAsset' }
                    },
                ]
            },
            {
                path: 'transferring-asset',
                children: [
                    {
                        path: 'create-or-edit-transferring-asset', component: CreateOrEditTransferringAssetModalComponent,
                        data: { permission: 'Pages.Administration.TransferringAsset.Create' }
                    },
                ]
            },
            {
                path: 'transferring-asset',
                children: [
                    {
                        path: 'create-or-edit-transferring-asset/:transferringAssetId', component: CreateOrEditTransferringAssetModalComponent,
                        data: { permission: 'Pages.Administration.TransferringAsset.Edit' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'exporting-used-asset', component: ExportingUsedAssetComponent,
                        data: { permission: 'Pages.Administration.ExportingUsedAsset' }
                    },
                ]
            },
            {
                path: 'exporting-used-asset',
                children: [
                    {
                        path: 'create-or-edit-exporting-used-asset', component: CreateOrEditExportingUsedAssetModalComponent,
                        data: { permission: 'Pages.Administration.ExportingUsedAsset.Create' }
                    },
                ]
            },
            {
                path: 'exporting-used-asset',
                children: [
                    {
                        path: 'create-or-edit-exporting-used-asset/:exportingUsedId', component: CreateOrEditExportingUsedAssetModalComponent,
                        data: { permission: 'Pages.Administration.ExportingUsedAsset.Edit' }
                    },
                ]
            },

        ])
    ],
    exports: [RouterModule]
})
export class GWebsiteRoutingModule {}
