import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild,Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { DisposalPlanDetailServiceProxy, DisposalPlanInput, DisposalPlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditDisposalPlanDetailModalComponent } from './create-or-edit-disposalPlanDetail-modal.component';
import { ModalDirective } from 'ngx-bootstrap';
import { filter } from 'rxjs/operators';

@Component({
    templateUrl: './disposalPlanDetail.component.html',
    animations: [appModuleAnimation()],
    selector: 'viewDisposalPlanDetailModal'
})
export class DisposalPlanDetailComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditDisposalPlanDetailModalComponent;
    @ViewChild('viewDetailModal') viewDetailModal: ModalDirective;

    /**
     * tạo các biến dể filters
     */
    disposalPlanMaKeHoach: string;
    /*
     * bien nhan thong tin tu parent form
     */
    @Input() selectedRow: DisposalPlanInput = new DisposalPlanInput();

    constructor(
        injector: Injector,
        private _disposalPlanDetailService: DisposalPlanDetailServiceProxy,
        private __disposalPlanService: DisposalPlanServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {

    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    show(): void {
        this.viewDetailModal.show();
        this.disposalPlanMaKeHoach = this.selectedRow.maKeHoach;
        this.applyFilters();
    }

    close(): void {
        this.viewDetailModal.hide();
    }
    /**
     * Hàm get danh sách disposalPlans
     * @param event
     */
    getDisposalPlanDetails(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }
        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();
        this.reloadList(this.disposalPlanMaKeHoach, event);
    }

    reloadList(disposalPlanMaKeHoach, event?: LazyLoadEvent) {
        this._disposalPlanDetailService.getDisposalPlanDetailsByFilter(disposalPlanMaKeHoach,this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteDisposalPlanDetail(id): void {
        this._disposalPlanDetailService.deleteDisposalPlanDetail(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.disposalPlanMaKeHoach = params['maKeHoach'] || '';;
            this.reloadList(this.disposalPlanMaKeHoach,null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.disposalPlanMaKeHoach,null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createDisposalPlanDetail() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    checkDisposalPlan(): void {
        this.selectedRow.trangThai = "Đã duyệt";
        this.__disposalPlanService.createOrEditDisposalPlan(this.selectedRow).subscribe(result => {
            this.notify.info(this.l('Duyet thanh cong!'));
            this.close();
        });
    }
}