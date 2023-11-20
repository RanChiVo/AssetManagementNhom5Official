import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CongTrinhServiceProxy, CongTrinhInput } from '@shared/service-proxies/service-proxies';
    
@Component({
    selector: 'createOrEditCongTrinhModal',
    templateUrl: './create-or-edit-congtrinh-modal.component.html'
})
export class CreateOrEditCongTrinhModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('congtrinhCombobox') congtrinhCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    congtrinh: CongTrinhInput = new CongTrinhInput();

    dsCongtrinh: Array<CongTrinhInput>=[];

    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy
    ) {
        super(injector);
    }

    show(congtrinhId?: number | null | undefined): void {
        this.saving = false;


        this._congtrinhService.getCongTrinhForEdit(congtrinhId).subscribe(result => {
            this.congtrinh = result;
            this.modal.show();

        })
    }

    save(): void {
        // let input = this.congtrinh;
        // this.saving = true;
        // this._congtrinhService.createOrEditCongTrinh(input).subscribe(result => {
        //     this.notify.info(this.l('SavedSuccessfully'));
        //     this.close();
        // })
        this.close();
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
