import { ConstructionPlanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ConstructionPlanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewConstructionPlanModal',
    templateUrl: './view-constructionPlan-modal.component.html'
})

export class ViewConstructionPlanModalComponent extends AppComponentBase {

    constructionPlan: ConstructionPlanForViewDto = new ConstructionPlanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _constructionPlanService: ConstructionPlanServiceProxy
    ) {
        super(injector);
    }

    show(constructionPlanId?: number | null | undefined): void {
        this._constructionPlanService.getConstructionPlanForView(constructionPlanId).subscribe(result => {
            this.constructionPlan = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}
