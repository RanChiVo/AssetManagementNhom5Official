import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { CategoryTypeInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditTypeModal',
    templateUrl: './create-or-edit-category-type-general-modal.component.html',
    styleUrls: ['../category/create-or-edit-category-general-modal.component.scss'],
})
export class CreateOrEditTypeModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    categoryType: CategoryTypeInput = new CategoryTypeInput();

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
    }

    show(typeId?: number | null | undefined): void {
        this.active = true;

        this._apiService.getForEdit('api/CategoryType/GetCategoryTypeForEdit', typeId).subscribe(result => {
            this.categoryType = result;
            this.modal.show();
        });
    }

    save(): void {
        let input = this.categoryType;
        this.saving = true;
        if (input.id) {
            this.updateType();
        } else {
            this.insertType();
        }
    }

    insertType() {
        this._apiService.post('api/CategoryType/CreateCategoryType', this.categoryType)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateType() {
        this._apiService.put('api/CategoryType/EditCategoryType', this.categoryType)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
