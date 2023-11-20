import { LoaiBatDongSanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { LoaiBatDongSanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewLoaiBatDongSanModal',
    templateUrl: './view-loaibatdongsan-modal.component.html'
})

export class ViewLoaiBatDongSanModalComponent extends AppComponentBase {

    loaibatdongsan : LoaiBatDongSanForViewDto = new LoaiBatDongSanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _loaibatdongsanService: LoaiBatDongSanServiceProxy
    ) {
        super(injector);
    }

    show(loaibatdongsanId?: number | null | undefined): void {
        this._loaibatdongsanService.getLoaiBatDongSanForView(loaibatdongsanId).subscribe(result => {
            this.loaibatdongsan = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
