import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Table } from 'primeng/components/table/table';
import { ConstructionServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditConstructionModalComponent } from './create-or-edit-construction.modal.component'; 
import { ViewConstructionModalComponent } from './view-construction.modal.component';
import { Paginator } from 'primeng/primeng';
import { ConstructionModalComponent } from './construction.modal.component';

@Component({
    templateUrl: './construction.component.html',
    animations: [appModuleAnimation()]
})
export class ConstructionComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEdit1ConstructionModal') createOrEdit1ConstructionModal: ConstructionModalComponent;
    @ViewChild('createOrEditConstructionModal') createOrEditConstructionModal: CreateOrEditConstructionModalComponent;
    @ViewChild('viewConstructionModal') viewConstructionModal: ViewConstructionModalComponent;

    /**
     * tạo các biến dể filters
     */
    MaCongTrinh: string;
    TenCongTrinh: string;
    MaKeHoach: string;
    NgayThucThiThucTe: string;

    constructor(
        injector: Injector,
        private _constructionService: ConstructionServiceProxy,
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
    getConstructions(event?: LazyLoadEvent) {
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

    reloadList(MaCT, TenCT, MaKH, NgayThucThiThucTe, event?: LazyLoadEvent) {
        this._constructionService.getConstructionsByFilter(MaCT, TenCT, MaKH, NgayThucThiThucTe, this.primengTableHelper.getSorting(this.dataTable),
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

    deleteConstruction(id): void {
        this._constructionService.deleteConstruction(id).subscribe(() => {
            this.reloadPage()
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaCongTrinh = params['MaCongTrinh'] || '';
            this.TenCongTrinh = params['TenCongTrinh'] || '';
            this.MaKeHoach = params['MaKeHoach'] || '';
            this.NgayThucThiThucTe = params['NgayThucThiThucTe'] || '';
            this.reloadList(this.MaCongTrinh, this.TenCongTrinh, this.MaKeHoach, this.NgayThucThiThucTe, null);
        });
    }

    

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaCongTrinh, this.TenCongTrinh, this.MaKeHoach, this.NgayThucThiThucTe, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createConstruction() {
        this.createOrEditConstructionModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
