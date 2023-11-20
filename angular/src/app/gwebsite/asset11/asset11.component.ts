import { ViewAsset11ModalComponent } from './view-asset11-modal.component';
import {
    AfterViewInit,
    Component,
    ElementRef,
    Injector,
    OnInit,
    ViewChild
} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { Asset11ServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAsset11ModalComponent } from './create-or-edit-asset11-modal.component';

@Component({
    templateUrl: './asset11.component.html',
    animations: [appModuleAnimation()]
})
export class Asset11Component extends AppComponentBase
    implements AfterViewInit, OnInit {
    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal')
    createOrEditModal: CreateOrEditAsset11ModalComponent;
    @ViewChild('viewAsset11Modal') viewAsset11Modal: ViewAsset11ModalComponent;

    /**
     * tạo các biến dể filters
     */
    asset11Name: string;

    constructor(
        injector: Injector,
        private _asset11Service: Asset11ServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {}

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách Asset11
     * @param event
     */
    getAsset11s(event?: LazyLoadEvent) {
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

    reloadList(asset11Name, event?: LazyLoadEvent) {
        this._asset11Service
            .getAsset11sByFilter(
                asset11Name,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(
                    this.paginator,
                    event
                ),
                this.primengTableHelper.getSkipCount(this.paginator, event)
            )
            .subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    deleteAsset11(id): void {
        this._asset11Service.deleteAsset11(id).subscribe(() => {
            this.reloadPage();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.asset11Name = params['name'] || '';
            this.reloadList(this.asset11Name, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.asset11Name, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createAsset11() {
        this.createOrEditModal.show();
    }

    accountingAsset11() {
        this._asset11Service.accounting().subscribe(() => {
            this.reloadPage();
        });
    }

    depreciatingAsset11() {
        this._asset11Service.depreciating().subscribe(() => {
            this.reloadPage();
        });
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
