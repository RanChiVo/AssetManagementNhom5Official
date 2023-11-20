import { OperateVehicleForViewDto } from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { OperateVehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewOperateVehicleModal",
    templateUrl: "./view-operatevehicle-modal.component.html"
})
export class ViewOperateVehicleModalComponent extends AppComponentBase {
    operatevehicle: OperateVehicleForViewDto = new OperateVehicleForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _operatevehicleService: OperateVehicleServiceProxy
    ) {
        super(injector);
    }

    show(operatevehicleId?: number | null | undefined): void {
        this._operatevehicleService
            .getOperateVehicleForView(operatevehicleId)
            .subscribe(result => {
                this.operatevehicle = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
