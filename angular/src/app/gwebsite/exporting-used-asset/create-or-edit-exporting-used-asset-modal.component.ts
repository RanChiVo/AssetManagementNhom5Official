import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, ContentChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ExportingUsedAssetServiceProxy, ExportingUsedAssetInput, TransferringAssetServiceProxy, SearchAssetUnitDataOutput, SearchAssetUserDataOutput, AssetController_05ServiceProxy, AssetForViewDto_05 } from '@shared/service-proxies/service-proxies';
import { CustomerServiceProxy } from '@shared/service-proxies/service-proxies';
import { Logs } from 'selenium-webdriver';
import { Asset } from './asset';
import { AssetDashboardComponent } from '../asset-dashboard/asset-dashboard.component';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { v } from '@angular/core/src/render3';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // <== add the imports!
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { SearchUserComponent } from '../exporting-used-asset/search-user.component';
import { SearchUnitComponent } from '../exporting-used-asset/search-unit.component';
import { SearchAssetComponent2 } from '../exporting-used-asset/search-asset.component';
import { Router, ActivatedRoute } from '@angular/router';
import * as moment from 'moment';

@Component({
    selector: 'createOrEditExportingUsedAssetModal',
    templateUrl: './create-or-edit-exporting-used-asset-modal.component.html',
    animations: [appModuleAnimation()]
    //moi them vao
    //directives: [SearchAssetComponent]
})
export class CreateOrEditExportingUsedAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('exportingUsedAssetCombobox') exportingUsedAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('searchAsset') searchAsset: SearchAssetComponent2;
    @ViewChild('searchUnit') searchUnit: SearchUnitComponent;
    @ViewChild('searchUser') searchUser: SearchUserComponent;
    @ViewChild('TransferringDateUtc') transferringDateUtc: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    assetType: string;
    assetTypes = ['Tài sản cố định', 'Công cụ lao động'];
    assetTypesId: number;

    information: Asset[] = [];
    selectedAsset: Asset = new Asset(' ', ' ', 0, ' ');

    today: number;
    mytoday: string;

    now = moment();
    date: moment.Moment;

    saving = false;

    assetId: string;
    usingUnit: string;
    usingUser: string;

    exportingUsedAssetIdForEdit: number;

    exportingUsedAsset: ExportingUsedAssetInput = new ExportingUsedAssetInput();
    input: ExportingUsedAssetInput = new ExportingUsedAssetInput();
    asset: AssetForViewDto_05 = new AssetForViewDto_05();

    constructor(
        injector: Injector,
        private _exportingUsedAssetService: ExportingUsedAssetServiceProxy,
        private _transferringAssetService: TransferringAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _assetId: AssetController_05ServiceProxy,
        private _router: Router,
    ) {
        super(injector);
        this.selectedAsset.name = ' ';
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params) => {
            this.exportingUsedAssetIdForEdit = params["exportingUsedId"];
            if (this.exportingUsedAssetIdForEdit > 0) {
                this.saving = false;

                this._exportingUsedAssetService.getExportingUsedAssetForEdit(this.exportingUsedAssetIdForEdit).subscribe(result => {
                    this.exportingUsedAsset = result;
                    this.assetId = result.assetId;
                    this.getSelectedAsset();
                    this.exportingUsedAsset.usingUnit = result.usingUnit;
                    this.exportingUsedAsset.user = result.user;
                    this.date = result.exportingDay;
                    $(this.transferringDateUtc.nativeElement).datetimepicker({});
                    $(this.transferringDateUtc.nativeElement).data("DateTimePicker")
                        .date(result.beginningDateofDepreciation.format('DD/MM/YYYY'));
                });
            }
            else {
                this.exportingUsedAsset.exportingDay = this.now;
                setTimeout(() => {
                    $(this.transferringDateUtc.nativeElement).datetimepicker({
                        locale: abp.localization.currentLanguage.name,
                        format: 'L'
                    });
                }, 0);
            }
        });

    }

    usingUnit2: number;
    //Cac bien gui ve tu cac form search
    getUnit($event): void {
        if ($event != null) {
            this.usingUnit2 = $event;
            this._transferringAssetService.getAssetUnitDetailInAngular(this.usingUnit2)
                .subscribe(result => {
                    this.exportingUsedAsset.usingUnit = result.assetUnitName;
                })
        }
    }

    usingUser2: number;
    //Cac bien gui ve tu cac form search
    getUser($event): void {
        if ($event != null) {
            this.usingUser2 = $event;
            this._transferringAssetService.getAssetUserDetailInAngular(this.usingUser2)
                .subscribe(result => {
                    this.exportingUsedAsset.user = result.assetUserName;
                })
        }
    }


    showSearchUserModal(): void {
        if (this.exportingUsedAsset.usingUnit == null)
            this.notify.warn(this.l('Insert Using Unit First'));
        else
            this.searchUser.showModal();
    }


    // hàm listener searchasset và lấy id của tài sản được chọn truyền qua.
    notifyMessage($event): void {
        if ($event != null) {
            this.assetId = $event;
            this.notify.info(this.l('Lay tai san muon chon thanh cong' + $event));
            this.getSelectedAsset();
            this.exportingUsedAsset.assetId = $event;
        }
    }

    getSelectedAsset(): void {
        this._assetId.getAssetForView(this.assetId).subscribe(result => {
            this.selectedAsset.id = result.assetId;
            this.selectedAsset.name = result.name;
            this.selectedAsset.assetType = result.assetTypeId;
            this.selectedAsset.description = result.description;
            if (result.assetTypeId == 1)
                this.assetType = this.assetTypes[0];
            else
                this.assetType = this.assetTypes[1];


        })
    }
    transferringDateIsValid(): boolean {
        if (!this.transferringDateUtc) {
            return false;
        }
        let transferringDateUtc = $(this.transferringDateUtc.nativeElement).val();
        return transferringDateUtc !== undefined && transferringDateUtc !== '';
    }
    save(): void {
        if (!this.transferringDateIsValid())
            this.notify.warn(this.l('Insert Transferring Date Then Save'));
        else if (this.assetId == null)
            this.notify.warn(this.l('Select Asset By Clicking Asset List Then Save'));
        else if (this.exportingUsedAsset.usingUnit == null)
            this.notify.warn(this.l('Select Asset By Clicking Unit List Then Save'));
        else if (this.exportingUsedAsset.user == null)
            this.notify.warn(this.l('Select Asset By Clicking User List Then Save'));
        else {
            this.exportingUsedAsset.beginningDateofDepreciation = moment($(this.transferringDateUtc.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ss') + 'Z');
            let input = this.exportingUsedAsset;
            this._exportingUsedAssetService.createOrEditExportingUsedAsset(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            });
        }


    }

    close(): void {
        this._router.navigate(['/app/gwebsite/exporting-used-asset']);
    }

}
