import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Table } from 'primeng/components/table/table';
import { ConstructionServiceProxy, BidManagerServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/primeng';
import { CreateOrEditBidManagerModalComponent } from './create-or-edit-bid-manager-modal.component';
import { ViewBidManagerModalComponent } from './view-bid-manager-modal.componenet';


@Component({
    templateUrl: './bid-manager.component.html',
    animations: [appModuleAnimation()]
})
export class BidManagerComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditBidManagerModal') createOrEditBidManagerModal: CreateOrEditBidManagerModalComponent;
    @ViewChild('viewBidManagerModal') viewBidManagerModal: ViewBidManagerModalComponent;

    /**
     * tạo các biến dể filters
     */
    MaHoSoThau: string;
    HangMucThau: string;
    NgayNhanHSThau: string;
    NgayHetHanHSThau: string;
    HinhThucThau: string;
    MaCongTrinh: string;

    constructor(
        injector: Injector,
        private _bidManagerService: BidManagerServiceProxy,
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

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getBidManagers(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, null,null,null, event);

    }

    reloadList(MaHoSoThau, HangMucThau, NgayNhanHSThau, NgayHetHanHSThau, HinhThucThau,MaCongTrinh, event?: LazyLoadEvent) {
        this._bidManagerService.getBidManagersByFilter(MaHoSoThau, HangMucThau, NgayNhanHSThau, NgayHetHanHSThau, HinhThucThau,MaCongTrinh, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    deleteBidManager(id): void {
        this._bidManagerService.deleteBidManager(id).subscribe(() => {
            this.reloadPage()
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaHoSoThau = params['MaHoSoThau'] || '';
            this.HangMucThau = params['HangMucThau'] || '';
            this.NgayNhanHSThau = params['NgayNhanHSThau'] || '';
            this.NgayHetHanHSThau = params['NgayHetHanHSThau'] || '';
            this.HinhThucThau = params['HinhThucThau'] || '';
            this.MaCongTrinh = params['MaCongTrinh'] || '';
            this.reloadList(this.MaHoSoThau, this.HangMucThau, this.NgayNhanHSThau, this.NgayHetHanHSThau, this.HinhThucThau, this.MaCongTrinh, null);
        });
    }



    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaHoSoThau, this.HangMucThau, this.NgayNhanHSThau, this.NgayHetHanHSThau, this.HinhThucThau, this.MaCongTrinh, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createBidManager() {
        this.createOrEditBidManagerModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
