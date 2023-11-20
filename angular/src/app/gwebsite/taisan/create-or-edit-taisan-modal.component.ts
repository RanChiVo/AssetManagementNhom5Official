import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TaiSanServiceProxy, TaiSanInput } from '@shared/service-proxies/service-proxies';
    
@Component({
    selector: 'createOrEditTaiSanModal',
    templateUrl: './create-or-edit-taisan-modal.component.html'
})
export class CreateOrEditTaiSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('taisanCombobox') taisanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    taisan: TaiSanInput = new TaiSanInput();

    constructor(
        injector: Injector,
        private _taisanService: TaiSanServiceProxy
    ) {
        super(injector);
    }

    show(taisanId?: number | null | undefined): void {
        this.saving = false;


        this._taisanService.getTaiSanForEdit(taisanId).subscribe(result => {
            this.taisan = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.taisan;
        this.saving = true;
        this._taisanService.createOrEditTaiSan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
