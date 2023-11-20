import { TypeVehicleForViewDto } from "./../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { TypeVehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewTypeVehicleModal",
    templateUrl: "./view-typevehicle-modal.componenent.html"
})
export class ViewTypeVehicleModalComponent extends AppComponentBase {
    typevehicle: TypeVehicleForViewDto = new TypeVehicleForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _typevehicleService: TypeVehicleServiceProxy
    ) {
        super(injector);
    }

    show(typevehicleId?: number | null | undefined): void {
        this._typevehicleService
            .getTypeVehicleForView(typevehicleId)
            .subscribe(result => {
                this.typevehicle = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
