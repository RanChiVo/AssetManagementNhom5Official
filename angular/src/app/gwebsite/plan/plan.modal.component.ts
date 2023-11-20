import { CustomerForViewDto, PlanServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
import { NumericDictionary } from 'lodash';
import { SelectionConstructionInPlanModalComponent } from './select-construction-in-plan.modal.conponent';

@Component({
    selector: 'selectPlanModal',
    templateUrl: './plan.modal.component.html'
})

export class PlanModalComponent extends AppComponentBase {

    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('selectConstructionModal') selectConstructionModal: SelectionConstructionInPlanModalComponent;
    constructor(
        injector: Injector,
        private _PlanService: PlanServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    active = false;
    TenKeHoach: string;
    MaKeHoach: string;
    MaDonVi: string;
    NgayLapKeHoach: string;
    public pPlanID: number;
    selectedMaKH: string;
    //@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(): void {
        // this._PlanService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter
        this.selectedMaKH = '';
        this.pPlanID = 0;
        this._activatedRoute.params.subscribe((params: Params) => {
            this.TenKeHoach = params['TenKeHoach'] || '';
            this.MaKeHoach = params['MaKeHoach'] || '';
            this.MaDonVi = params['MaDonVi'] || '';
            this.NgayLapKeHoach = params['NgayLapKeHoach'] || '';
            this.reloadList(this.MaKeHoach, this.TenKeHoach, this.MaDonVi, this.NgayLapKeHoach, null);
        });

        this.modal.show();

    }


    //setActive(): void {
    //    this.active = true;
    //}
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }



    SetSelectedCongTrinhID(ID): void {
        this.pPlanID = ID;
        this.close()
    }


    /**
     * Hàm get danh sách Plan
     * @param event
     */
    getPlans(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, null, event);

    }


    reloadList(MaKeHoach, TenKeHoach, MaDonVi, NgayLapKeHoach, event?: LazyLoadEvent) {
        this._PlanService.getPlansByFilter(MaKeHoach, TenKeHoach, MaDonVi, NgayLapKeHoach, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }



    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaKeHoach, this.TenKeHoach, this.MaDonVi, this.NgayLapKeHoach, null);
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
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
