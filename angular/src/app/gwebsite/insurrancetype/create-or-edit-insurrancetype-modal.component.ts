import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { InsurranceTypeServiceProxy, InsurranceTypeInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditInsurranceTypeModal',
    templateUrl: './create-or-edit-insurrancetype-modal.component.html'
})
export class CreateOrEditInsurranceTypeModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('insurrancTypeCombobox') insurranceTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    insurrancetype: InsurranceTypeInput = new InsurranceTypeInput();

    constructor(
        injector: Injector,
        private _insurrancetypeService: InsurranceTypeServiceProxy
    ) {
        super(injector);
    }

    show(insurrancetypeId?: number | null | undefined): void {
        this.saving = false;


        this._insurrancetypeService.getInsurranceTypeForEdit(insurrancetypeId).subscribe(result => {
            this.insurrancetype = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.insurrancetype;
        this.saving = true;
        this._insurrancetypeService.createOrEditInsurranceType(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
