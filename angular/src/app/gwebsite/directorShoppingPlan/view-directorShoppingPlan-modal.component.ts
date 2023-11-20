import { DirectorShoppingPlanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { DirectorShoppingPlanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewDirectorShoppingPlanModal',
    templateUrl: './view-directorShoppingPlan-modal.component.html'
})

export class ViewDirectorShoppingPlanModalComponent extends AppComponentBase {

    directorShoppingPlan: DirectorShoppingPlanForViewDto = new DirectorShoppingPlanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _directorShoppingPlanService: DirectorShoppingPlanServiceProxy
    ) {
        super(injector);
    }

    show(directorShoppingPlanId?: number | null | undefined): void {
        this._directorShoppingPlanService.getDirectorShoppingPlanForView(directorShoppingPlanId).subscribe(result => {
            this.directorShoppingPlan = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}
