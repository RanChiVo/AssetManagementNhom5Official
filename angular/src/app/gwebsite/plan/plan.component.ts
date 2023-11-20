import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditPlanModalComponent } from './create-or-edit-plan-modal.component';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectionConstructionInPlanModalComponent } from './select-construction-in-plan.modal.conponent';

@Component({
    templateUrl: './plan.component.html',
    selector: 'PlanModal',
    animations: [appModuleAnimation()]
})
export class PlanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditPlanModal') createOrEditPlanModal: CreateOrEditPlanModalComponent;
    @ViewChild('selectionConstructionInPlan') selectionConstructionInPlan: SelectionConstructionInPlanModalComponent;
    @ViewChild('PlanModal') modal: ModalDirective;

    /**
     * tạo các biến dể filters
     */
    MaKH: string;
    TenKH: string;
    MaDV: string;
    NgayThanhLap: string;
    
    constructor(
        injector: Injector,
        private _planService: PlanServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
      
    }



    show(): void {
        this.modal.show();
    }
    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách KeHoachXayDung
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

    reloadList(makh, tenkh, madv, ngaylap, event?: LazyLoadEvent) {
        this._planService.getPlansByFilter(makh, tenkh, madv, ngaylap, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.createOrEditPlanModal.pCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deletePlan(id): void {
        this._planService.deletePlan(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaKH = params['MaKeHoach'] || '';
            this.TenKH = params['TenKeHoach'] || '';
            this.MaDV = params['MaDonVi'] || '';
            this.NgayThanhLap = params['NgayThanhLap'] || '';
            this.reloadList(this.MaKH, this.TenKH, this.MaDV, this.NgayThanhLap, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaKH, this.TenKH, this.MaDV, this.NgayThanhLap, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createPlan() {
        this.createOrEditPlanModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
