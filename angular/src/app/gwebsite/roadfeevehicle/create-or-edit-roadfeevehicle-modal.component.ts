import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild
} from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import {
    RoadFeeVehicleServiceProxy,
    RoadFeeVehicleInput,
    VehicleInput
} from "@shared/service-proxies/service-proxies";
import { SelectVehicleModalComponent } from "../vehicle/select-vehicle-modal.component";
import { VehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
@Component({
    selector: "createOrEditRoadFeeVehicleModal",
    templateUrl: "./create-or-edit-roadfeevehicle-modal.component.html"
})
export class CreateOrEditRoadFeeVehicleModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("roadfeevehicleCombobox") roadfeevehicleCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;
    @ViewChild("selectVehicleModal")
    selectVehicleModal: SelectVehicleModalComponent;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    roadfeevehicle: RoadFeeVehicleInput = new RoadFeeVehicleInput();
    xe: VehicleInput = new VehicleInput();
    selectedVehicle: number;
    constructor(
        injector: Injector,
        private _roadfeevehicleService: RoadFeeVehicleServiceProxy,
        private _assetService: VehicleServiceProxy,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(maPhiDuongBo?: number | null | undefined): void {
        this.saving = false;

        this._roadfeevehicleService
            .getRoadFeeVehicleForEdit(maPhiDuongBo)
            .subscribe(result => {
                this.roadfeevehicle = result;
                this.modal.show();
            });
    }

    save(): void {
        // this.roadfeevehicle.idVehicle="Mã đã chọn"
        let input = this.roadfeevehicle;
        this.saving = true;
        this._roadfeevehicleService
            .createOrEditRoadFeeVehicle(input)
            .subscribe(result => {
                this.notify.info(this.l("SavedSuccessfully"));
                this.close();
            });
    }
    showXe(): void {
        console.log("Mo tai san");
        this.selectVehicleModal.show();
    }
    updateVehicle(): void {
        if (this.selectVehicleModal.selectedMaXe != -1) {
            this.selectedVehicle = this.selectVehicleModal.selectedMaXe;
            this._apiService
                .getForEdit(
                    "api/Vehicle/GetVehicleForView",
                    this.selectedVehicle
                )
                .subscribe(result => {
                    this.xe = result;
                });
        }
    }
    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
