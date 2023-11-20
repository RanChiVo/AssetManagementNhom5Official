import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { AssetController_05ServiceProxy } from '@shared/service-proxies/service-proxies';
import { Asset } from './asset';
import { ModalDirective } from 'ngx-bootstrap';
import { Moment } from 'moment';

@Component({
    selector: 'searchAssetComponent2',
    templateUrl: './search-asset.component.html',
})

export class SearchAssetComponent2 extends AppComponentBase {

    @ViewChild('searchModal') public modal: ModalDirective;
    @ViewChild('exportingUsedAssetCombobox') exportingUsedAssetCombobox: ElementRef;

    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() sendSelectedAssetIdEvent: EventEmitter<string> = new EventEmitter<string>();

    assetTypes = ['Tài sản cố định', 'Công cụ lao động'];
    info: string[] = ['aksldhalksfd'];
    infoofAsset: string[] = [' '];

    // Tạo các biến để filter
    assetName: string;

    saving = false;

    selectedAssetId: string;

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _assetService: AssetController_05ServiceProxy
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
            this.saving = false;
            this.init();
        });
    }

    /**
     * Hàm get danh sách Assets
     * @param event
     */
    getAssets(event?: LazyLoadEvent) {
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


    reloadList(assetName, event?: LazyLoadEvent) {
        this._assetService.getAssetsByFilter(assetName, this.primengTableHelper.getSorting(this.dataTable),
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
            this.assetName = params['name'] || '';
            this.reloadList(this.assetName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.assetName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    showModal(): void {
        this.saving = false;
        this.modal.show();
    }

    /**
    * Hàm xử lý sau khi View được init
    */
    acccept(): void {
        if (this.selectedAssetId == null)
            this.notify.warn(this.l('Select Asset Then Save'));
        else {
            this.saving = true;
            this.sendSelectedAssetIdEvent.emit(this.selectedAssetId);
            this.modal.hide();
        }
    }

    getIdofSelectedAsset(value: string): void {

        this.selectedAssetId = value;
    }

    close(): void {
        this.modal.hide();
    }
    /**
    * Tạo pipe thay vì tạo từng hàm truncate như thế này
    * @param text
    */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
