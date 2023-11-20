import { Asset11ForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Injector, Component, ViewChild } from '@angular/core';
import { Asset11ServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewAsset11Modal',
    templateUrl: './view-asset11-modal.component.html'
})
export class ViewAsset11ModalComponent extends AppComponentBase {
    asset11: Asset11ForViewDto = new Asset11ForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _asset11Service: Asset11ServiceProxy
    ) {
        super(injector);
    }

    show(asset11Id?: number | null | undefined): void {
        this._asset11Service.getAsset11ForView(asset11Id).subscribe(result => {
            this.asset11 = result;
            this.modal.show();
        });
    }

    close(): void {
        this.modal.hide();
    }
}
