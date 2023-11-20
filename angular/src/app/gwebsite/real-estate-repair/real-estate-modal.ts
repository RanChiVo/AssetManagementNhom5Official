import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { RealEstateServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'realEstateModal',
    templateUrl: './real-estate-modal.html',
    animations: [appModuleAnimation()]
})
export class RealEstateModalComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('realEstateModal') modal: ModalDirective;
    /**
     * tạo các biến dể filters
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    public pID: number;
    public flag1 = false;

    MaBatDongSan: string;

    constructor(
        injector: Injector,
        private _realEstateService: RealEstateServiceProxy,
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
    getRealEstates(event?: LazyLoadEvent) {
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

    reloadList(MaBatDongSan, event?: LazyLoadEvent) {
        this._realEstateService.getRealEstatesByFilter(null, MaBatDongSan ,null,null, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }



    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaBatDongSan = params['MaBatDongSan'] || '';
            this.reloadList(this.MaBatDongSan, null);
        });
    }



    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaBatDongSan, null);


    }
    selectionMBDS(id): void {
        this.pID = id;
        this.flag1 = true;
        close();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    show(): void {
        this.modal.show();
    }
    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
