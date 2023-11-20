import { ViewNhomTaiSanModalComponent } from './view-nhomtaisan-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { NhomTaiSanServiceProxy, LoaiBatDongSanDto } from '@shared/service-proxies/service-proxies';
import { CreateOrEditNhomTaiSanModalComponent } from './create-or-edit-nhomtaisan-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    templateUrl: './nhomtaisan.component.html',
    animations: [appModuleAnimation()]
})
export class NhomTaiSanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditNhomTaiSanModalComponent;
    @ViewChild('viewNhomTaiSanModal') viewNhomTaiSanModal: ViewNhomTaiSanModalComponent;

    /**
     * tạo các biến dể filters
     */
    nhomtaisanName: string;
    Id: string;
    constructor(
        injector: Injector,
        private _nhomtaisanService: NhomTaiSanServiceProxy,
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
     * Hàm get danh sách NhomTaiSan
     * @param event
     */
    getNhomTaiSans(event?: LazyLoadEvent) {
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

    reloadList(nhomtaisanName, event?: LazyLoadEvent) {
        this._nhomtaisanService.getNhomTaiSansByFilter(nhomtaisanName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteNhomTaiSan(id): void {
        this._nhomtaisanService.deletePropertyGroup(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.nhomtaisanName = params['name'] || '';
           
            this.reloadList(this.nhomtaisanName, null);
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
        this.reloadList(this.nhomtaisanName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createNhomTaiSan() {
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
