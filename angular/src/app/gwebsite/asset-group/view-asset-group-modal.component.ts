import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { AssetGroupController_05ServiceProxy, AssetGroupForViewDto_05 } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewAssetGroupModal',
    templateUrl: './view-asset-group-modal.component.html'
})

export class ViewAssetGroupModalComponent extends AppComponentBase {

    assetGroup: AssetGroupForViewDto_05 = new AssetGroupForViewDto_05();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private assetGroupId: AssetGroupController_05ServiceProxy
    ) {
        super(injector);
    }

    show(assetGroupId?: string | null | undefined): void {
        this.assetGroupId.getAssetGroupForView(assetGroupId).subscribe(result => {
            this.assetGroup = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}