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
    ModelVehicleServiceProxy,
    ModelVehicleInput
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditModelVehicleModal",
    templateUrl: "./create-or-edit-modelvehicle-modal.component.html"
})
export class CreateOrEditModelVehicleModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("modelvehicleCombobox") modelvehicleCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    modelvehicle: ModelVehicleInput = new ModelVehicleInput();

    constructor(
        injector: Injector,
        private _modelvehicleService: ModelVehicleServiceProxy
    ) {
        super(injector);
    }

    show(modelvehicleId?: number | null | undefined): void {
        this.saving = false;

        this._modelvehicleService
            .getModelVehicleForEdit(modelvehicleId)
            .subscribe(result => {
                this.modelvehicle = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.modelvehicle;
        this.saving = true;
        this._modelvehicleService
            .createOrEditModelVehicle(input)
            .subscribe(result => {
                this.notify.info(this.l("SavedSuccessfully"));
                this.close();
            });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
