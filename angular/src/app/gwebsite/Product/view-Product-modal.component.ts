
    import { SanPhamForViewDto }         from './../../../shared/service-proxies/service-proxies';
    import { AppComponentBase } from "@shared/common/app-component-base";
    import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
    import { SanPhamServiceProxy } from "@shared/service-proxies/service-proxies";
    import { ModalDirective } from 'ngx-bootstrap';
    
    @Component({
        selector: 'viewProductModal',
        templateUrl: './view-Product-modal.component.html'
    })
    
    export class ViewProductModalComponent extends AppComponentBase {
    
        product : SanPhamForViewDto = new SanPhamForViewDto();
        @ViewChild('viewModal') modal: ModalDirective;
    
        constructor(
            injector: Injector,
            private _productService: SanPhamServiceProxy
        ) {
            super(injector);
        }
    
        show(productId?: number | null | undefined): void {
            this._productService.getProductForView(productId).subscribe(result => {
                this.product = result;
                this.modal.show();
            })
        }
    
        close() : void{
            this.modal.hide();
        }
    }
    