import { HienTrangPhapLyForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { HienTrangPhapLyServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewHienTrangPhapLyModal',
    templateUrl: './view-hientrangphaply-modal.component.html'
})

export class ViewHienTrangPhapLyModalComponent extends AppComponentBase {

    hientrangphaply : HienTrangPhapLyForViewDto = new HienTrangPhapLyForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _hientrangphaplyService: HienTrangPhapLyServiceProxy
    ) {
        super(injector);
    }

    show(hientrangphaplyId?: number | null | undefined): void {
        this._hientrangphaplyService.getHienTrangPhapLyForView(hientrangphaplyId).subscribe(result => {
            this.hientrangphaply = result;
            
        })
    }

    close() : void{
        this.modal.hide();
    }
}
