import { KeHoachXayDungForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { KeHoachXayDungServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewKeHoachXayDungModal',
    templateUrl: './view-kehoachxaydung-modal.component.html'
})

export class ViewKeHoachXayDungModalComponent extends AppComponentBase {

    kehoachxaydung : KeHoachXayDungForViewDto = new KeHoachXayDungForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _kehoachxaydungService: KeHoachXayDungServiceProxy
    ) {
        super(injector);
    }

    show(kehoachxaydungId?: number | null | undefined): void {
        this._kehoachxaydungService.getKeHoachXayDungForView(kehoachxaydungId).subscribe(result => {
            this.kehoachxaydung = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
