import { TransferringAssetDataOutputDetail } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { TransferringAssetServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewTransferringAssetModal',
    templateUrl: './view-transferring-asset-modal.component.html'
})

export class ViewTransferringAssetModalComponent extends AppComponentBase {

    transferringAsset: TransferringAssetDataOutputDetail = new TransferringAssetDataOutputDetail();
    @ViewChild('viewModal') modal: ModalDirective;

    
    constructor(
        injector: Injector,
        private _transferringAssetService: TransferringAssetServiceProxy
    ) {
        super(injector);
    }

    show(transferringAssetId?: number | null | undefined): void {
        this._transferringAssetService.getTransferringAssetDetailInAngular(transferringAssetId).subscribe(result => {
            this.transferringAsset = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}
