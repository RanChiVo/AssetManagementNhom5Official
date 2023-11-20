
    import { LoaiNhaCungCapForViewDto }         from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { LoaiNhaCungCapServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewLoaiNhaCungCapModal',
    templateUrl: './view-LoaiNhaCungCap-modal.component.html'
})

export class ViewLoaiNhaCungCapModalComponent extends AppComponentBase {

    loaiNhaCungCap : LoaiNhaCungCapForViewDto = new LoaiNhaCungCapForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _loaiNhaCungCapService: LoaiNhaCungCapServiceProxy
    ) {
        super(injector);
    }

    show(loaiNhaCungCapId?: number | null | undefined): void {
        this._loaiNhaCungCapService.getLoaiNhaCungCapForView(loaiNhaCungCapId).subscribe(result => {
            this.loaiNhaCungCap = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
