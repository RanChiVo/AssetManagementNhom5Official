import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild,Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ShoppingPlanDetailServiceProxy, ShoppingPlanInput, ShoppingPlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditShoppingPlanDetailModalComponent } from './create-or-edit-shoppingPlanDetail-modal.component';
import { ModalDirective } from 'ngx-bootstrap';
import { filter } from 'rxjs/operators';

@Component({
    templateUrl: './shoppingPlanDetail.component.html',
    animations: [appModuleAnimation()],
    styles:[`.hide{display:none;}`],
    selector: 'viewDetailModal'
})
export class ShoppingPlanDetailComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditShoppingPlanDetailModalComponent;
    @ViewChild('viewDetailModal') viewDetailModal: ModalDirective;

    /**
     * tạo các biến dể filters
     */
    shoppingPlanMaKeHoach: string;
    /*
     * bien nhan thong tin tu parent form
     */
    @Input() selectedRow: ShoppingPlanInput = new ShoppingPlanInput();
    @Output() detailSave: EventEmitter<any> = new EventEmitter<any>();

    constructor(
        injector: Injector,
        private _shoppingPlanDetailService: ShoppingPlanDetailServiceProxy,
        private __shoppingPlanService: ShoppingPlanServiceProxy,
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
        this.shoppingPlanMaKeHoach = this.selectedRow.maKeHoach;
        this.applyFilters();
    }

    close(): void {
        this.viewDetailModal.hide();
        this.detailSave.emit(null);
    }
    /**
     * Hàm get danh sách shoppingPlans
     * @param event
     */
    getShoppingPlanDetails(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }
        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();
        this.reloadList(this.shoppingPlanMaKeHoach, event);
    }

    reloadList(shoppingPlanMaKeHoach, event?: LazyLoadEvent) {
        this._shoppingPlanDetailService.getShoppingPlansByFilter(shoppingPlanMaKeHoach,this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteShoppingPlanDetail(id): void {
        this._shoppingPlanDetailService.deleteShoppingPlanDetail(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.shoppingPlanMaKeHoach = params['maKeHoach'] || '';;
            this.reloadList(this.shoppingPlanMaKeHoach,null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.shoppingPlanMaKeHoach,null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createShoppingPlanDetail() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    checkShoppingPlan(): void {
        if (this.selectedRow.tinhTrang == "not check" || this.selectedRow.tinhTrang == null)
            this.selectedRow.tinhTrang = "checking";
        else this.selectedRow.tinhTrang = "checked";
        let input = this.selectedRow;
        console.log(input);
        this.__shoppingPlanService.createOrEditShoppingPlan(input).subscribe(result => {
            this.notify.info(this.l('Duyet thanh cong!'));
            this.close();
        });
    }
}
