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
    TypeVehicleServiceProxy,
    TypeVehicleInput
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditTypeVehicleModal",
    templateUrl: "./create-or-edit-typevehicle-modal.component.html"
})
export class CreateOrEditTypeVehicleModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("typevehicleCombobox") typevehicleCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    typevehicle: TypeVehicleInput = new TypeVehicleInput();

    constructor(
        injector: Injector,
        private _typevehicleService: TypeVehicleServiceProxy
    ) {
        super(injector);
    }

    show(typevehicleId?: number | null | undefined): void {
        this.saving = false;

        this._typevehicleService
            .getTypeVehicleForEdit(typevehicleId)
            .subscribe(result => {
                this.typevehicle = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.typevehicle;
        this.saving = true;
        this._typevehicleService
            .createOrEditTypeVehicle(input)
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
