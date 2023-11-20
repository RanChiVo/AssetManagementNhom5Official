import { SearchAssetUnitDataOutput, SearchAssetUnitInitData, ComboboxItemDto } from '../../../shared/service-proxies/service-proxies';
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
    selector: 'searchUnitComponent',
    templateUrl: './search-unit.component.html'
})

export class SearchUnitComponent extends AppComponentBase {

    @ViewChild('searchModal') modal: ModalDirective;

    @ViewChild('assetRegionCombobox') assetRegionCombobox: ElementRef;
    @ViewChild('assetFatherCombobox') assetFatherCombobox: ElementRef;

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    assetUnitDataOutput: SearchAssetUnitDataOutput = new SearchAssetUnitDataOutput();
    assetUnitInitData: SearchAssetUnitInitData = new SearchAssetUnitInitData();

    dataAssetRegion: ComboboxItemDto[] = [];
    dataAssetFather: ComboboxItemDto[] = [];
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<number> = new EventEmitter<number>();

    /**
     * tạo các biến dể kiểm tra
     */
    saving = false;
    selectedUnitId = 0;
    initData2: string;

    /**
     * tạo các biến dể filters
     */

    assetRegionName: string;
    assetFatherName: string ;
    assetUnitName: string;
    assetRegion: number;

    constructor(
        injector: Injector,
        private _transferringAssetService: TransferringAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    showModal(): void {
        this.saving = false;
        this._transferringAssetService.getAssetUnitInitDataInAngular(this.assetRegion).subscribe(result => {
            this.assetUnitInitData = result;
            this.dataAssetRegion = result.getAssetRegions;
            this.dataAssetFather = result.getAssetFathers;
            this.modal.show();
            setTimeout(() => {
                $(this.assetRegionCombobox.nativeElement).selectpicker('refresh');
                $(this.assetFatherCombobox.nativeElement).selectpicker('refresh');
            },0);
        })
    }

    reloadComboboxFather() {
        this.assetRegion = parseInt($(this.assetRegionCombobox.nativeElement).val().toString());
        if (Number.isInteger(this.assetRegion)) {
            this._transferringAssetService.getAssetUnitInitDataInAngular(this.assetRegion).subscribe(result => {
                this.assetUnitInitData = result;
                this.dataAssetFather = result.getAssetFathers;
                setTimeout(() => {
                    $(this.assetFatherCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }
        else {
            this._transferringAssetService.getAssetUnitInitDataInAngular(null).subscribe(result => {
                this.assetUnitInitData = result;
                this.dataAssetFather = result.getAssetFathers;
                setTimeout(() => {
                    $(this.assetFatherCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }


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
    getAssetUnits(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null, event);
    }


    reloadList(assetFatherName: string, assetUnitName: string, event?: LazyLoadEvent) {
        this._transferringAssetService.getAssetUnitsInAngular(assetFatherName, assetUnitName,
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
            //this.assetRegionName = params['assetRegionName'] ;
            this.assetFatherName = params['assetFatherName'];
            this.assetUnitName = params['assetUnitName'];

            this.reloadList(this.assetFatherName,
                 this.assetUnitName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
    selectUnit(unitId: number): void {
        this.selectedUnitId = unitId;
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
       
        this.reloadList(this.assetFatherName,
            this.assetUnitName, null);
           
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    acccept(): void {
        if (this.selectedUnitId == 0)
            this.notify.warn(this.l('Select Unit Then Save'));
        else {
            this.saving = true;
            this.modal.hide();
            this.modalSave.emit(this.selectedUnitId);
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
