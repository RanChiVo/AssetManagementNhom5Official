import { InsurranceTypeForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { InsurranceTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewInsurranceTypeModal',
    templateUrl: './view-insurrancetype-modal.component.html'
})

export class ViewInsurranceTypeModalComponent extends AppComponentBase {

    insurrancetype : InsurranceTypeForViewDto = new InsurranceTypeForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _insurrancetypeService: InsurranceTypeServiceProxy
    ) {
        super(injector);
    }

    show(insurrancetypeId?: number | null | undefined): void {
        this._insurrancetypeService.getInsurranceTypeForView(insurrancetypeId).subscribe(result => {
            this.insurrancetype = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}