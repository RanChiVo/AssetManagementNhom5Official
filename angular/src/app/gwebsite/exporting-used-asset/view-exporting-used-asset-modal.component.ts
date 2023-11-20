import { ExportingUsedAssetForViewDto, AssetController_05ServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Injector, Component, ViewChild } from '@angular/core';
import { ExportingUsedAssetServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';
//import { LaborToolServiceProxy } from '@shared/service-proxies/service-proxies';
import {Asset} from './asset';

@Component({
    selector: 'viewExportingUsedAssetModal',
    templateUrl: './view-exporting-used-asset-modal.component.html'
})

export class ViewExportingUsedAssetModalComponent extends AppComponentBase {

    exportingUsedAsset: ExportingUsedAssetForViewDto = new ExportingUsedAssetForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;
   
    id: number = 0;
    selectedAsset: Asset = new Asset('123', 'werqwer', 0, 'wqerqwerqwer');
    assetId: string;

    constructor(
        injector: Injector,
        private _exportingUsedAssetService: ExportingUsedAssetServiceProxy,
        private _assetId: AssetController_05ServiceProxy,
        // private _laborToolService: LaborToolServiceProxy
    ) {
        super(injector);
    }

    show(exportingUsedAssetId?: number | null | undefined): void {
        this._exportingUsedAssetService.getExportingUsedAssetForView(exportingUsedAssetId).subscribe(result => {
            this.exportingUsedAsset = result;
            this.id = parseInt(result.assetId);
            this.assetId = result.assetId;
        });
        this._assetId.getAssetForView(this.assetId).subscribe(result => {
            this.selectedAsset.id = result.assetId;
            this.selectedAsset.name = result.name;
            this.modal.show();
        });
    }
    

    close(): void{
        this.modal.hide();
    }
}
