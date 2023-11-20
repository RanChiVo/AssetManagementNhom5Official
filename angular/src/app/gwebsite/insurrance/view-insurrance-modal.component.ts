import { InsurranceForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { InsurranceServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewInsurranceModal',
    templateUrl: './view-insurrance-modal.component.html'
})

export class ViewInsurranceModalComponent extends AppComponentBase {

    insurrance : InsurranceForViewDto = new InsurranceForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _insurranceService: InsurranceServiceProxy
    ) {
        super(injector);
    }

    show(insurranceId?: number | null | undefined): void {
        this._insurranceService.getInsurranceForView(insurranceId).subscribe(result => {
            this.insurrance = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}