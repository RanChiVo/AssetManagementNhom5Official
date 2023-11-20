import { ViewLoaiNhaCungCapModalComponent } from './view-LoaiNhaCungCap-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { LoaiNhaCungCapServiceProxy, NhaCungCapHangHoaServiceProxy, NhaCungCapHangHoaDto, LoaiNhaCungCapDto } from '@shared/service-proxies/service-proxies';
import { CreateOrEditLoaiNhaCungCapModalComponent } from './create-or-edit-LoaiNhaCungCap-modal.component';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
/*import { RegisterTenantResultComponent } from 'account/register/register-tenant-result.component';*/
import {ExcelService} from '../services/excel.service';
    @Component({
        templateUrl: './LoaiNhaCungCap.component.html',
        animations: [appModuleAnimation()]
    })
    export class LoaiNhaCungCapComponent extends AppComponentBase implements AfterViewInit, OnInit {

        /**
        * @ViewChild là dùng get control và call thuộc tính, functions của control đó
        */
        @ViewChild('dataTable') dataTable: Table;
        @ViewChild('paginator') paginator: Paginator;
        @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditLoaiNhaCungCapModalComponent;
        @ViewChild('viewLoaiNhaCungCapModal') viewLoaiNhaCungCapModal: ViewLoaiNhaCungCapModalComponent;

        /**
        * tạo các biến dể filters
        */
        LoaiNhaCungCapName: string;
        MaLoaiNhaCungCapHangHoa: string;
        nhaCungCapHangHoas: Array<NhaCungCapHangHoaDto>=[];
        loaiNhaCungCaps:Array<LoaiNhaCungCapDto>=[];

        constructor(
            injector: Injector,
            private _loaiNhaCungCapService: LoaiNhaCungCapServiceProxy,
            private _nhaCungCapHangHoaService: NhaCungCapHangHoaServiceProxy,
            private _activatedRoute: ActivatedRoute,
            private _apiService: WebApiServiceProxy,
            private excelService: ExcelService
        ) {
            super(injector);
            this.getNhaCungCapHangHoa(this.MaLoaiNhaCungCapHangHoa);
            this.getNhaCungCapHangHoas(this.MaLoaiNhaCungCapHangHoa);
            /*this.exportAsXLSX();*/
            this.getLoaiNhaCungCap();
            
        }
        getLoaiNhaCungCap():LoaiNhaCungCapDto[]
        {
            this._apiService.get('api/LoaiNhaCungCap/GetLoaiNhaCungCapsByFilter').subscribe(result => {
                this.loaiNhaCungCaps = result.items;
            });
            return this.loaiNhaCungCaps;
        }
        getNhaCungCapHangHoa(MaLoaiNhaCungCapHangHoa):void
        {
            this._apiService.get('api/NhaCungCapHangHoa/GetAllNhaCungCapHangHoasByFilter?MaLoaiNhaCungCap='+MaLoaiNhaCungCapHangHoa).subscribe(result => {
                this.nhaCungCapHangHoas = result.items;
            });
        console.log('api/NhaCungCapHangHoa/GetAllNhaCungCapHangHoasByFilter?MaLoaiNhaCungCap='+MaLoaiNhaCungCapHangHoa);
        }
        getNhaCungCapHangHoas(MaLoaiNhaCungCapHangHoa) : NhaCungCapHangHoaDto[]
        {
            this._apiService.get('api/NhaCungCapHangHoa/GetAllNhaCungCapHangHoasByFilter?MaLoaiNhaCungCap='+MaLoaiNhaCungCapHangHoa).subscribe(result => {
                this.nhaCungCapHangHoas = result.items;
            });
        console.log('api/NhaCungCapHangHoa/GetAllNhaCungCapHangHoasByFilter?MaLoaiNhaCungCap='+MaLoaiNhaCungCapHangHoa);
        for(var i=0; i< this.nhaCungCapHangHoas.length; i++)
        {
            console.log(this.nhaCungCapHangHoas[i].maNhaCungCap);
            console.log(this.nhaCungCapHangHoas[i].tenNhaCungCap);
            console.log(this.nhaCungCapHangHoas[i].maLoaiNhaCungCap);
            console.log(this.nhaCungCapHangHoas[i].soDienThoai);
            console.log(this.nhaCungCapHangHoas[i].nguoiLienHe);
            console.log(this.nhaCungCapHangHoas[i].ghiChu);
            console.log(this.nhaCungCapHangHoas[i].diaChi);
            console.log(this.nhaCungCapHangHoas[i].email);
            console.log(this.nhaCungCapHangHoas[i].hoatDong);

        }
        return this.nhaCungCapHangHoas;
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
        getLoaiNhaCungCaps(event?: LazyLoadEvent) {
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

        reloadList(LoaiNhaCungCapName, event?: LazyLoadEvent) {
            this._loaiNhaCungCapService.getLoaiNhaCungCapsByFilter(LoaiNhaCungCapName, this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(this.paginator, event),
                this.primengTableHelper.getSkipCount(this.paginator, event),
            ).subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
        }
       

        deleteLoaiNhaCungCap(id): void {
            this._loaiNhaCungCapService.deleteLoaiNhaCungCap(id).subscribe(() => {
                this.reloadPage();
            })
        }

        init(): void {
            //get params từ url để thực hiện filter
            this._activatedRoute.params.subscribe((params: Params) => {
              //  this.LoaiNhaCungCapName = params['name'] || '';
                this.reloadList(this.LoaiNhaCungCapName, null);
            });
        }

        reloadPage(): void {
            this.paginator.changePage(this.paginator.getPage());
        }

        applyFilters(): void {
            //truyền params lên url thông qua router
            this.reloadList(this.LoaiNhaCungCapName, null);

            if (this.paginator.getPage() !== 0) {
                this.paginator.changePage(0);
                return;
            }
        }

        //hàm show view create MenuClient
        createLoaiNhaCungCap() {
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
            this.excelService.exportAsExcelFile(this.getLoaiNhaCungCap(),"Loại Nhà Cung Cấp Hàng Hóa");
          }
    }