import { CategoryTypeForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Injector, Component, ViewChild } from '@angular/core';
import { CategoryTypeServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewCategoryTypeModal',
    templateUrl: './view-category-type-general-modal.component.html'
})

export class ViewCategoryTypeModalComponent extends AppComponentBase {

    type: CategoryTypeForViewDto = new CategoryTypeForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _typeService: CategoryTypeServiceProxy
    ) {
        super(injector);
    }

    show(id?: number | null | undefined): void {
        this._typeService.getCategoryTypeForView(id).subscribe(result => {
            this.type = result;
            this.modal.show();
        });
    }

    close(): void {
        this.modal.hide();
    }
}