import { ViewLoaiSoHuuModalComponent } from './view-loaisohuu-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { LoaiSoHuuServiceProxy, LoaiBatDongSanDto } from '@shared/service-proxies/service-proxies';
import { CreateOrEditLoaiSoHuuModalComponent } from './create-or-edit-loaisohuu-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    templateUrl: './loaisohuu.component.html',
    animations: [appModuleAnimation()]
})
export class LoaiSoHuuComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditLoaiSoHuuModalComponent;
    @ViewChild('viewLoaiSoHuuModal') viewLoaiSoHuuModal: ViewLoaiSoHuuModalComponent;

    /**
     * tạo các biến dể filters
     */
    loaisohuuName: string;
    Id: string;
    constructor(
        injector: Injector,
        private _loaisohuuService: LoaiSoHuuServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    public listItems: Array<LoaiBatDongSanDto> = [];
    public filters: {
        filterType: string,
        filterId: string,
        filterName: string,
        filterSymbol: string
    } = <any>{};

    public filterTypes: {
        filterTypeName: string,
    } = <any>{};

    getListTypes(): void {
        // get category type
        this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
            this.listItems = result.items;
        });
    }


    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.getListTypes();
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
     * Hàm get danh sách LoaiSoHuu
     * @param event
     */
    getLoaiSoHuus(event?: LazyLoadEvent) {
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

    reloadList(loaisohuuName, event?: LazyLoadEvent) {
        this._loaisohuuService.getLoaiSoHuusByFilter(loaisohuuName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteLoaiSoHuu(id): void {
        this._loaisohuuService.deleteLoaiSoHuu(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.loaisohuuName = params['name'] || '';
           
            this.reloadList(this.loaisohuuName, null);
        });
    }

    getId(): string {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.Id = params['Id'] || '';
        })
     return this.Id;
    };
    


    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.loaisohuuName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createLoaiSoHuu() {
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
