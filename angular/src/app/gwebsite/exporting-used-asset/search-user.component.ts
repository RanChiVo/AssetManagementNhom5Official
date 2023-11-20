import { SearchAssetUnitDataOutput, SearchAssetUnitInitData, ComboboxItemDto, SearchAssetUserDataOutput } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, ElementRef, EventEmitter, Output, Input } from "@angular/core";
import { TransferringAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import * as moment from 'moment';


@Component({
    selector: 'searchUserComponent',
    templateUrl: './search-user.component.html'
})

export class SearchUserComponent extends AppComponentBase {

    @ViewChild('searchModal') modal: ModalDirective;

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    assetUserDataOutput: SearchAssetUserDataOutput = new SearchAssetUserDataOutput();

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<number> = new EventEmitter<number>();
    @Input() assetUnitIdFromUnitForm: number;

    /**
     * tạo các biến dể kiểm tra
     */
    saving = false;
    selectedUserId = 0;

    /**
     * tạo các biến dể filters
     */
    assetUnitId: number;
    assetUserId: number ;
    assetUserName: string;

    constructor(
        injector: Injector,
        private _transferringAssetService: TransferringAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    showModal(): void {
        this.saving = false;
        this.assetUnitId = this.assetUnitIdFromUnitForm;
        this.modal.show();
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
         // default date time picker
        setTimeout(() => {
            this.init();   
        });
    }
    
    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getAssetUsers(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.assetUnitId,null,null, event);
    }
    

    reloadList(assetUnitId: number, assetUserId: number, assetUserName: string, event?: LazyLoadEvent) {
        this._transferringAssetService.getAssetUsersInAngular(assetUnitId, assetUserId, assetUserName,
            this.primengTableHelper.getSorting(this.dataTable),
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
            this.assetUnitId = params['assetUnitId'] ;
            this.assetUserId = params['assetUserId'];
            this.assetUserName = params['assetUserName'];

            this.reloadList(this.assetUnitId, this.assetUserId,
                this.assetUserName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
    selectUser(userId: number): void {
        this.selectedUserId = userId;
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
       
        this.reloadList(this.assetUnitId, this.assetUserId,
            this.assetUserName, null);
           
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    acccept(): void {
        if (this.selectedUserId == 0)
            this.notify.warn(this.l('Select User Then Save'));
        else {
            this.saving = true;
            this.modal.hide();
            this.modalSave.emit(this.selectedUserId);
        }
    }

    close(): void {
        this.saving = true;
        this.modal.hide();
        this.modalSave.emit(null);
    }


    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }























}
