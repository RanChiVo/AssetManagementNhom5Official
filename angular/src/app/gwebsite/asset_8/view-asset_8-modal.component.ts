import { Asset_8ForViewDto } from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { Asset_8ServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewAsset_8Modal",
    templateUrl: "./view-asset_8-modal.component.html"
})
export class ViewAsset_8ModalComponent extends AppComponentBase {
    asset: Asset_8ForViewDto = new Asset_8ForViewDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _assetService: Asset_8ServiceProxy
    ) {
        super(injector);
    }

    show(assetId?: number | null | undefined): void {
        this._assetService.getAsset_8ForView(assetId).subscribe(result => {
            this.asset = result;
            this.modal.show();
        });
    }

    close(): void {
        this.modal.hide();
    }
}
