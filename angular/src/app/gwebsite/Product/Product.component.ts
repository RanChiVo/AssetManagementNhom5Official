import { ViewProductModalComponent } from './view-Product-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { SanPhamServiceProxy,SanPhamDto } from '@shared/service-proxies/service-proxies';
import { CreateOrEditProductModalComponent } from './create-or-edit-Product-modal.component';
import {ExcelService} from '../services/excel.service';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

    @Component({
        templateUrl: './Product.component.html',
        animations: [appModuleAnimation()]
    })
    export class ProductComponent extends AppComponentBase implements AfterViewInit, OnInit {

        /**
        * @ViewChild là dùng get control và call thuộc tính, functions của control đó
        */
        @ViewChild('dataTable') dataTable: Table;
        @ViewChild('paginator') paginator: Paginator;
        @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditProductModalComponent;
        @ViewChild('viewProductModal') viewProductModal: ViewProductModalComponent;

        /**
        * tạo các biến dể filters
        */
        ProductName: string;
        products: Array<SanPhamDto>=[];

        constructor(
            injector: Injector,
            private _productService: SanPhamServiceProxy,
            private _activatedRoute: ActivatedRoute,
            private _apiService: WebApiServiceProxy,
            private excelService: ExcelService
        ) {
            super(injector);
            this.getProduct();
           /* this.exportAsXLSX();*/
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
       getProduct():SanPhamDto[]
       {
       /* this._apiService.get('api/Product/GetProductsByFilter').subscribe(result => {
            this.products = result.items;
        });*/
        this._productService.getProductsByFilter(null,"",500,0).subscribe(result => {
            this.products = result.items;
        });
           return this.products;
       }
        getProducts(event?: LazyLoadEvent) {
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

        reloadList(ProductName, event?: LazyLoadEvent) {
            this._productService.getProductsByFilter(ProductName, this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(this.paginator, event),
                this.primengTableHelper.getSkipCount(this.paginator, event),
            ).subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
        }

        deleteProduct(id): void {
            this._productService.deleteProduct(id).subscribe(() => {
                this.reloadPage();
            })
        }

        init(): void {
            //get params từ url để thực hiện filter
            this._activatedRoute.params.subscribe((params: Params) => {
             
                this.reloadList(this.ProductName, null);
            });
        }

        reloadPage(): void {
            this.paginator.changePage(this.paginator.getPage());
        }

        applyFilters(): void {
            //truyền params lên url thông qua router
            this.reloadList(this.ProductName, null);

            if (this.paginator.getPage() !== 0) {
                this.paginator.changePage(0);
                return;
            }
        }

        //hàm show view create MenuClient
        createProduct() {
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
            this.excelService.exportAsExcelFile( this.products,"Danh Sách Sản Phẩm");
          }
    }