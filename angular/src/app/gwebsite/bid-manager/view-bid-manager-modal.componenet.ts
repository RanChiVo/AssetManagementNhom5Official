import { RealEstateRepairForViewDto_9, ConstructionForViewDto, ConstructionServiceProxy, BidManagerForViewDto, BidManagerServiceProxy, ConstructionInput } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewBidManagerModal',
    templateUrl: './view-bid-manager-modal.componenet.html'
})

export class ViewBidManagerModalComponent extends AppComponentBase {

    bidManager: BidManagerForViewDto = new BidManagerForViewDto();
    construction: ConstructionInput = new ConstructionInput();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _bidManagerService: BidManagerServiceProxy,
        private _constructionService: ConstructionServiceProxy
    ) {
        super(injector);
    }

    show(ID?: number | null | undefined): void {
        this._bidManagerService.getBidManagerForView(ID).subscribe(result => {
            this.bidManager = result;    
        })
        this._constructionService.getConstructionForEditWithMaCongTrinh(this.bidManager.maCongTrinh).subscribe(result => {
            this.construction = result;
        })
        this.modal.show();
    }

    close(): void {
        this.modal.hide();

    }
}
