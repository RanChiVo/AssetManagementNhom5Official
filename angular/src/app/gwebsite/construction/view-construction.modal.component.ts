import { RealEstateRepairForViewDto_9, ConstructionForViewDto, ConstructionServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewConstructionModal',
    templateUrl: './view-construction.modal.component.html'
})

export class ViewConstructionModalComponent extends AppComponentBase {

    construction: ConstructionForViewDto = new ConstructionForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _constructionService: ConstructionServiceProxy
    ) {
        super(injector);
    }

    show(constructionID?: number | null | undefined): void {
        this._constructionService.getConstructionForView(constructionID).subscribe(result => {
            this.construction = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();

    }
}
