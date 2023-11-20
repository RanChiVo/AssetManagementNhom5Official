import { ViewTaiSanModalComponent } from './view-taisan-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { TaiSanServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditTaiSanModalComponent } from './create-or-edit-taisan-modal.component';
import { ModalDirective } from 'ngx-bootstrap';

@Component({

    templateUrl: './taisan.component.html',
    selector: 'TaiSanModal',
    animations: [appModuleAnimation()]
})
export class TaiSanComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditTaiSanModalComponent;
    @ViewChild('viewTaiSanModal') viewTaiSanModal: ViewTaiSanModalComponent;
    @ViewChild('TaiSanModal') modal: ModalDirective;
    /**
     * tạo các biến dể filters
     */
    taisanName: string;
    mataisan:string;
    nhomtaisan:string;
    loaitaisan:string;
    constructor(
        injector: Injector,
        private _taisanService: TaiSanServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        
    }



    show():void{
        this.modal.show();
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
     * Hàm get danh sách TaiSan
     * @param event
     */
    getTaiSans(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null,null,null, event);

    }

    reloadList(taisanName,mataisan,nhomtaisan,loaitaisan, event?: LazyLoadEvent) {
        this._taisanService.getTaiSansByFilter(mataisan,nhomtaisan,loaitaisan,taisanName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteTaiSan(id): void {
        this._taisanService.deleteTaiSan(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.taisanName = params['TenTaiSan'] || '';
            this.mataisan = params['MaTaiSan'] || '';
            this.nhomtaisan= params['MaNhomTaiSan'] || '';
            this.loaitaisan= params['MaLoaiTaiSan'] || '';
            this.reloadList(this.taisanName,this.mataisan,this.nhomtaisan,this.loaitaisan, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.taisanName,this.mataisan,this.nhomtaisan,this.loaitaisan, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createTaiSan() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
