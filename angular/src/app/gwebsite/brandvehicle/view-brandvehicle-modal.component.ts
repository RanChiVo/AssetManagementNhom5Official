import { BrandVehicleForViewDto } from "./../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { BrandVehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewBrandVehicleModal",
    templateUrl: "./view-brandvehicle-modal.component.html"
})
export class ViewBrandVehicleModalComponent extends AppComponentBase {
    brandvehicle: BrandVehicleForViewDto = new BrandVehicleForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _brandvehicleService: BrandVehicleServiceProxy
    ) {
        super(injector);
    }

    show(brandvehicleId?: number | null | undefined): void {
        this._brandvehicleService
            .getBrandVehicleForView(brandvehicleId)
            .subscribe(result => {
                this.brandvehicle = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
