
    import { ProductTypeForViewDto }         from './../../../shared/service-proxies/service-proxies';
    import { AppComponentBase } from "@shared/common/app-component-base";
    import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
    import { ProductTypeServiceProxy } from "@shared/service-proxies/service-proxies";
    import { ModalDirective } from 'ngx-bootstrap';
    
    @Component({
        selector: 'viewProductTypeModal',
        templateUrl: './view-ProductType-modal.component.html'
    })
    
    export class ViewProductTypeModalComponent extends AppComponentBase {
    
        productType : ProductTypeForViewDto = new ProductTypeForViewDto();
        @ViewChild('viewModal') modal: ModalDirective;
    
        constructor(
            injector: Injector,
            private _productTypeService: ProductTypeServiceProxy
        ) {
            super(injector);
        }
    
        show(productTypeId?: number | null | undefined): void {
            this._productTypeService.getProductTypeForView(productTypeId).subscribe(result => {
                this.productType = result;
                this.modal.show();
            })
        }
    
        close() : void{
            this.modal.hide();
        }
    }
    