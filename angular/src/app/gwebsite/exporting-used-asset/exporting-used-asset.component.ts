import { ViewExportingUsedAssetModalComponent } from './view-exporting-used-asset-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ExportingUsedAssetServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditExportingUsedAssetModalComponent } from './create-or-edit-exporting-used-asset-modal.component';

@Component({
    templateUrl: './exporting-used-asset.component.html',
    animations: [appModuleAnimation()]
})
export class ExportingUsedAssetComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditExportingUsedAssetModalComponent;
    @ViewChild('viewExportingUsedAssetModal') viewExportingUsedAssetModal: ViewExportingUsedAssetModalComponent;

    /**
     * tạo các biến dể filters
     */
    exportingUsedAssetName: string;
    exportingUsedAssetUsingUnit: number;
    exportingUsedAssetUser: string;
    exportingUsedAssetExportingDay: string;

    date: string;
    constructor(
        injector: Injector,
        private _exportingUsedAssetService: ExportingUsedAssetServiceProxy,
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
     * Hàm get danh sách ExportingUsedAsset
     * @param event
     */
    getExportingUsedAssets(event?: LazyLoadEvent) {
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


    reloadList(ExportingUsedAssetName, ExportingUsedAssetUsingUnit, ExportingUsedAssetExportingDay, ExportingUsedAssetUser, event?: LazyLoadEvent) {
        this._exportingUsedAssetService.getExportingUsedAssetsByFilter(ExportingUsedAssetName, ExportingUsedAssetUsingUnit, 
            ExportingUsedAssetExportingDay, ExportingUsedAssetUser,
             this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteExportingUsedAsset(id): void {
        this._exportingUsedAssetService.deleteExportingUsedAsset(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.exportingUsedAssetName = params['name'] || '';
            this.exportingUsedAssetUsingUnit = params['usingUnit'] || '';
            this.exportingUsedAssetExportingDay = params['exportingDay'] || '';
            this.exportingUsedAssetUser = params['user'] || '';
            this.reloadList(this.exportingUsedAssetName, this.exportingUsedAssetUsingUnit,
                this.exportingUsedAssetExportingDay, this.exportingUsedAssetUser, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.exportingUsedAssetName, this.exportingUsedAssetUsingUnit,
            this.exportingUsedAssetExportingDay, this.exportingUsedAssetUser, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
