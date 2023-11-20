import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { GoodsServiceProxy, GoodsInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditHangHoaModal',
    templateUrl: './create-or-edit-hanghoa-modal.component.html'
})
export class CreateOrEditHangHoaModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hanghoaCombobox') hanghoaCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hanghoa: GoodsInput = new GoodsInput();

    constructor(
        injector: Injector,
        private _hanghoaService: GoodsServiceProxy
    ) {
        super(injector);
    }

    show(hanghoaId?: number | null | undefined): void {
        this.saving = false;


        this._hanghoaService.getGoodsForEdit(hanghoaId).subscribe(result => {
            this.hanghoa = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.hanghoa;
        this.saving = true;
        this._hanghoaService.createOrEditGoods(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
