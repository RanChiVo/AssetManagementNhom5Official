import {
    CustomerForViewDto,
    Asset_8ServiceProxy
} from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import {
    AfterViewInit,
    Injector,
    Component,
    ViewChild,
    Output,
    EventEmitter
} from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";
import { LazyLoadEvent } from "primeng/primeng";
import { Table } from "primeng/table";
import { Paginator } from "primeng/components/paginator/paginator";
import { ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: "selectAsset_8Modal",
    templateUrl: "./select-asset_8-modal.component.html"
})
export class SelectAsset_8ModalComponent extends AppComponentBase {
    customer: CustomerForViewDto = new CustomerForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;
    constructor(
        injector: Injector,
        private _assetService: Asset_8ServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    assetName: string;
    public selectedMaTS: number;

    // Output sự kiện cho component khác xử lý, khi cái modol này lưu, thì biến modalSave sẽ thay đổi

    //@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    show(customerId?: number | null | undefined): void {
        // this._assetService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.assetName = params["TenTaiSan"] || "";
            this.reloadList(this.assetName, null);
        });
        this.selectedMaTS = -1;
        this.modal.show();
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    selectedAsset(mats): void {
        this.selectedMaTS = mats;
        console.log("Gia tri select:" + mats);
        this.close();
    }

    /**
     * Hàm get danh sách Asset
     * @param event
     */
    getAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);
    }

    reloadList(assetName, event?: LazyLoadEvent) {
        this._assetService
            .getAssets_8ByFilter(
                null,
                null,
                null,
                null,
                assetName,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(
                    this.paginator,
                    event
                ),
                this.primengTableHelper.getSkipCount(this.paginator, event)
            )
            .subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.assetName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, "...");
    }
}
