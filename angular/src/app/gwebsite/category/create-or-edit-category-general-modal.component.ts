import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { CategoryTypeDto } from '../category-type/dto/category-type.dto';
import { CategoryServiceProxy, CategoryInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditCategoryModal',
    templateUrl: './create-or-edit-category-general-modal.component.html',
    styleUrls: ['./create-or-edit-category-general-modal.component.scss'],
})
export class CreateOrEditCategoryModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('categoryCombobox') categoryCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    savingType = false;

    category: CategoryInput = new CategoryInput();
    categoryType: CategoryTypeDto = new CategoryTypeDto();
    selectedType: number;
    categoryTypes: Array<CategoryTypeDto> = [];

    constructor(
        injector: Injector,
        private _apiService: WebApiServiceProxy,
        private _categoryService: CategoryServiceProxy
    ) {
        super(injector);
    }

    getTypes(): void {
        // get category type
        this._apiService.get('api/CategoryType/GetCategoryTypesByFilter', 
        [{ fieldName: 'IsCreatedCheckedAll', value: true },
        { fieldName: 'IsUpdatedCheckedAll', value: true },
        { fieldName: 'Status', value: 'Active'}])
        .subscribe(result => {
            this.categoryTypes = result.items;
        });
    }

    show(categoryId?: number | null | undefined): void {
        this.active = true;
        this.getTypes();

        this._categoryService.getCategoryForEdit(categoryId).subscribe(result => {
            this.category = result;
            this.modal.show();
            setTimeout(() => {
                $(this.categoryCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    onChangeType(): void {
        this._apiService.getForEdit('api/CategoryType/GetCategoryTypeForView', this.selectedType).subscribe(result => {
            this.category.categoryType = result.name;
            this.category.categoryId = result.prefixWord; // get prefix word to create id
        });
    }

    save(): void {
        let input = this.category;
        this.saving = true;
        if (input.id) {
            this.updateCategory();
        } else {
            this.insertCategory();
        }
    }

    insertCategory() {
        this._apiService.post('api/Category/CreateCategory', this.category)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    updateCategory() {
        this._apiService.put('api/Category/EditCategory', this.category)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    addType(): void {
        this.savingType = true;
        this._apiService.post('api/CategoryType/CreateCategoryType', this.categoryType)
            .pipe(finalize(() => this.savingType = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
