
import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SanPhamServiceProxy, SanPhamInput, SanPhamDto, ComboboxItemDto,ProductTypeDto, NhaCungCapHangHoaDto,ProductTypeServiceProxy,NhaCungCapHangHoaServiceProxy } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
    
    
    @Component({
        selector: 'createOrEditProductModal',
        templateUrl: './create-or-edit-Product-modal.component.html'
    })
    export class CreateOrEditProductModalComponent extends AppComponentBase {
    
    
        @ViewChild('createOrEditModal') modal: ModalDirective;
        @ViewChild('ProductCombobox') ProductCombobox: ElementRef;
        @ViewChild('iconCombobox') iconCombobox: ElementRef;
        @ViewChild('dateInput') dateInput: ElementRef;
        @ViewChild('LoaiSanPhamCombobox') LoaiSanPhamCombobox: ElementRef;
        @ViewChild('NhaCungCapHangHoaCombobox') NhaCungCapHangHoaCombobox: ElementRef;
    
        /**
         * @Output dùng để public event cho component khác xử lý
         */
        @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    
        saving = false;
    
        product: SanPhamInput = new SanPhamInput();
        loaiSanPham: ProductTypeDto=new ProductTypeDto();
        nhaCungCapHangHoa: NhaCungCapHangHoaDto=new NhaCungCapHangHoaDto();
       selectedType: number;
       temp: string;
       loaiSanPhams: Array<ProductTypeDto>=[];
       nhaCungCapHangHoas: Array<NhaCungCapHangHoaDto>=[];
        constructor(
            injector: Injector,
            private _productService:SanPhamServiceProxy,
            private _router: Router,
            private _activatedRoute: ActivatedRoute,
            private _apiService: WebApiServiceProxy,
            private _productTypeService: ProductTypeServiceProxy,
            private _nhaCungCapHangHoaService : NhaCungCapHangHoaServiceProxy
        
        ) {
            super(injector);
            this.getProductTypes();
            this.getNhaCungCap();
        }
        getProductTypes(): ProductTypeDto[] {
           /* this._apiService.get('api/ProductType/GetProductTypesByFilter').subscribe(result => {
                this.loaiSanPhams = result.items;
               
            });*/
            this._productTypeService.getProductTypesByFilter(null, "", 100, 0)
            .subscribe(result => {
                this.loaiSanPhams = result.items;
            });
            return this.loaiSanPhams;               
        }

        getNhaCungCap(): void {
            /*this._apiService.get('api/NhaCungCapHangHoa/GetNhaCungCapHangHoasByFilter').subscribe(result => {
                this.nhaCungCapHangHoas = result.items;
               
            });*/
            this._nhaCungCapHangHoaService.getAllNhaCungCapHangHoasByFilter(null,"",100,0).subscribe(result =>{
                this.nhaCungCapHangHoas=result.items;
            });
         
        }

        onChangeProductType(): void {
            this._apiService.getForEdit('api/ProductType/GetProductTypeForView', this.selectedType).subscribe(result => {
                this.temp = result.tenLoaiSanPham;
              
            });
    
        }
        onChangeNhaCungCapHangHoa(): void {
            this._apiService.getForEdit('api/NhaCungCapHangHoa/GetNhaCungCapHangHoaForView', this.selectedType).subscribe(result => {
                this.temp = result.tenNhaCungCap;
              
            });
    
        }
    
        show(productId?: number | null | undefined): void {
            this.saving = false;
    
    
            this._productService.getProductForEdit(productId).subscribe(result => {
                this.product = result;
                this.modal.show();
    
            })
        }
    
        save(): void {
            let input = this.product;
            this.saving = true;
            console.log(this.product.maSanPham);
            
            input.maSanPham = this.product.maSanPham;
            console.log(input.maSanPham);
            this._productService.createOrEditProduct(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })

        }
    
        close(): void {
            this.modal.hide();
            this.modalSave.emit(null);
        }
    }
    