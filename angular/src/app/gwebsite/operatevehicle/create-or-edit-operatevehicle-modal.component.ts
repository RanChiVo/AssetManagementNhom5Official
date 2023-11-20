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
    OperateVehicleServiceProxy,
    OperateVehicleInput,
    VehicleInput
} from "@shared/service-proxies/service-proxies";
import { SelectVehicleModalComponent } from "../vehicle/select-vehicle-modal.component";
import { VehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
@Component({
    selector: "createOrEditOperateVehicleModal",
    templateUrl: "./create-or-edit-operatevehicle-modal.component.html"
})
export class CreateOrEditOperateVehicleModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("operatevehicleCombobox") operatevehicleCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;
    @ViewChild("selectVehicleModal")
    selectVehicleModal: SelectVehicleModalComponent;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    operatevehicle: OperateVehicleInput = new OperateVehicleInput();
    xe: VehicleInput = new VehicleInput();
    selectedVehicle: number;
    constructor(
        injector: Injector,
        private _operatevehicleService: OperateVehicleServiceProxy,
        private _assetService: VehicleServiceProxy,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(operatevehicleId?: number | null | undefined): void {
        this.saving = false;

        this._operatevehicleService
            .getOperateVehicleForEdit(operatevehicleId)
            .subscribe(result => {
                this.operatevehicle = result;
                this.modal.show();
            });
    }

    save(): void {
        // this.operatevehicle.idVehicle="Mã đã chọn"
        let input = this.operatevehicle;
        this.saving = true;
        this._operatevehicleService
            .createOrEditOperateVehicle(input)
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
