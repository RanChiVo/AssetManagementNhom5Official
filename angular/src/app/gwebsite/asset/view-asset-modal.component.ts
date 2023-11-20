import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { AssetController_05ServiceProxy, AssetForViewDto_05 } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewAssetModal',
    templateUrl: './view-asset-modal.component.html'
})

export class ViewAssetModalComponent extends AppComponentBase {

    asset: AssetForViewDto_05 = new AssetForViewDto_05();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private assetId: AssetController_05ServiceProxy
    ) {
        super(injector);
    }

    show(assetId?: string | null | undefined): void {
        this.assetId.getAssetForView(assetId).subscribe(result => {
            this.asset = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}