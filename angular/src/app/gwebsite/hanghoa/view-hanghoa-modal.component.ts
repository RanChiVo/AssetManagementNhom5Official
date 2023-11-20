import { GoodsForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { GoodsServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewHangHoaModal',
    templateUrl: './view-hanghoa-modal.component.html'
})

export class ViewHangHoaModalComponent extends AppComponentBase {

    hanghoa: GoodsForViewDto = new GoodsForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _hanghoaService: GoodsServiceProxy
    ) {
        super(injector);
    }

    show(hanghoaId?: number | null | undefined): void {
        this._hanghoaService.getGoodsForView(hanghoaId).subscribe(result => {
            this.hanghoa = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
