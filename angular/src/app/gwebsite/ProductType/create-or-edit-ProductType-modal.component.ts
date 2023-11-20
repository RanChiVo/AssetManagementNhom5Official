import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProductTypeServiceProxy, ProductTypeInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditProductTypeModal',
    templateUrl: './create-or-edit-ProductType-modal.component.html'
})
export class CreateOrEditProductTypeModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('ProductTypeCombobox') ProductTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    productType: ProductTypeInput = new ProductTypeInput();
   

    constructor(
        injector: Injector,
        private _productTypeService: ProductTypeServiceProxy
    ) {
        super(injector);
    }

    show(productTypeId?: number | null | undefined): void {
        this.saving = false;


        this._productTypeService.getProductTypeForEdit(productTypeId).subscribe(result => {
            this.productType = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.productType;     
        this.saving = true;
        this._productTypeService.createOrEditProductType(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            console.log("thong tin luu vao"+input);
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
