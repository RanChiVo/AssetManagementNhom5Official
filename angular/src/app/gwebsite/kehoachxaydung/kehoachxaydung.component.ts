import { ViewKeHoachXayDungModalComponent } from './view-kehoachxaydung-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { KeHoachXayDungServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditKeHoachXayDungModalComponent } from './create-or-edit-kehoachxaydung-modal.component';
import { ModalDirective } from 'ngx-bootstrap';
import { SelectKeHoachXayDungModalComponent } from './select-kehoachxaydung-modal.component';

@Component({
    templateUrl: './kehoachxaydung.component.html',
    selector: 'KeHoachXayDungModal',
    animations: [appModuleAnimation()]
})
export class KeHoachXayDungComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditKeHoachXayDungModalComponent;
    @ViewChild('viewKeHoachXayDungModal') viewKeHoachXayDungModal: ViewKeHoachXayDungModalComponent;
    @ViewChild('selectKeHoachXayDungModal') selectKeHoachXayDungModal:SelectKeHoachXayDungModalComponent;
    @ViewChild('KeHoachXayDungModal') modal: ModalDirective;
  
    /**
     * tạo các biến dể filters
     */
    kehoachxaydungName: string;
    makehoachxaydung:string;
    nhomkehoachxaydung:string;
    loaikehoachxaydung:string;
    constructor(
        injector: Injector,
        private _kehoachxaydungService: KeHoachXayDungServiceProxy,
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
     * Hàm get danh sách KeHoachXayDung
     * @param event
     */
    getKeHoachXayDungs(event?: LazyLoadEvent) {
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

    reloadList(tenkh,makh,trangthai,them, event?: LazyLoadEvent) {
        this._kehoachxaydungService.getKeHoachXayDungsByFilter(null,null,null,null,null, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteKeHoachXayDung(id): void {
        this._kehoachxaydungService.deleteKeHoachXayDung(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.kehoachxaydungName = params['TenKeHoachXayDung'] || '';
            this.makehoachxaydung = params['MaKeHoachXayDung'] || '';
            this.nhomkehoachxaydung= params['MaNhomKeHoachXayDung'] || '';
            this.loaikehoachxaydung= params['MaLoaiKeHoachXayDung'] || '';
            this.reloadList(this.kehoachxaydungName,this.makehoachxaydung,this.nhomkehoachxaydung,this.loaikehoachxaydung, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.kehoachxaydungName,this.makehoachxaydung,this.nhomkehoachxaydung,this.loaikehoachxaydung, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createKeHoachXayDung() {
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
