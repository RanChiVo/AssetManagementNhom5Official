import { SoftwareForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Injector, Component, ViewChild } from '@angular/core';
import { SoftwareServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewSoftwareModal',
    templateUrl: './view-software-modal.component.html'
})

export class ViewSoftwareModalComponent extends AppComponentBase {

    software: SoftwareForViewDto = new SoftwareForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _softwareService: SoftwareServiceProxy
    ) {
        super(injector);
    }

    show(softwareId?: number | null | undefined): void {
        this._softwareService.getSoftwareForView(softwareId).subscribe(result => {
            this.software = result;
            this.modal.show();
        } );
    }

    close(): void {
        this.modal.hide();
    }
}
