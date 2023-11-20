import { FixedAssetForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { FixedAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewFixedAssetModal',
    templateUrl: './view-fixed-asset-modal.component.html'
})

export class ViewFixedAssetModalComponent extends AppComponentBase {

    fixedAsset: FixedAssetForViewDto = new FixedAssetForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private fixedAssetId: FixedAssetServiceProxy
    ) {
        super(injector);
    }

    show(fixedAssetId?: number | null | undefined): void {
        this.fixedAssetId.getFixedAssetForView(fixedAssetId).subscribe(result => {
            this.fixedAsset = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}