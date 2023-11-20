import { SearchAssetComponent } from './search-asset.component';
import { SearchUnitComponent } from './search-unit.component';
import { SearchUserComponent } from './search-user.component';
import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ModalDirective } from 'ngx-bootstrap';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { TransferringAssetServiceProxy, TransferringAssetDataInput, TransferringAssetDataOutputForInput, SearchAssetUserDataOutput, SearchAssetUnitDataOutput } from '@shared/service-proxies/service-proxies';
import { DatePipe } from '@angular/common';
import * as moment from 'moment';


@Component({
    templateUrl: './create-or-edit-transferring-asset-modal.component.html',
    animations: [appModuleAnimation()],
    providers: [DatePipe]//getcurrent date
})
export class CreateOrEditTransferringAssetModalComponent extends AppComponentBase{


    @ViewChild('TransferringDateUtc') transferringDateUtc: ElementRef;
    @ViewChild('searchAsset') searchAsset: SearchAssetComponent;
    @ViewChild('searchUnit') searchUnit: SearchUnitComponent;
    @ViewChild('searchUser') searchUser: SearchUserComponent;

    //Cac bien de tao moi du lieu
    transferringDate: moment.Moment;
    assetId: string;
    isChecked = false;//Kiem duyet se nam trong phan view voi permission la admin
    receivingUnit: number;
    receivingUser: number;
    usingUnit: number;
    usingUser: number;
    note: string;
    attachingFileName: string;
    exportingDayString: string;
    exportingDayEndString: string;
    transferringAssetIdForEdit = 0;
    ischeck = false;

    saving = false;
    dataInput: TransferringAssetDataInput = new TransferringAssetDataInput();

    dataOutputForInput: TransferringAssetDataOutputForInput = new TransferringAssetDataOutputForInput();
    assetUserDataOutput: SearchAssetUserDataOutput = new SearchAssetUserDataOutput();
    assetUnitDataOutput: SearchAssetUnitDataOutput = new SearchAssetUnitDataOutput();

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    

    constructor(
        injector: Injector,
        private _transferringAssetService: TransferringAssetServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
    ) {
            super(injector);
    }


    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params) => {
            this.transferringAssetIdForEdit = params["transferringAssetId"];
            if (this.transferringAssetIdForEdit > 0) {
                this.ischeck = true;
                this._transferringAssetService.getTransferringAssetForEditInAngular(this.transferringAssetIdForEdit)
                    .subscribe(result => {
                        this.dataInput = result;
                        this.note = result.note;
                        this.attachingFileName = result.attachingFileName;
                        this.transferringDate = result.transferringDate;
                        this.getAsset(result.assetId);
                        this.getUser(result.receivingUser);
                        this.getUnit(result.receivingUnit);
                        $(this.transferringDateUtc.nativeElement).datetimepicker({});
                        $(this.transferringDateUtc.nativeElement).data("DateTimePicker")
                            .date(result.transferringDate.format('DD/MM/YYYY'));
                    })
            }
            else {
                setTimeout(() => {
                    $(this.transferringDateUtc.nativeElement).datetimepicker({
                        locale: abp.localization.currentLanguage.name,
                        format: 'L'
                    });
                }, 0);

            }
        });
        
    }

    checkAsset() {
        if (this.ischeck == false)
            this.notify.info(this.l('Cannot check while create'));
        else {
            if (this.isChecked == false) {
                this.notify.success(this.l('Checked'));
                this.isChecked = true;
            }
        }
    }
    
    ngAfterViewInit(): void {
    }


    init(): void {

        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.transferringDate = params['transferringDate'];
            this.assetId = params['assetId'];
            this.isChecked = params['isChecked'];
            this.receivingUnit = params['receivingUnit'];
            this.receivingUser = params['receivingUser'];
            this.usingUnit = params['usingUnit'];
            this.usingUser = params['usingUser'];
            this.note = params['note'];
            this.attachingFileName = params['attachingFileName'];
        });
    }
    showSearchUserModal(): void {
        if (this.receivingUnit == null)
            this.notify.warn(this.l('Insert Receiving Unit First'));
        else
            this.searchUser.showModal();
    }

    //Cac bien gui ve tu cac form search
    getAsset($event): void {
        if ($event != null) {
            this.assetId = $event;
            this._transferringAssetService.getTransferringAssetDetailForInputInAngular(this.assetId)
                .subscribe(result => {
                    this.dataOutputForInput = result;
                    this.usingUnit = result.usingUnitID;
                    this.usingUser = result.usingUserID;
                    this.exportingDayString = result.exportingDay.format("DD/MM/YYYY").toString();
                    this.exportingDayEndString = result.exportingDayEnd.format("DD/MM/YYYY").toString();
                });
        }
            
            
    }

    //Cac bien gui ve tu cac form search
    getUnit($event): void {
        if ($event != null)
        {
            this.receivingUnit = $event;
            this._transferringAssetService.getAssetUnitDetailInAngular(this.receivingUnit)
                .subscribe(result => {
                    this.assetUnitDataOutput = result;
                })
        }
    }

    //Cac bien gui ve tu cac form search
    getUser($event): void {
        if ($event != null)
        {
            this.receivingUser = $event;
            this._transferringAssetService.getAssetUserDetailInAngular(this.receivingUser)
                .subscribe(result => {
                    this.assetUserDataOutput = result;
                })
        }
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
        else if (this.receivingUnit == null)
            this.notify.warn(this.l('Select Asset By Clicking Unit List Then Save'));
        else if (this.receivingUser == null)
            this.notify.warn(this.l('Select Asset By Clicking User List Then Save'));
        else {
            this.saving = true;
            this.dataInput.id = this.transferringAssetIdForEdit;
            this.dataInput.assetId = this.assetId;
            this.dataInput.isChecked = this.isChecked;
            this.dataInput.receivingUnit = this.receivingUnit;
            this.dataInput.receivingUser = this.receivingUser;
            this.dataInput.usingUnit = this.usingUnit;//Unit
            this.dataInput.usingUser = this.usingUser;//User
            this.dataInput.note = this.note;
            this.dataInput.attachingFileName = this.attachingFileName;
            this.dataInput.transferringDate = moment($(this.transferringDateUtc.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ss') + 'Z');
            this._transferringAssetService.createOrEditTransferringAssetInAngular(this.dataInput).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));

            });
            this._router.navigate(['/app/gwebsite/transferring-asset']);
        }

    }
}   
