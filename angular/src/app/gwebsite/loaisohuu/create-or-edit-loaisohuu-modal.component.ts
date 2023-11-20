import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LoaiSoHuuServiceProxy, LoaiSoHuuInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditLoaiSoHuuModal',
    templateUrl: './create-or-edit-loaisohuu-modal.component.html'
})
export class CreateOrEditLoaiSoHuuModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('loaisohuuCombobox') loaisohuuCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    loaisohuu: LoaiSoHuuInput = new LoaiSoHuuInput();

    constructor(
        injector: Injector,
        private _loaisohuuService: LoaiSoHuuServiceProxy
    ) {
        super(injector);
    }

    show(loaisohuuId?: number | null | undefined): void {
        this.saving = false;


        this._loaisohuuService.getLoaiSoHuuForEdit(loaisohuuId).subscribe(result => {
            this.loaisohuu = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.loaisohuu;
        this.saving = true;
        this._loaisohuuService.createOrEditLoaiSoHuu(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
