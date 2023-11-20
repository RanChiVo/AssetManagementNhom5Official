import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectKeHoachXayDungModalComponent } from '../kehoachxaydung/select-kehoachxaydung-modal.component';
import { HoSoThauN13Input, HoSoThauN13ServiceProxy } from '@shared/service-proxies/service-proxies';
    
@Component({
    selector: 'createHoSoThauN13Modal',
    templateUrl: './create-hosothau13-modal.component.html'
})
export class CreateHoSoThauN13ModalComponent extends AppComponentBase {


    @ViewChild('createModal') modal: ModalDirective;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


     
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hosothau: HoSoThauN13Input = new HoSoThauN13Input();

    dsCongtrinh: Array<HoSoThauN13Input>=[];

    makh:string;
    constructor(
        injector: Injector,
        private _hosothauService: HoSoThauN13ServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.saving = false;

     
    }

    reset():void{
   
    }

    save(): void {
        let input = this.hosothau;
        this.saving = true;

        this._hosothauService.createOrEditHoSoThau(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
        this.close();
    }
 
    close(): void {
        this.modalSave.emit(null);
    }
}
