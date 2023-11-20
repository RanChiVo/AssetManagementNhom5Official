import { ViewOperateVehicleModalComponent } from "./view-operatevehicle-modal.component";
import {
    AfterViewInit,
    Component,
    ElementRef,
    Injector,
    OnInit,
    ViewChild
} from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import * as _ from "lodash";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import {
    OperateVehicleServiceProxy,
    VehicleInput
} from "@shared/service-proxies/service-proxies";
import { CreateOrEditOperateVehicleModalComponent } from "./create-or-edit-operatevehicle-modal.component";
import { SelectVehicleModalComponent } from "../vehicle/select-vehicle-modal.component";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
@Component({
    templateUrl: "./operatevehicle.component.html",
    animations: [appModuleAnimation()]
})
export class OperateVehicleComponent extends AppComponentBase
    implements AfterViewInit, OnInit {
    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;
    @ViewChild("createOrEditModal")
    createOrEditModal: CreateOrEditOperateVehicleModalComponent;
    @ViewChild("viewOperateVehicleModal")
    viewOperateVehiclModal: ViewOperateVehicleModalComponent;
    @ViewChild("selectVehicleModal")
    selectVehicleModal: SelectVehicleModalComponent;

    xe: VehicleInput = new VehicleInput();
    /**
     * tạo các biến dể filters
     */
    operatevehicleName: string;
    selectedVehicle: number;
    nuberfilter: number;
    constructor(
        injector: Injector,
        private _operatevehicleService: OperateVehicleServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {}

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getOperateVehicles(event?: LazyLoadEvent) {
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

    reloadList(operatevehicleName, number, event?: LazyLoadEvent) {
        this._operatevehicleService
            .getOperateVehiclesByFilter(
                operatevehicleName,
                number,
                null,
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

    deleteOperateVehicle(id): void {
        this._operatevehicleService.deleteBrandVehicle(id).subscribe(() => {
            this.reloadPage();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.operatevehicleName = params["name"] || "";
            this.reloadList(this.operatevehicleName, this.nuberfilter, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.operatevehicleName, this.nuberfilter, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createOperateVehicle() {
        this.createOrEditModal.show();
    }
    updateVehicle(): void {
        if (this.selectVehicleModal.selectedMaXe != -1) {
            this.selectedVehicle = this.selectVehicleModal.selectedMaXe;
            this._apiService
                .getForEdit(
                    "api/Vehicle/GetVehicleForView",
                    this.selectedVehicle
                )
                .subscribe(result => {
                    this.xe = result;
                });
        }
    }
    showXe(): void {
        console.log("Mo tai san");
        this.selectVehicleModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, "...");
    }
}
