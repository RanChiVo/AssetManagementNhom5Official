import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ContractorInput, ContractorServiceProxy } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditContractorModal',
    templateUrl: './create-or-edit-contractor-modal.component.html'
})
export class CreateOrEditContractorModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('contractorCombobox') contractorCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    public pBool = false;
    contractor: ContractorInput = new ContractorInput();

    constructor(
        injector: Injector,
        private _contractorService: ContractorServiceProxy
    ) {
        super(injector);
    }

    show(ID?: number | null | undefined): void {
        this.saving = false;


        this._contractorService.getContractorForEdit(ID).subscribe(result => {
            this.contractor = result;
            this.modal.show();

        })
    }

    save(): void {
        if (this.pBool) {
            this.close();
            return;
        }
        let input = this.contractor;
        this.saving = true;     
            this._contractorService.createOrEditContractor(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })     
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);

    }
}
