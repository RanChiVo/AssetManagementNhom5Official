import { VehicleServiceProxy } from "./../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import {
    AfterViewInit,
    Injector,
    Component,
    ViewChild,
    Output,
    EventEmitter
} from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";
import { LazyLoadEvent } from "primeng/primeng";
import { Table } from "primeng/table";
import { Paginator } from "primeng/components/paginator/paginator";
import { ActivatedRoute, Params } from "@angular/router";

@Component({
    selector: "selectVehicleModal",
    templateUrl: "./select-vehicle-modal.component.html"
})
export class SelectVehicleModalComponent extends AppComponentBase {
    @ViewChild("viewModal") modal: ModalDirective;
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;
    constructor(
        injector: Injector,
        private _vehicleService: VehicleServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    vehicleName: string;
    mataisan: string;
    public selectedMaXe: number;

    // Output sự kiện cho component khác xử lý, khi cái modol này lưu, thì biến modalSave sẽ thay đổi

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    show(customerId?: number | null | undefined): void {
        // this._assetService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.vehicleName = params["Name"] || "";
            this.mataisan = "";
            this.reloadList(this.vehicleName, this.mataisan, null);
        });
        this.selectedMaXe = -1;
        this.modal.show();
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    selectedVehicle(maxe): void {
        this.selectedMaXe = maxe;
        this.close();
    }

    /**
     * Hàm get danh sách Asset
     * @param event
     */
    getVehicles(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, event);
    }

    reloadList(vehicleName, taisanName, event?: LazyLoadEvent) {
        this._vehicleService
            .getVehiclesByFilter(
                vehicleName,
                taisanName,
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
        this.reloadList(this.vehicleName, this.mataisan, null);

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
