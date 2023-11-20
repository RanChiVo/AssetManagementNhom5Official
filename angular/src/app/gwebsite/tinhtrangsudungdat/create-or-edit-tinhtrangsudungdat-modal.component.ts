import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TinhTrangSuDungDatServiceProxy, TinhTrangSuDungDatInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditTinhTrangSuDungDatModal',
    templateUrl: './create-or-edit-tinhtrangsudungdat-modal.component.html'
})
export class CreateOrEditTinhTrangSuDungDatModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('tinhtrangsudungdatCombobox') tinhtrangsudungdatCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    tinhtrangsudungdat: TinhTrangSuDungDatInput = new TinhTrangSuDungDatInput();

    constructor(
        injector: Injector,
        private _tinhtrangsudungdatService: TinhTrangSuDungDatServiceProxy
    ) {
        super(injector);
    }

    show(tinhtrangsudungdatId?: number | null | undefined): void {
        this.saving = false;


        this._tinhtrangsudungdatService.getTinhTrangSuDungDatForEdit(tinhtrangsudungdatId).subscribe(result => {
            this.tinhtrangsudungdat = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.tinhtrangsudungdat;
        this.saving = true;
        this._tinhtrangsudungdatService.createOrEditTinhTrangSuDungDat(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
