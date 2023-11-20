import { CongTrinhForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { CongTrinhServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewCongTrinhModal',
    templateUrl: './view-congtrinh-modal.component.html'
})

export class ViewCongTrinhModalComponent extends AppComponentBase {

    congtrinh : CongTrinhForViewDto = new CongTrinhForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy
    ) {
        super(injector);
    }

    show(congtrinhId?: number | null | undefined): void {
        this._congtrinhService.getCongTrinhForView(congtrinhId).subscribe(result => {
            this.congtrinh = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
