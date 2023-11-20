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
    BrandVehicleServiceProxy,
    BrandVehicleInput
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditBrandVehicleModal",
    templateUrl: "./create-or-edit-brandvehicle-modal.component.html"
})
export class CreateOrEditBrandVehicleModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("brandvehicleCombobox") brandvehicleCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    brandvehicle: BrandVehicleInput = new BrandVehicleInput();

    constructor(
        injector: Injector,
        private _brandvehicleService: BrandVehicleServiceProxy
    ) {
        super(injector);
    }

    show(brandvehicleId?: number | null | undefined): void {
        this.saving = false;

        this._brandvehicleService
            .getBrandVehicleForEdit(brandvehicleId)
            .subscribe(result => {
                this.brandvehicle = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.brandvehicle;
        this.saving = true;
        this._brandvehicleService
            .createOrEditBrandVehicle(input)
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
