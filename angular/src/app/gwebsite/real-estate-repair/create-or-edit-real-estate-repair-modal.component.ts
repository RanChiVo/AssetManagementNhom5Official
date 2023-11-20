import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RealEstateRepairServiceProxy, RealEstateRepairInput_9, RealEstateServiceProxy, RealEstateInput_9 } from '@shared/service-proxies/service-proxies';
import { RealEstateModalComponent } from './real-estate-modal';
import { Paginator } from 'primeng/primeng';


@Component({
    selector: 'createOrEditRealEstateRepairModal',
    templateUrl: './create-or-edit-real-estate-repair-modal.component.html'
})
export class CreateOrEditRealEstateRepairModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('realEstateRepairCombobox') realEstateRepairCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('realEstateModal') realEstateModal: RealEstateModalComponent;
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

    showRealEstate(): void {
        this.realEstateModal.show()
    }

    reloadRealEstate(): void {
        this._realEstateService.getRealEstateForEdit(this.realEstateModal.pID).subscribe(result => {
            this.realEstateRepair.maTaiSan = result.maTaiSan;
            this.realEstateRepair.tenTaiSan = result.tenTaiSan;

        })
    }

    save(): void {
        let input = this.realEstateRepair;
        input.trangThaiDuyet = "Đang chờ";
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
