import { DisposalPlanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { DisposalPlanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewDisposalPlanModal',
    templateUrl: './view-disposalPlan-modal.component.html'
})

export class ViewDisposalPlanModalComponent extends AppComponentBase {

    disposalPlan: DisposalPlanForViewDto = new DisposalPlanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _disposalPlanService: DisposalPlanServiceProxy
    ) {
        super(injector);
    }

    show(disposalPlanId?: number | null | undefined): void {
        this._disposalPlanService.getDisposalPlanForView(disposalPlanId).subscribe(result => {
            this.disposalPlan = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}