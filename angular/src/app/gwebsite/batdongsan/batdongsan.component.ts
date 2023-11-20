import { ViewBatDongSanModalComponent } from './view-batdongsan-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { BatDongSanServiceProxy, TaiSanInput } from '@shared/service-proxies/service-proxies';
import { CreateOrEditBatDongSanModalComponent } from './create-or-edit-batdongsan-modal.component';
import { TaiSanComponent } from '../taisan/taisan.component';
import { LoaiBatDongSanDto } from '../loaibatdongsan/dto/loaibatdongsandto';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import { TaiSanDto } from '../taisan/Dto/taisandto';
import { SelectTaiSanModalComponent } from '../taisan/select-taisan-modal.component';
import { Constain } from '../constain/constain';

@Component({
    selector: 'batdongsanComponent',
    templateUrl: './batdongsan.component.html',
    animations: [appModuleAnimation()]
})
export class BatDongSanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditBatDongSanModalComponent;
    @ViewChild('selectTaiSanModel') selectTaiSanModel: SelectTaiSanModalComponent;
    @ViewChild('viewBatDongSanModal') viewBatDongSanModal: ViewBatDongSanModalComponent;
    @ViewChild('taiSanModel') taiSanModel: TaiSanComponent;

    /**
     * tạo các biến dể filters
     */
    batdongsanName: string;
    mataisanName: string;
    maloaibds: string;
    taisan: TaiSanInput = new TaiSanInput();
    listItems: Array<LoaiBatDongSanDto> = [];
    listTaiSans: Array<TaiSanDto> = [];
    selectedLBDS: number;
    selectedTaiSan: number;
    // dùng để gọi từ conponent khác
    // @Input() selectedMaTaiSan:string;

    constructor(
        injector: Injector,
        private _batdongsanService: BatDongSanServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
        this.getListTypes();
       // this.getListTaiSan();
    }


    getListTypes(): void {
        // get loaibatdongsan type
        this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
            this.listItems = result.items;
        });
    }


    getListTaiSan(): void {

        this._apiService.get('api/TaiSan/GetTaiSansByFilter').subscribe(result => {
            this.listTaiSans = result.items;

        });
    }

    onChangeTaiSan(): void {
        this._apiService.getForEdit('api/TaiSan/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
            this.mataisanName = result.maTaiSan;
            this.taisan.maTaiSan = result.maTaiSan;
            this.taisan.diaChi = result.diaChi;
            this.taisan.tenTaiSan = result.tenTaiSan;
            this.taisan.maNhomTaiSan = result.maNhomTaiSan;
            this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
            this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
            this.taisan.ghiChu = result.ghiChu;
        });
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
     * Hàm get danh sách BatDongSan
     * @param event
     */
    getBatDongSans(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, event);

    }



    reloadList(batdongsanName, maloaibds, mataisanName, event?: LazyLoadEvent) {
        this._batdongsanService.getBatDongSansByFilter(batdongsanName, maloaibds, mataisanName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteBatDongSan(id): void {
        this._batdongsanService.deleteBatDongSan(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.batdongsanName = params['MaBatDongSan'] || '';
            this.maloaibds = params['MaLoaiBDS'] || '';
            this.mataisanName = params['MaTaiSan'] || '';
            this.reloadList(this.batdongsanName, this.maloaibds, this.mataisanName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.batdongsanName, this.maloaibds, this.mataisanName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    reset(): void {
        this.batdongsanName = "";
        this.mataisanName = "";
        this.maloaibds = "";
        this.taisan.maTaiSan = "";
        this.taisan.diaChi = "";
        this.taisan.tenTaiSan = "";
        this.taisan.maNhomTaiSan = "";
        this.taisan.maLoaiTaiSan = "";
        this.taisan.nguyenGiaTaiSan = null;
        this.taisan.ghiChu = "";
        this.selectedLBDS = 0;
        this.selectedTaiSan = 0;
        this.applyFilters();

    }
    //hàm show view create MenuClient
    createBatDongSan() {
        this.createOrEditModal.show();
    }

    selectTaiSan() {
        if (Constain.showConsoleLog)
        {
            console.log("mo modal");
        }
            
        this.selectTaiSanModel.show();

    }

    updateTaiSan() {
        if (Constain.showConsoleLog)
        {
            console.log("Update data");
        }
        if(this.selectTaiSanModel.selectedMaTS!=-1){
            this.selectedTaiSan=this.selectTaiSanModel.selectedMaTS;
            this._apiService.getForEdit('api/TaiSan/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
                this.mataisanName = result.maTaiSan;
                this.taisan.maTaiSan = result.maTaiSan;
                this.taisan.diaChi = result.diaChi;
                this.taisan.tenTaiSan = result.tenTaiSan;
                this.taisan.maNhomTaiSan = result.maNhomTaiSan;
                this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
                this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
                this.taisan.ghiChu = result.ghiChu;
            });
        }

    }   




    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
