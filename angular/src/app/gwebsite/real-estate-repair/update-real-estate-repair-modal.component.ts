import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RealEstateRepairServiceProxy, RealEstateRepairInput_9, RealEstateServiceProxy, RealEstateInput_9 } from '@shared/service-proxies/service-proxies';
import { RealEstateModalComponent } from './real-estate-modal';
import { Paginator } from 'primeng/primeng';


@Component({
    selector: 'updateRealEstateRepairModal',
    templateUrl: './update-real-estate-repair-modal.component.html'
})
export class UpdateRealEstateRepairModalComponent extends AppComponentBase {


    @ViewChild('updateRealEstateRepairModal') modal: ModalDirective;
    @ViewChild('realEstateRepairCombobox') realEstateRepairCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('paginator') paginator: Paginator;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    realEstateRepair: RealEstateRepairInput_9 = new RealEstateRepairInput_9();
    realEstate: RealEstateInput_9 = new RealEstateInput_9();

    constructor(
        injector: Injector,
        private _realEstateRepairService: RealEstateRepairServiceProxy,
        private _realEstateService: RealEstateServiceProxy
    ) {
        super(injector);
    }

    show(realEstateRepairId?: number | null | undefined): void {
        this.saving = false;

        this._realEstateRepairService.getRealEstateRepairForEdit(realEstateRepairId).subscribe(result => {
            this.realEstateRepair = result;
            this._realEstateService.getRealEstateForEditWithMTS(this.realEstateRepair.maTaiSan).subscribe(result => {
                this.realEstate = result;

            })
            this.modal.show();
        })
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }



    save(): void {
        let input = this.realEstateRepair;
        this.saving = true;
        this._realEstateRepairService.createOrEditRealEstateRepair(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }


}
