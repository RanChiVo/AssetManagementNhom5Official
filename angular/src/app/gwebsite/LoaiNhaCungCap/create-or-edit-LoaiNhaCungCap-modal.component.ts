/*import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LoaiNhaCungCapServiceProxy, LoaiNhaCungCapInput } from '@shared/service-proxies/service-proxies';


    @Component({
        selector: 'createOrEditLoaiNhaCungCapModal',
        templateUrl: './create-or-edit-LoaiNhaCungCap-modal.component.html'
    })
    export class CreateOrEditLoaiNhaCungCapModalComponent extends AppComponentBase {


        @ViewChild('createOrEditModal') modal: ModalDirective;
        @ViewChild('loaiNhaCungCapCombobox') loaiNhaCungCapCombobox: ElementRef;
        @ViewChild('iconCombobox') iconCombobox: ElementRef;
        @ViewChild('dateInput') dateInput: ElementRef;

 //@Output dùng để public event cho component khác xử lý
        
        @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

        saving = false;

        loaiNhaCungCap: LoaiNhaCungCapInput = new LoaiNhaCungCapInput();

        constructor(
            injector: Injector,
            private _loaiNhaCungCapService: LoaiNhaCungCapServiceProxy
        ) {
            super(injector);
        }

        show(loaiNhaCungCapId?: number | null | undefined): void {
            this.saving = false;


            this._loaiNhaCungCapService.getLoaiNhaCungCapForEdit(loaiNhaCungCapId).subscribe(result => {
                this.loaiNhaCungCap = result;
                this.modal.show();

            })
        }

        save(): void {
            let input = this.loaiNhaCungCap;
            this.saving = true;
            this._loaiNhaCungCapService.createOrEditLoaiNhaCungCap(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })

        }

        close(): void {
            this.modal.hide();
            this.modalSave.emit(null);
        }
    }*/
import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LoaiNhaCungCapServiceProxy, LoaiNhaCungCapInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditLoaiNhaCungCapModal',
    templateUrl: './create-or-edit-LoaiNhaCungCap-modal.component.html'
})
export class CreateOrEditLoaiNhaCungCapModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('LoaiNhaCungCapCombobox') LoaiNhaCungCapCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    loaiNhaCungCap: LoaiNhaCungCapInput = new LoaiNhaCungCapInput();

    constructor(
        injector: Injector,
        private _loaiNhaCungCapService: LoaiNhaCungCapServiceProxy
    ) {
        super(injector);
    }

    show(loaiNhaCungCapId?: number | null | undefined): void {
        this.saving = false;


        this._loaiNhaCungCapService.getLoaiNhaCungCapForEdit(loaiNhaCungCapId).subscribe(result => {
            this.loaiNhaCungCap = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.loaiNhaCungCap;     
        this.saving = true;
        this._loaiNhaCungCapService.createOrEditLoaiNhaCungCap(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            console.log("thong tin luu vao"+input);
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
