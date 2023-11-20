import { ModelVehicleForViewDto } from "./../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModelVehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewModelVehicleModal",
    templateUrl: "./view-modelvehicle-modal.component.html"
})
export class ViewModelVehicleModalComponent extends AppComponentBase {
    modelvehicle: ModelVehicleForViewDto = new ModelVehicleForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _modelvehicleService: ModelVehicleServiceProxy
    ) {
        super(injector);
    }

    show(modelvehicleId?: number | null | undefined): void {
        this._modelvehicleService
            .getModelVehicleForView(modelvehicleId)
            .subscribe(result => {
                this.modelvehicle = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
