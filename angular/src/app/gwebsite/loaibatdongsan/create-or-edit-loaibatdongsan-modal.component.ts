import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LoaiBatDongSanServiceProxy, LoaiBatDongSanInput } from '@shared/service-proxies/service-proxies';
import { BatDongSanDTO } from '../batdongsan/dto/batdongsandto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';


@Component({
    selector: 'createOrEditLoaiBatDongSanModal',
    templateUrl: './create-or-edit-loaibatdongsan-modal.component.html'
})


export class CreateOrEditLoaiBatDongSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('loaibatdongsanCombobox') loaibatdongsanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    selectedBDS: number;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    loaibatdongsan: LoaiBatDongSanInput = new LoaiBatDongSanInput();

   



    constructor(
        injector: Injector,
        private _loaibatdongsanService: LoaiBatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
       
    }










 

    show(loaibatdongsanId?: number | null | undefined): void {
        this.saving = false;


        this._loaibatdongsanService.getLoaiBatDongSanForEdit(loaibatdongsanId).subscribe(result => {
            this.loaibatdongsan = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.loaibatdongsan;
        this.saving = true;
        this._loaibatdongsanService.createOrEditLoaiBatDongSan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
