import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SupplierServiceProxy, SupplierInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditNhaCungCapModal',
    templateUrl: './create-or-edit-nhacungcap-modal.component.html'
})
export class CreateOrEditNhaCungCapModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('nhacungcapCombobox') nhacungcapCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    nhacungcap: SupplierInput = new SupplierInput();

    constructor(
        injector: Injector,
        private _nhacungcapService: SupplierServiceProxy
    ) {
        super(injector);
    }

    show(nhacungcapId?: number | null | undefined): void {
        this.saving = false;


        this._nhacungcapService.getSupplierForEdit(nhacungcapId).subscribe(result => {
            this.nhacungcap = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.nhacungcap;
        this.saving = true;
        this._nhacungcapService.createOrEditSupplier(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
