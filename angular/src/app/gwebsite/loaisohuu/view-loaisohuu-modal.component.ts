import { LoaiSoHuuForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { LoaiSoHuuServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewLoaiSoHuuModal',
    templateUrl: './view-loaisohuu-modal.component.html'
})

export class ViewLoaiSoHuuModalComponent extends AppComponentBase {

    loaisohuu : LoaiSoHuuForViewDto = new LoaiSoHuuForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _loaisohuuService: LoaiSoHuuServiceProxy
    ) {
        super(injector);
    }

    show(loaisohuuId?: number | null | undefined): void {
        this._loaisohuuService.getLoaiSoHuuForView(loaisohuuId).subscribe(result => {
            this.loaisohuu = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
