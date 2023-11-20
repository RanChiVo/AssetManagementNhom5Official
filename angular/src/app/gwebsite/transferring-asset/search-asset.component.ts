import { SearchAssetDataOutput, ComboboxItemDto } from '../../../shared/service-proxies/service-proxies';
import { SearchAssetInitData } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, ElementRef, EventEmitter, Output } from "@angular/core";
import { TransferringAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import * as moment from 'moment';



@Component({
    selector: 'searchAssetComponent',
    templateUrl: './search-asset.component.html'
})

export class SearchAssetComponent extends AppComponentBase {

    @ViewChild('searchModal') modal: ModalDirective;
    @ViewChild('DateAddedUtc') dateAddedUtc: ElementRef;

    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('assetTypeCombobox') assetTypeCombobox: ElementRef;
    @ViewChild('assetSupplierCombobox') assetSupplierCombobox: ElementRef;

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    assetDataOutput: SearchAssetDataOutput = new SearchAssetDataOutput();
    assetInitData: SearchAssetInitData = new SearchAssetInitData();

    dataAssetGroup: ComboboxItemDto[] = [];
    dataAssetType: ComboboxItemDto[] = [];
    dataAssetSupplier: ComboboxItemDto[] = [];
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<string> = new EventEmitter<string>() ;

    /**
     * tạo các biến dể kiểm tra
     */
    saving = false;
    selectedAssetId: string;

    /**
     * tạo các biến dể filters
     */

    assetTypeName: string;
    assetGroupName: string ;
    assetId: string;
    assetName: string;
    dateAdded: moment.Moment;
    supplier: string;
    loading = false;

    constructor(
        injector: Injector,
        private _transferringAssetService: TransferringAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    showModal(): void {
        this.saving = false;
        this._transferringAssetService.getAssetInitDataInAngular().subscribe(result => {
            this.assetInitData = result;
            this.dataAssetGroup = result.getAssetGroups;
            this.dataAssetType = result.getAssetTypes;
            this.dataAssetSupplier = result.getAssetSuppliers;
            this.modal.show();
            setTimeout(() => {
                // default date time picker
                $(this.dateAddedUtc.nativeElement).datetimepicker({
                    locale: abp.localization.currentLanguage.name,
                    format: 'L'
                });
                $(this.assetTypeCombobox.nativeElement).selectpicker('refresh');
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
                $(this.assetSupplierCombobox.nativeElement).selectpicker('refresh');
            },0);
        })
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
         
        setTimeout(() => {
            // default date time picker
            this.init();   
        });
    }

    /**
     * Hàm get danh sách Customer
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

        this.reloadList(null,null,null,null,undefined,null, event);
    }

    reloadList(assetTypeName: string, assetGroupName: string, assetId: string, assetName: string, dateAdded: moment.Moment, supplier: string, event?: LazyLoadEvent) {
        this._transferringAssetService.getAssetsInAngular(assetTypeName,assetGroupName,assetId,assetName,dateAdded,supplier,
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
            this.assetTypeName = params['assetTypeName'] ;
            this.assetGroupName = params['assetGroupName'];
            this.assetId = params['assetId'];
            this.assetName = params['assetName'];
            this.dateAdded = params['dateAdded'];
            this.supplier = params['supplier'];

            this.reloadList(this.assetTypeName, this.assetGroupName,
                this.assetId, this.assetName, this.dateAdded,
                this.supplier, null);
        });

    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
        
    }
    selectAsset(assetId:string): void {
        this.selectedAssetId = assetId;
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        if (this.dateAddedIsValid())
            this.dateAdded = moment($(this.dateAddedUtc.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ss') + 'Z');
        else
            this.dateAdded = undefined;
        this.reloadList(this.assetTypeName, this.assetGroupName,
            this.assetId, this.assetName, this.dateAdded,
            this.supplier, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }

    }

    dateAddedIsValid(): boolean {
        if (!this.dateAddedUtc) {
            return false;
    }
        let dateAddedUtc = $(this.dateAddedUtc.nativeElement).val();
        return dateAddedUtc !== undefined && dateAddedUtc !== '';
    }

    acccept(): void {
        if (this.selectedAssetId == null)
            this.notify.warn(this.l('Select Asset Then Save'));
        else {
            this.saving = true;
            this.modal.hide();
            this.modalSave.emit(this.selectedAssetId);
        }
    }

    close(): void {
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
