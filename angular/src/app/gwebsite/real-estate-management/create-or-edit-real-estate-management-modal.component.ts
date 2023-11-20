import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RealEstateServiceProxy, RealEstateInput_9, AssetController_9ServiceProxy, AssetInput_9, ComboboxItemDto, RealEstateDto_9, AssetDto_9,  RealEstateTypeInput_9, RealEstateTypeServiceProxy, RealEstateTypeDto_9, } from '@shared/service-proxies/service-proxies';
import { Router, ActivatedRoute } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';
import { AssetComponent9 } from './asset-component';
import { Paginator } from 'primeng/primeng';


@Component({
    selector: 'createOrEditRealEstateModal',
    templateUrl: './create-or-edit-real-estate-management-modal.component.html'
})
export class CreateOrEditRealEstateModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('realEstateTypeCombobox') realEstateTypeCombobox: ElementRef;
    @ViewChild('tinhTrangSuDungCombobox') tinhTrangSuDungCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('assetModal') assetModal: AssetComponent9;

    /**
     * @Output dùng để public event cho component khác xử lý
     */

    flag: boolean = false;
    getId: number;
    selectedType: number;
    load: string;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    realEstateType: RealEstateTypeInput_9 = new RealEstateTypeInput_9();
    realEstateTypes: Array<RealEstateTypeDto_9> = [];
    realEstate: RealEstateInput_9 = new RealEstateInput_9();
    asset: AssetInput_9 = new AssetInput_9();


    constructor(
        injector: Injector,
        private _realEstateTypeService: RealEstateTypeServiceProxy,
        private _realEstateService: RealEstateServiceProxy,
        private _assetService: AssetController_9ServiceProxy,

        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
        this.getTypes();
    }

    getTypes(): void {
        // get category type
        this._apiService.get('api/RealEstateType/GetRealEstateTypesByFilter').subscribe(result => {
            this.realEstateTypes = result.items;
        });
    }

    onChangeType(): void {
        this._apiService.getForEdit('api/RealEstateType/GetRealEstateTypeForView', this.selectedType).subscribe(result => {
            this.realEstate.maLoaiBatDongSan = result.tenLoaiBatDongSan;
        });
    }

    show(realEstateId?: number | null | undefined): void {
        this.saving = false;
        this.flag = false;

        this._realEstateService.getRealEstateForEdit(realEstateId).subscribe(result => {
            this.realEstate = result;
            this.modal.show();
            setTimeout(() => {
                $(this.realEstateTypeCombobox.nativeElement).selectpicker('refresh');
            }, 0);

        })
        //this._buildingService.getBuildingForEdit(realEstateId).subscribe(result => {
        //    this.building = result;
        //})
        //this._land.getLandForEdit(realEstateId).subscribe(result => {
        //    this.land = result;
        //})
    }

    save(): void {
        let input1 = this.realEstate;
        
        this.saving = true;
        this._realEstateService.createOrEditRealEstate(input1).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    reloadAsset(): void {
            this._assetService.getAssetForEditWithMTS(this.assetModal.pmaTaiSan).subscribe(result => {
                this.asset = result;
                this.realEstate.maTaiSan = result.maTaiSan;
                this.realEstate.loaiTaiSan = result.loaiTaiSan;

            })
    }

    assetShow(): void {
        this.assetModal.show();
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    
}
