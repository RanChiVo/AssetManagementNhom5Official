import { ViewProductTypeModalComponent } from './view-ProductType-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ProductTypeServiceProxy,SanPhamDto, ProductTypeDto,SanPhamServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditProductTypeModalComponent } from './create-or-edit-ProductType-modal.component';
import { strictEqual } from 'assert';
import {WebApiServiceProxy} from '@shared/service-proxies/webapi.service';
import {ExcelService} from '../services/excel.service';
import { FileDownloadService } from '@shared/utils/file-download.service';


    @Component({
        templateUrl: './ProductType.component.html',
        animations: [appModuleAnimation()]
    })
    export class ProductTypeComponent extends AppComponentBase implements AfterViewInit, OnInit {

        /**
        * @ViewChild là dùng get control và call thuộc tính, functions của control đó
        */
        @ViewChild('dataTable') dataTable: Table;
        @ViewChild('paginator') paginator: Paginator;
        @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditProductTypeModalComponent;
        @ViewChild('viewProductTypeModal') viewProductTypeModal: ViewProductTypeModalComponent;

        /**
        * tạo các biến dể filters
        */
       ProductTypeName: string;
       ProductType: string;
       products: Array<SanPhamDto>=[];
       productTypes: Array<ProductTypeDto>=[];

        constructor(
            injector: Injector,
            private _productTypeService: ProductTypeServiceProxy,
            private _activatedRoute: ActivatedRoute,
            private _apiService: WebApiServiceProxy,
            private excelService: ExcelService,
            private _fileDownloadService: FileDownloadService,
            private _productService: SanPhamServiceProxy
        ) {
            super(injector);
            this.getProducts(this.ProductType);
            this.getProductType();
           /* this.exportAsXLSX();*/
        }
        getProductType():ProductTypeDto[]
        {
            this._apiService.get('api/ProductType/GetProductTypesByFilter').subscribe(result => {
                this.productTypes = result.items;
            });
            return this.productTypes;
        }
        getProducts(ProductType): SanPhamDto[]
        {
           
            this._productService.getProductsByFilterType(ProductType,"",100,0).subscribe(result=>{
                this.products=result.items});
            return this.products;
           /* this._apiService.get('api/SanPham/GetProductsByFilterType='+this.ProductType).subscribe(result => {
                this.products = result.items;
            });*/
            /*return this.products;*/
        }
        /**
        * Hàm xử lý trước khi View được init
        */
        ngOnInit(): void {
        }

        /**
        * Hàm xử lý sau khi View được init
        */
        ngAfterViewInit(): void {
            setTimeout(() => {
                this.init();
            });
        }

        /**
        * Hàm get danh sách Customer
        * @param event
        */
        getProductTypes(event?: LazyLoadEvent) {
            if (!this.paginator || !this.dataTable) {
                return;
            }

            //show loading trong gridview
            this.primengTableHelper.showLoadingIndicator();

            /**
            * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
            */

            this.reloadList(null, event);

        }

        reloadList(ProductTypeName, event?: LazyLoadEvent) {
            this._productTypeService.getProductTypesByFilter(ProductTypeName, this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(this.paginator, event),
                this.primengTableHelper.getSkipCount(this.paginator, event),
            ).subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
        }

        deleteProductType(id): void {
            this._productTypeService.deleteProductType(id).subscribe(() => {
                this.reloadPage();
            })
        }

        init(): void {
            //get params từ url để thực hiện filter
            this._activatedRoute.params.subscribe((params: Params) => {
                this.reloadList(this.ProductTypeName, null);
            });
        }

        reloadPage(): void {
            this.paginator.changePage(this.paginator.getPage());
        }

        applyFilters(): void {
            //truyền params lên url thông qua router
            this.reloadList(this.ProductTypeName, null);

            if (this.paginator.getPage() !== 0) {
                this.paginator.changePage(0);
                return;
            }
        }
        

        //hàm show view create MenuClient
        createProductType() {
            this.createOrEditModal.show();
        }

        /**
        * Tạo pipe thay vì tạo từng hàm truncate như thế này
        * @param text
        */
        truncateString(text): string {
            return abp.utils.truncateStringWithPostfix(text, 32, '...');
        }
        exportAsXLSX():void {
            this.excelService.exportAsExcelFile( this.productTypes,"Danh Sách Loại Sản Phẩm");
          }
         
    }