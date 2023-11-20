import { SupplierForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { SupplierServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewNhaCungCapModal',
    templateUrl: './view-nhacungcap-modal.component.html'
})

export class ViewNhaCungCapModalComponent extends AppComponentBase {

    nhacungcap: SupplierForViewDto = new SupplierForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _nhacungcapService: SupplierServiceProxy
    ) {
        super(injector);
    }

    show(nhacungcapId?: number | null | undefined): void {
        this._nhacungcapService.getSupplierForView(nhacungcapId).subscribe(result => {
            this.nhacungcap = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
