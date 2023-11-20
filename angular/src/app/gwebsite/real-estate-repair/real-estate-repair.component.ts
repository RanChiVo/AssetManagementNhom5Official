import { ViewRealEstateRepairModalComponent } from './view-real-estate-repair-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { RealEstateRepairServiceProxy, RealEstateServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditRealEstateRepairModalComponent } from './create-or-edit-real-estate-repair-modal.component';
import { RealEstateModalComponent } from './real-estate-modal';
import { ApprovedRealEstateRepairModalComponent } from './approved-real-estate-repair';
import { UpdateRealEstateRepairModalComponent } from './update-real-estate-repair-modal.component';

@Component({
    templateUrl: './real-estate-repair.component.html',
    animations: [appModuleAnimation()]
})
export class RealEstateRepairComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditRealEstateRepairModalComponent;
    @ViewChild('viewRealEstateRepairModal') viewRealEstateRepairModal: ViewRealEstateRepairModalComponent;
    @ViewChild('realEstateModal') realEstateModal: RealEstateModalComponent;
    @ViewChild('approvedRealEstateModal') approvedRealEstateModal: ApprovedRealEstateRepairModalComponent;
    @ViewChild('updateRealEstateRepairModal') updateRealEstateRepairModal: UpdateRealEstateRepairModalComponent;
    /**
     * tạo các biến dể filters
     */
               
    MaTaiSan: string;
    TenTaiSan: string;
    NgayDeXuat: string;
    NgaySuaChuaXong: string;
    NguoiDeXuat: string;
    NhanVienPhuTrach: string;
    TrangThaiDuyet: string;



    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    constructor(
        injector: Injector,
        private _realEstateRepairService: RealEstateRepairServiceProxy,
        private _realEstateService: RealEstateServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
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
    getRealEstateRepairs(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null, null, null,null,null,null, event);

    }

    showRealEstate(): void {
        this.realEstateModal.show()
    }

    reloadRealEstate(): void {
        this._realEstateService.getRealEstateForEdit(this.realEstateModal.pID).subscribe(result => {
        this.MaTaiSan = result.maTaiSan;
        })
    }

    reloadList(MaTaiSan, TenTaiSan, NgayDeXuat, NgaySuaChuaXong, NguoiDeXuat, NhanVienPhuTrach, TrangThaiDuyet, event?: LazyLoadEvent) {
        this._realEstateRepairService.getRealEstateRepairsByFilter(MaTaiSan, TenTaiSan, NgayDeXuat, NgaySuaChuaXong, NguoiDeXuat, NhanVienPhuTrach, TrangThaiDuyet, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount; 
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteRealEstateRepair(id): void {
        this._realEstateRepairService.deleteRealEstateRepair(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaTaiSan = params['MaTaiSan'] || '';
            this.TenTaiSan = params['TenTaiSan'] || '';
            this.NgayDeXuat = params['NgayDeXuat'] || '';
            this.NgaySuaChuaXong = params['NgaySuaChuaXong'] || '';
            this.NguoiDeXuat = params['NguoiDeXuat'] || '';
            this.NhanVienPhuTrach = params['NhanVienPhuTrach'] || '';
            this.TrangThaiDuyet = params['TrangThaiDuyet'] || '';


            this.reloadList(this.MaTaiSan, this.TenTaiSan, this.NgayDeXuat, this.NgaySuaChuaXong, this.NguoiDeXuat, this.NhanVienPhuTrach, this.TrangThaiDuyet, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaTaiSan, this.TenTaiSan, this.NgayDeXuat, this.NgaySuaChuaXong, this.NguoiDeXuat, this.NhanVienPhuTrach, this.TrangThaiDuyet, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createRealEstateRepair() {
        this.createOrEditModal.show();
    }

    updateRealEstateRepair(id: number , trangthai: string) {
        if (trangthai == "Đã duyệt") {
            this.updateRealEstateRepairModal.show(id);
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
