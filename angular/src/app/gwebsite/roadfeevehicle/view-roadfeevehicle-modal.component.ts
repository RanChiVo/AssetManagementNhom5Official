import { RoadFeeVehicleForViewDto } from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { RoadFeeVehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewRoadFeeVehicleModal",
    templateUrl: "./view-roadfeevehicle-modal.component.html"
})
export class ViewRoadFeeVehicleModalComponent extends AppComponentBase {
    roadfeevehicle: RoadFeeVehicleForViewDto = new RoadFeeVehicleForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _roadfeevehicleService: RoadFeeVehicleServiceProxy
    ) {
        super(injector);
    }

    show(roadfeevehicleId?: number | null | undefined): void {
        this._roadfeevehicleService
            .getRoadFeeVehicleForView(roadfeevehicleId)
            .subscribe(result => {
                this.roadfeevehicle = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
