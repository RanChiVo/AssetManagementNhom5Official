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
    Asset_8ServiceProxy,
    Asset_8Input
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditAsset_8Modal",
    templateUrl: "./create-or-edit-asset_8-modal.component.html"
})
export class CreateOrEditAsset_8ModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("assetCombobox") assetCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    asset: Asset_8Input = new Asset_8Input();

    constructor(
        injector: Injector,
        private _assetService: Asset_8ServiceProxy
    ) {
        super(injector);
    }

    show(assetId?: number | null | undefined): void {
        this.saving = false;

        this._assetService.getAsset_8ForEdit(assetId).subscribe(result => {
            this.asset = result;
            this.modal.show();
        });
    }

    save(): void {
        let input = this.asset;
        this.saving = true;
        this._assetService.createOrEditAsset_8(input).subscribe(result => {
            this.notify.info(this.l("SavedSuccessfully"));
            this.close();
        });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
