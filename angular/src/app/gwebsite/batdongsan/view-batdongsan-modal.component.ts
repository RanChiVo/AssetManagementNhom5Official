import { BatDongSanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { BatDongSanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewBatDongSanModal',
    templateUrl: './view-batdongsan-modal.component.html'
})

export class ViewBatDongSanModalComponent extends AppComponentBase {

    batdongsan : BatDongSanForViewDto = new BatDongSanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _batdongsanService: BatDongSanServiceProxy
    ) {
        super(injector);
    }

    show(batdongsanId?: number | null | undefined): void {
        this._batdongsanService.getBatDongSanForView(batdongsanId).subscribe(result => {
            this.batdongsan = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
