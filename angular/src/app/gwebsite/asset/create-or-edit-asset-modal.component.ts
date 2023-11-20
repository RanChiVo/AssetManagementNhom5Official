import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import * as moment from 'moment';
import { DatePipe } from '@angular/common';
import {
    AssetController_05ServiceProxy, AssetTypeControler_05ServiceProxy,
    AssetGroupInput_05, AssetTypeDto_05, PagedResultDtoOfAssetTypeDto_05, AssetTypeViewDto_05,
    AssetDto_05, ComboboxItemDto
} from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';
import { MomentFormatPipe } from '@shared/utils/moment-format.pipe';
@Component({
    templateUrl: './create-or-edit-asset-modal.component.html',
    animations: [appModuleAnimation()],
})

export class CreateOrEditAssetModalComponent extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('assetTypeCombobox') assetTypeCombobox: ElementRef;
    @ViewChild('supplierCombobox') supplierCombobox: ElementRef;
    @ViewChild('dateAddedUtc') dateAddedUtc: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    dateAdded: moment.Moment;
    viewStatus: boolean = false;
    messageUpload: string;
    assetId: string = null;
    isReadOnly: boolean = false;
    imageURL: any;
    selected: string;
    asset: AssetDto_05 = new AssetDto_05();
    tempAssetGroupId = "";
    tempAssetTypeId = 1;
    fatherAssetGroup: AssetGroupInput_05 = new AssetGroupInput_05();
    assetType: AssetTypeDto_05 = new AssetTypeDto_05();
    assetGroups: ComboboxItemDto[] = [];
    assetTypes: ComboboxItemDto[] = [];
    suppliers: ComboboxItemDto[] = [];
    assetStatus = ["true", "false"];
    private _assetTypeService: AssetTypeControler_05ServiceProxy;

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private _assetService: AssetController_05ServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params) => {
            this.assetId = params["assetId"];
            this.isReadOnly = params["readOnly"]
            console.log("Is ReadOnly", this.isReadOnly);
        });
        this.reloadList(this.assetId);
        this.getAsset(this.assetId);
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            $(this.dateAddedUtc.nativeElement).datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

        }, 0);
    }

    dateAddedIsValid(): boolean {
        if (!this.dateAddedUtc) {
            return false;
        }
        let transferringDateUtc = $(this.dateAddedUtc.nativeElement).val();
        return transferringDateUtc !== undefined && transferringDateUtc !== '';
    }

    getAsset(assetId?: string | null | undefined): void {
        this.saving = false;
        this._assetService.getAssetEdit(assetId).subscribe(result => {
            this.asset = result.asset;
            this.assetGroups = result.assetGroups;
            this.assetTypes = result.assetTypes;
            this.suppliers = result.purchaseOders;
            this.imageURL = this.asset.linkofImage;
            setTimeout(() => {
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
                $(this.assetTypeCombobox.nativeElement).selectpicker('refresh');
                $(this.supplierCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    chooseImage(files: any) {
        var fileType = files[0].type;
        var fileReader = new FileReader();

        if (files.length === 0)
            return;

        if (fileType.match(/image\/*/) == null) {
            this.messageUpload = "This images is not supported!";
            return;
        }
        fileReader.readAsDataURL(files[0]);
        fileReader.onload = (_event) => {
            this.imageURL = fileReader.result;
        }
    }

    save(): void {
        this.asset.linkofImage = this.imageURL;
        this.asset.dateAdded = moment($(this.dateAddedUtc.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ss') + 'Z');
        let input = this.asset;
        this.saving = true;
        this._assetService.createOrEditAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
        });
        this._router.navigate(['/app/gwebsite/asset']);
    }

    init(): void {
        this.reloadList(this.asset.assetId);
    }

    getWarrantys(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }
        this.primengTableHelper.showLoadingIndicator();
        this.reloadList(this.assetId);
    }

    reloadList(assetId?: string | null | undefined) {
        this._assetService.getWarrantysForView(assetId
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.asset.assetId);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
}