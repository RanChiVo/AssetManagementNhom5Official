import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { RealEstateTypeServiceProxy, RealEstateTypeInput_9 } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditRealEstateTypeModal',
    templateUrl: './create-or-edit-real-estate-type.html'
})
export class CreateOrEditRealEstateTypeModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('RealEstateTypeCombobox') RealEstateTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    RealEstateType: RealEstateTypeInput_9 = new RealEstateTypeInput_9();

    constructor(
        injector: Injector,
        private _RealEstateTypeService: RealEstateTypeServiceProxy
    ) {
        super(injector);
    }

    show(customerId?: number | null | undefined): void {
        this.saving = false;


        this._RealEstateTypeService.getRealEstateTypeForEdit(customerId).subscribe(result => {
            this.RealEstateType = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.RealEstateType;
        this.saving = true;
        this._RealEstateTypeService.createOrEditRealEstateType(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
