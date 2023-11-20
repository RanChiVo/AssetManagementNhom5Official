import { ViewPhieuGoiHangModalComponent } from './view-phieugoihang-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { GoodsInvoiceServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditPhieuGoiHangModalComponent } from './create-or-edit-phieugoihang-modal.component';

@Component({
    templateUrl: './phieugoihang.component.html',
    animations: [appModuleAnimation()]
})
export class PhieuGoiHangComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditPhieuGoiHangModalComponent;
    @ViewChild('viewPhieuGoiHangModal') viewPhieuGoiHangModal: ViewPhieuGoiHangModalComponent;

    /**
     * tạo các biến dể filters
     */
    phieugoihangName: string;

    constructor(
        injector: Injector,
        private _phieugoihangService: GoodsInvoiceServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
        this.ngAfterViewInit();
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

    /**
     * Hàm get danh sách PhieuGoiHang
     * @param event
     */
    getPhieuGoiHangs(event?: LazyLoadEvent) {
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

    reloadList(phieugoihangName, event?: LazyLoadEvent) {
        this._phieugoihangService.getGoodsInvoicesByFilter(phieugoihangName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deletePhieuGoiHang(id): void {
        this._phieugoihangService.deleteGoodsInvoice(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.phieugoihangName = params['tenphieugoihang'] || '';
            this.reloadList(this.phieugoihangName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.phieugoihangName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createPhieuGoiHang() {
        this.createOrEditModal.show();
    }


    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
