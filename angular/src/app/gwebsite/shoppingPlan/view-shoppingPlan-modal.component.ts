import { ShoppingPlanForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ShoppingPlanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewShoppingPlanModal',
    templateUrl: './view-shoppingPlan-modal.component.html'
})

export class ViewShoppingPlanModalComponent extends AppComponentBase {

    shoppingPlan: ShoppingPlanForViewDto = new ShoppingPlanForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _shoppingPlanService: ShoppingPlanServiceProxy
    ) {
        super(injector);
    }

    show(shoppingPlanId?: number | null | undefined): void {
        this._shoppingPlanService.getShoppingPlanForView(shoppingPlanId).subscribe(result => {
            this.shoppingPlan = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}
