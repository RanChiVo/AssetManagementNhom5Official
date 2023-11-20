import { ViewNhaCungCapHangHoaModalComponent } from './view-NhaCungCapHangHoa-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { NhaCungCapHangHoaServiceProxy, SanPhamDto, NhaCungCapHangHoaDto ,SanPhamServiceProxy} from '@shared/service-proxies/service-proxies';
import { CreateOrEditNhaCungCapHangHoaModalComponent } from './create-or-edit-NhaCungCapHangHoa-modal.component';
import {WebApiServiceProxy} from '@shared/service-proxies/webapi.service';
import {ExcelService} from '../services/excel.service';
import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { max } from 'moment';
import { MAX_LENGTH_VALIDATOR } from '@angular/forms/src/directives/validators';


    @Component({
        templateUrl: './NhaCungCapHangHoa.component.html',
        animations: [appModuleAnimation()]
    })
    export class NhaCungCapHangHoaComponent extends AppComponentBase implements AfterViewInit, OnInit {

        /**
        * @ViewChild là dùng get control và call thuộc tính, functions của control đó
        */
        @ViewChild('dataTable') dataTable: Table;
        @ViewChild('paginator') paginator: Paginator;
        @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditNhaCungCapHangHoaModalComponent;
        @ViewChild('viewNhaCungCapHangHoaModal') viewNhaCungCapHangHoaModal: ViewNhaCungCapHangHoaModalComponent;

        /**
        * tạo các biến dể filters
        */
        NhaCungCapHangHoaName: string;
        MaNhaCungCapHangHoa: string;
        sl:string;
        products: Array<SanPhamDto>=[];
        products1:Array<SanPhamDto>=[];
        nhaCungCapHangHoa: Array<NhaCungCapHangHoaDto>=[];
        config: any;
        constructor(
            injector: Injector,
            private _nhaCungCapHangHoaService: NhaCungCapHangHoaServiceProxy,
            private _activatedRoute: ActivatedRoute,
            private _apiService: WebApiServiceProxy,
            private excelService: ExcelService,
            private _productService: SanPhamServiceProxy
        ) {
            super(injector);
            /*this.getProducts(this.MaNhaCungCapHangHoa);*/
            this.getNhaCungCapHangHoa();
            /*this.exportAsXLSX();*/
            this.config = {
                itemsPerComponent: 5,
                currentComponent: 1,
                totalItems: this.products.length
              };
            this.pageChanged(event);
        }

        getNhaCungCapHangHoa(): NhaCungCapHangHoaDto[]
        {
            /*this._apiService.get('api/NhaCungCapHangHoa/GetNhaCungCapHangHoasByFilter').subscribe(result => {
                this.nhaCungCapHangHoa = result.items;
            });*/
            this._nhaCungCapHangHoaService.getAllNhaCungCapHangHoasByFilter(null,"",1000,0).subscribe(result => {
                this.nhaCungCapHangHoa = result.items;
            });
            return this.nhaCungCapHangHoa;
        }
        getProducts(MaNhaCungCapHangHoa): SanPhamDto[]
        {
            /*this._apiService.get('api/Product/GetProductsByFilterName?MaNhaCungCap='+MaNhaCungCapHangHoa).subscribe(result=>{
                this.products1=result.items;
               
            })
            
            this._productService.getProductsByFilterName(MaNhaCungCapHangHoa,"",500,0).subscribe(result=>{
                this.products=result.items;
            });*/
            this._productService.getProductsByFilterName(MaNhaCungCapHangHoa,"",500,0).subscribe(result=>{
                this.products=result.items;
            });
            return this.products;
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
        getNhaCungCapHangHoas(event?: LazyLoadEvent) {
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

        reloadList(NhaCungCapHangHoaName, event?: LazyLoadEvent) {
            this._nhaCungCapHangHoaService.getNhaCungCapHangHoasByFilter(NhaCungCapHangHoaName, this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(this.paginator, event),
                this.primengTableHelper.getSkipCount(this.paginator, event),
            ).subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
        }

        deleteNhaCungCapHangHoa(id): void {
            this._nhaCungCapHangHoaService.deleteNhaCungCapHangHoa(id).subscribe(() => {
                this.reloadPage();
            })
        }

        init(): void {
            //get params từ url để thực hiện filter
            this._activatedRoute.params.subscribe((params: Params) => {
                //this.NhaCungCapHangHoaName = params['name'] || '';
                this.reloadList(this.NhaCungCapHangHoaName, null);
            });
        }

        reloadPage(): void {
            this.paginator.changePage(this.paginator.getPage());
        }

        applyFilters(): void {
            //truyền params lên url thông qua router
            this.reloadList(this.NhaCungCapHangHoaName, null);

            if (this.paginator.getPage() !== 0) {
                this.paginator.changePage(0);
                return;
            }
        }

        //hàm show view create MenuClient
        createNhaCungCapHangHoa() {
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
            this.excelService.exportAsExcelFile( this.nhaCungCapHangHoa,"Nhà Cung Cấp Hàng Hóa");
          }
          pageChanged(event){
            this.config.currentComponent = event;
        
          }
    }