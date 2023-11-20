import { ViewTransferringAssetModalComponent } from './view-transferring-asset-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { TransferringAssetServiceProxy, SearchAssetInitData, GetCurrentLoginInformationsOutput, GetUserForEditOutput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './transferring-asset.component.html',
    animations: [appModuleAnimation()]
})
export class TransferringAssetComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    //@ViewChild('viewCustomerModal') viewCustomerModal: ViewTransferringAssetModalComponent;

    @ViewChild('IsCheckedCombobox') isCheckedCombobox: ElementRef;
    @ViewChild('TransferringDateUtc') transferringDateUtc: ElementRef;

    currentSession: GetCurrentLoginInformationsOutput = new GetCurrentLoginInformationsOutput();
    currentUser: GetUserForEditOutput = new GetUserForEditOutput();


    /**
     * tạo các biến dể filters
     */
    transferringDate: moment.Moment;
    assetId: string;
    assetName: string;
    receivingUnit: string;
    receivingUser: string;
    isChecked: boolean;
    id: number;

    constructor(
        injector: Injector,
        private _transferringAssetService: TransferringAssetServiceProxy,
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
            $(this.transferringDateUtc.nativeElement).datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });
            $(this.isCheckedCombobox.nativeElement).selectpicker('refresh');
            
            this.init();
        },0);
        
    }

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getTransferringAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(undefined,null,null,null,null,undefined, event);

    }

    reloadList(transferringDate: moment.Moment, assetId: string, assetName: string, receivingUnit: string, receivingUser: string, isChecked: boolean, event?: LazyLoadEvent) {
        this._transferringAssetService.getTransferringAssetsInAngular(transferringDate, assetId, assetName, receivingUnit, receivingUser, isChecked,
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
            this.transferringDate = params['transferringDate'] ;
            this.assetId = params['assetId'];
            this.assetName = params['assetName'];
            this.receivingUnit = params['receivingUnit'];
            this.receivingUser = params['receivingUser'];
            this.isChecked = params['isChecked'];
            this.id = params['id'];
            this.reloadList(this.transferringDate, this.assetId,
                this.assetName, this.receivingUnit, this.receivingUser,
                this.isChecked, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        if (this.transferringDateIsValid())
            this.transferringDate = moment($(this.transferringDateUtc.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ss') + 'Z');
        else
            this.transferringDate = undefined;

        if (this.isCheckedIsValid() == false) {
            this.isChecked = undefined;
        }

        this.reloadList(this.transferringDate, this.assetId,
            this.assetName, this.receivingUnit, this.receivingUser,
            this.isChecked, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    transferringDateIsValid(): boolean {
        if (!this.transferringDateUtc) {
            return false;
        }
        let transferringDateUtc = $(this.transferringDateUtc.nativeElement).val();
        return transferringDateUtc !== undefined && transferringDateUtc !== '';
    }

    isCheckedIsValid(): boolean {
        if (!this.isCheckedCombobox) {
            return false;
        }
        let isCheckedCombobox = $(this.isCheckedCombobox.nativeElement).val();
        return isCheckedCombobox !== undefined && isCheckedCombobox !== '';
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
