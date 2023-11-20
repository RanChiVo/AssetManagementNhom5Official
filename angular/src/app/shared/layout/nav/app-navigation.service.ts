import { PermissionCheckerService } from "@abp/auth/permission-checker.service";
import { Injectable } from "@angular/core";
import { AppMenu } from "./app-menu";
import { AppMenuItem } from "./app-menu-item";

@Injectable()
export class AppNavigationService {
    constructor(private _permissionService: PermissionCheckerService) {}

    getMenu(): AppMenu {
        return new AppMenu('MainMenu', 'MainMenu', [
            new AppMenuItem('Dashboard', 'Pages.Administration.Host.Dashboard', 'flaticon-line-graph', '/app/admin/hostDashboard'),
            new AppMenuItem('Dashboard', 'Pages.Tenant.Dashboard', 'flaticon-line-graph', '/app/main/dashboard'),
            new AppMenuItem('Tenants', 'Pages.Tenants', 'flaticon-list-3', '/app/admin/tenants'),
            new AppMenuItem('AssetDashboard', 'Pages.Administration.AssetDashboard', 'flaticon-line-graph', '/app/gwebsite/asset-dashboard'),
            new AppMenuItem('Editions', 'Pages.Editions', 'flaticon-app', '/app/admin/editions'),
            new AppMenuItem('Nhóm 1 - Quản lý danh mục', '', 'flaticon-grid-menu', '', [
                new AppMenuItem('Loại danh mục', 'Pages.CategoryTypes.General', 'flaticon-menu-1', '/app/gwebsite/category-type'),
                new AppMenuItem('Danh sách danh mục', 'Pages.Categories.General', 'flaticon-menu-1', '/app/gwebsite/category')
            ]),
            new AppMenuItem('Nhóm 2 - Quản lý kế hoạch mua sắm', '', 'flaticon-interface-8', '', [
                new AppMenuItem('ShoppingPlan', 'Pages.Administration.ShoppingPlan', 'flaticon-menu-1', '/app/gwebsite/shoppingPlan'),
                new AppMenuItem('DirectorShoppingPlan', 'Pages.Administration.DirectorShoppingPlan', 'flaticon-menu-1', '/app/gwebsite/directorShoppingPlan'),
                new AppMenuItem('ConstructionPlan', 'Pages.Administration.ConstructionPlan', 'flaticon-menu-1', '/app/gwebsite/constructionPlan')
            ]),
            new AppMenuItem('Nhóm 3 - Quản lý nghiệp vụ mua sắm', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Dự án', 'Pages.Administration.Project', 'flaticon-menu-1', '/app/gwebsite/duan'),
                new AppMenuItem('Hàng hoá', 'Pages.Administration.Goods', 'flaticon-menu-1', '/app/gwebsite/hanghoa'),
                new AppMenuItem('Nhà cung cấp', 'Pages.Administration.Supplier', 'flaticon-menu-1', '/app/gwebsite/nhacungcap'),
                new AppMenuItem('Hồ sơ thầu', 'Pages.Administration.Bid', 'flaticon-menu-1', '/app/gwebsite/hosothau'),
                new AppMenuItem('Hợp đồng thầu', 'Pages.Administration.Contract', 'flaticon-menu-1', '/app/gwebsite/hopdongthau'),
                new AppMenuItem('Phiếu gọi hàng', 'Pages.Administration.GoodsInvoice', 'flaticon-menu-1', '/app/gwebsite/phieugoihang'),
            ]),
            new AppMenuItem('Nhóm 5 - Quản lý tài sản cố định', '', 'flaticon-interface-8', '', [
                new AppMenuItem('TransferringAsset', 'Pages.Administration.TransferringAsset', 'flaticon-line-graph', '/app/gwebsite/transferring-asset'),
                new AppMenuItem('AssetGroup', 'Pages.Administration.AssetGroup_05', 'flaticon-menu-1', '/app/gwebsite/asset-group'),
                new AppMenuItem('Asset', 'Pages.Administration.Asset_05', 'flaticon-menu-1', '/app/gwebsite/asset'),
                new AppMenuItem('ExportingUsedAsset', 'Pages.Administration.ExportingUsedAsset', 'flaticon-menu-1', '/app/gwebsite/exporting-used-asset'),
            ]),
            new AppMenuItem('Nhóm 6 - Administration', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Quản lý hiệu quả đầu tư TSCĐ', '', 'flaticon-menu-1', '', [
                    new AppMenuItem('QL giá trị đã đầu tư', '', 'flaticon-menu-1', '', [
                        new AppMenuItem('Mua tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/purchased-assets'),
                        new AppMenuItem('Vận hành tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/operating-assets'),
                        new AppMenuItem('Bảo trì tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/maintained-assets')
                    ]),
                    new AppMenuItem('QL giá trị dự kiến đầu tư', '', 'flaticon-menu-1', '', [
                        new AppMenuItem('Mua tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/planned-to-purchase-assets'),
                        new AppMenuItem('Bảo trì tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/planned-to-maintain-assets')
                    ]),
                    new AppMenuItem('QL giá trị đã thu về', '', 'flaticon-menu-1', '', [
                        new AppMenuItem('Thanh lý tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/sole-assets'),
                    ]),
                    new AppMenuItem('QL giá trị dự kiến thu về', '', 'flaticon-menu-1', '', [
                        new AppMenuItem('Thanh lý tài sản', '', 'flaticon-menu-1', '/app/gwebsite/asset-investment-efficiency/planned-to-sell-assets'),
                    ])
                ]),
            ]),
            new AppMenuItem('Nhóm 8 - Vehicle Manager', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Asset', 'Pages.QuanLyXe.Asset', 'flaticon-menu-1', '/app/gwebsite/asset'),
                new AppMenuItem('Vehicle', 'Pages.Administration.Vehicle', 'flaticon-menu-1', '/app/gwebsite/vehicle'),
                new AppMenuItem('TypeVehicle', 'Pages.Administration.TypeVehicle', 'flaticon-menu-1', '/app/gwebsite/typevehicle'),
                new AppMenuItem('BrandVehicle', 'Pages.Administration.BrandVehicle', 'flaticon-menu-1', '/app/gwebsite/brandvehicle'),
                new AppMenuItem('ModelVehicle', 'Pages.Administration.ModelVehicle', 'flaticon-menu-1', '/app/gwebsite/modelvehicle'),
                new AppMenuItem('OperateVehicle', 'Pages.Administration.OperateVehicle', 'flaticon-menu-1', '/app/gwebsite/operatevehicle'),
                new AppMenuItem('RoadFeeVehicle', 'Pages.Administration.RoadFeeVehicle', 'flaticon-menu-1', '/app/gwebsite/roadfeevehicle'),
                new AppMenuItem('Insurrance Manager', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('InsurranceVehicle', 'Pages.Administration.Insurrance', 'flaticon-menu-1', '/app/gwebsite/insurrance'),
                    new AppMenuItem('InsurranceTypeVehicle', 'Pages.Administration.InsurranceType', 'flaticon-menu-1', '/app/gwebsite/insurrancetype')
                ]),
            ]),
            new AppMenuItem('Nhóm 9 - Quản lý bất động sản', '', 'flaticon-interface-8', '', [
                new AppMenuItem('RealEstateManagement', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('RealEstate', 'Pages.Administration.RealEstate9', 'flaticon-menu-1', '/app/gwebsite/real-estate-management'),
                    new AppMenuItem('RealEstateType', 'Pages.Administration.RealEstateType9', 'flaticon-menu-1', '/app/gwebsite/real-estate-type'),
                    new AppMenuItem('RealEstateRepair', 'Pages.Administration.RealEstateRepair9', 'flaticon-menu-1', '/app/gwebsite/real-estate-repair')
                ]),
                new AppMenuItem('ConstructionManagement', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('PlanManagement', 'Pages.Administration.Plan9', 'flaticon-menu-1', '/app/gwebsite/plan'),
                    new AppMenuItem('ConstructionManager', 'Pages.Administration.Construction9', 'flaticon-menu-1', '/app/gwebsite/construction')
                ]),
                new AppMenuItem('BidManager', 'Pages.Administration.BidManager9', 'flaticon-menu-1', '/app/gwebsite/bid-manager')
            ]),
            new AppMenuItem('Nhóm 10 - Quản Lý Nhà Cung Cấp Hàng Hóa', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Loại Nhà Cung Cấp', 'Pages.Administration.LoaiNhaCungCap', 'flaticon-menu-1', '/app/gwebsite/LoaiNhaCungCap'),
                new AppMenuItem('Nhà Cung Cấp Hàng Hóa', 'Pages.Administration.NhaCungCapHangHoa', 'flaticon-menu-1', '/app/gwebsite/NhaCungCapHangHoa'),
                new AppMenuItem('Loại Sản Phẩm', 'Pages.Administration.ProductType', 'flaticon-menu-1', '/app/gwebsite/ProductType'),
                new AppMenuItem('Sản Phẩm', 'Pages.Administration.Product', 'flaticon-menu-1', '/app/gwebsite/Product')
            ]),
            new AppMenuItem('Nhóm 11 - Quản Lý Tài Khoản Kế Toán', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Asset11', 'Pages.Administration.Asset11', 'flaticon-menu-1', '/app/gwebsite/asset11'),
                new AppMenuItem('Debit11', 'Pages.Administration.Debit11', 'flaticon-menu-1', '/app/gwebsite/debit11'),
                 new AppMenuItem('Credit11', 'Pages.Administration.Credit11', 'flaticon-menu-1', '/app/gwebsite/credit11')
            ]),
            new AppMenuItem('Nhóm 13 - Quản lý bất động sản', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Quản Lý Bất Động Sản N13', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('Bất Động Sản N13', 'Pages.Administration.QuanLyBatDongSan.BatDongSan', 'flaticon-menu-1', '/app/gwebsite/batdongsan'),
                    new AppMenuItem('Sửa Chữa Bất Động Sản N13', 'Pages.Administration.QuanLyBatDongSan.SuaChuaBatDongSan', 'flaticon-menu-1', '/app/gwebsite/suachuabatdongsan'),
                    new AppMenuItem('Loại Bất Động Sản N13', 'Pages.Administration.QuanLyBatDongSan.LoaiBatDongSan', 'flaticon-menu-1', '/app/gwebsite/loaibatdongsan'),
                    new AppMenuItem('Loại Sở Hữu N13', 'Pages.Administration.QuanLyBatDongSan.LoaiSoHuu', 'flaticon-menu-1', '/app/gwebsite/loaisohuu'),
                    new AppMenuItem('Hiện Trạng Pháp Lý N13', 'Pages.Administration.QuanLyBatDongSan.HienTrangPhapLy', 'flaticon-menu-1', '/app/gwebsite/hientrangphaply'),
                    new AppMenuItem('Tình Trạng Sử Dụng Đất N13', 'Pages.Administration.QuanLyBatDongSan.TinhTrangSuDungDat', 'flaticon-menu-1', '/app/gwebsite/tinhtrangsudungdat'),
                    new AppMenuItem('Tài Sản Test N13', 'Pages.Administration.QuanLyBatDongSan.TaiSan', 'flaticon-menu-1', '/app/gwebsite/taisan'),
                ]),
                new AppMenuItem('Quản Lý Kế hoạch XD N13', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('Kế hoạch XD cơ bản N13', 'Pages.Administration.QuanLyKeHoachXayDung.KeHoachXayDung', 'flaticon-menu-1', '/app/gwebsite/kehoachxaydung'),
                ]),
                new AppMenuItem('Quản Lý Công trình N13', '', 'flaticon-interface-8', '', [
                    new AppMenuItem('Công trình dỡ dang N13', 'Pages.Administration.QuanLyCongTrinhDoDang.CongTrinhDoDang', 'flaticon-menu-1', '/app/gwebsite/congtrinh'),
                    new AppMenuItem('Hồ sơ thầu N13', 'Pages.Administration.QuanLyCongTrinhDoDang.HoSoThau', 'flaticon-menu-1', '/app/gwebsite/hosothaun13'),
                ]),
            ]),
            new AppMenuItem('Nhóm 14 - Quản lý tài sản IT', '', 'flaticon-interface-8', '', [
                new AppMenuItem('Computer', 'Pages.Administration.Computer', 'flaticon-menu-1', '/app/gwebsite/computer'),
                new AppMenuItem('Software', 'Pages.Administration.Software', 'flaticon-menu-1', '/app/gwebsite/software')
            ]),

            new AppMenuItem('Systems', '', 'flaticon-layers', '', [
                new AppMenuItem('OrganizationUnits', 'Pages.Administration.OrganizationUnits', 'flaticon-map', '/app/admin/organization-units'),
                new AppMenuItem('Roles', 'Pages.Administration.Roles', 'flaticon-suitcase', '/app/admin/roles'),
                new AppMenuItem('Users', 'Pages.Administration.Users', 'flaticon-users', '/app/admin/users'),
                new AppMenuItem('Languages', 'Pages.Administration.Languages', 'flaticon-tabs', '/app/admin/languages'),
                new AppMenuItem('AuditLogs', 'Pages.Administration.AuditLogs', 'flaticon-folder-1', '/app/admin/auditLogs'),
                new AppMenuItem('Maintenance', 'Pages.Administration.Host.Maintenance', 'flaticon-lock', '/app/admin/maintenance'),
                new AppMenuItem('Subscription', 'Pages.Administration.Tenant.SubscriptionManagement', 'flaticon-refresh', '/app/admin/subscription-management'),
                new AppMenuItem('VisualSettings', 'Pages.Administration.UiCustomization', 'flaticon-medical', '/app/admin/ui-customization'),
                new AppMenuItem('Settings', 'Pages.Administration.Host.Settings', 'flaticon-settings', '/app/admin/hostSettings'),
                new AppMenuItem('Settings', 'Pages.Administration.Tenant.Settings', 'flaticon-settings', '/app/admin/tenantSettings')
            ]),
            new AppMenuItem(
                "DemoUiComponents",
                "Pages.DemoUiComponents",
                "flaticon-shapes",
                "/app/admin/demo-ui-components"
            )
        ]);
    }

    checkChildMenuItemPermission(menuItem): boolean {
        for (let i = 0; i < menuItem.items.length; i++) {
            let subMenuItem = menuItem.items[i];

            if (
                subMenuItem.permissionName &&
                this._permissionService.isGranted(subMenuItem.permissionName)
            ) {
                return true;
            }

            if (subMenuItem.items && subMenuItem.items.length) {
                return this.checkChildMenuItemPermission(subMenuItem);
            } else if (!subMenuItem.permissionName) {
                return true;
            }
        }
        return false;
    }
}
