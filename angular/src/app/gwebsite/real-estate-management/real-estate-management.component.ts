import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { WebApiServiceProxy, IFilter } from '@shared/service-proxies/webapi.service';
import { RealEstateServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditRealEstateModalComponent } from './create-or-edit-real-estate-management-modal.component';
import { PrimengTableHelper } from '@shared/helpers/PrimengTableHelper';
import { ViewRealEstateModalComponent } from './view-real-estate-management-modal.component';

@Component({
    templateUrl: './real-estate-management.component.html',
    animations: [appModuleAnimation()]
})
export class RealEstateManagementComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditRealEstateModalComponent;
    @ViewChild('viewRealEstateModal') viewRealEstateModal: ViewRealEstateModalComponent;
    /**
     * tạo các biến dể filters
     */


    
    MaTaiSan: string;       
    MaBatDongSan: string;
    MaLoaiBatDongSan: string;
    TinhTrangSuDung: string;


    constructor(
        injector: Injector,
        private _realEstateService: RealEstateServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy

    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.MaTaiSan = null,
            this.MaBatDongSan = null,
            this.MaLoaiBatDongSan = null,
            this.TinhTrangSuDung = null
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
     * Hàm get danh sách bất động sản
     * @param event
     */
    getRealEstates(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        
        this.reloadList(null, null, null, null, event);
    }
  

    reloadList(MaTaiSan, MaBatDongSan, MaLoaiBatDongSan, TinhTrangSuDung, event?: LazyLoadEvent) {
        this._realEstateService.getRealEstatesByFilter(MaTaiSan,  MaBatDongSan, MaLoaiBatDongSan, TinhTrangSuDung, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteRealEstate(id): void {
        this._realEstateService.deleteRealEstate(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaTaiSan = params['MaTaiSan'] || '';
            this.MaBatDongSan = params['MaBatDongSan'] || '';
            this.MaLoaiBatDongSan = params['MaLoaiBatDongSan'] || '';
            this.TinhTrangSuDung = params['TinhTrangSuDung'] || '';
            //reload lại gridview
            this.reloadList(this.MaTaiSan,  this.MaBatDongSan, this.MaLoaiBatDongSan, this.TinhTrangSuDung, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        this.reloadList(this.MaTaiSan, this.MaBatDongSan, this.MaLoaiBatDongSan, this.TinhTrangSuDung, null);
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createRealEstate() {
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







