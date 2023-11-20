import { ComputerForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Injector, Component, ViewChild } from '@angular/core';
import { ComputerServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewComputerModal',
    templateUrl: './view-computer-modal.component.html'
})

export class ViewComputerModalComponent extends AppComponentBase {

    computer: ComputerForViewDto = new ComputerForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _computerService: ComputerServiceProxy
    ) {
        super(injector);
    }

    show(computerId?: number | null | undefined): void {
        this._computerService.getComputerForView(computerId).subscribe(result => {
            this.computer = result;
            this.modal.show();
        } );
    }

    close(): void {
        this.modal.hide();
    }
}
