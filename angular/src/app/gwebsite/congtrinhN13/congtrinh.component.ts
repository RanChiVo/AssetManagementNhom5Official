import { ViewCongTrinhModalComponent } from './view-congtrinh-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CongTrinhServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditCongTrinhModalComponent } from './create-or-edit-congtrinh-modal.component';
import { ModalDirective } from 'ngx-bootstrap';
import { CreateCongTrinhModalComponent } from './create-congtrinh-modal.component';

@Component({

    templateUrl: './congtrinh.component.html',
    selector: 'CongTrinhModal',
    animations: [appModuleAnimation()]
})
export class CongTrinhComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createCongTrinhModal') createCongTrinhModal: CreateCongTrinhModalComponent;
    @ViewChild('CongTrinhModal') modal: ModalDirective;
    /**
     * tạo các biến dể filters
     */
    congtrinhName: string;
    macongtrinh: string;
    maKeHoach: string;
    loaicongtrinh: string;

    /**
     * Tab values
     */
    activeTabSuaChua = true;
    activeTabCreate = false;
    activeTabUpdate = false;
    activeTabView = false;
    activeTabSetActive = false;

    disableTabUpdate = true;
    disableTabView = true;
    disableTabSetActive = true;
    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy,
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
     * Tab funtion
     */

    InitTabCongTrinh(): void {

        this.reloadList(null, null, null);
        this.activeTabCreate = false;
        this.activeTabUpdate = false;
        this.activeTabView = false;
        this.activeTabSetActive = false;

        this.disableTabUpdate = true;
        this.disableTabView = true;
        this.disableTabSetActive = true;


    }
    InitTabCreate(): void {
        this.activeTabSuaChua = false;
        this.activeTabUpdate = false;
        this.activeTabView = false;
        this.activeTabSetActive = false;


        this.disableTabView = true;
        this.disableTabUpdate = true;
        this.disableTabSetActive = true;
        this.createCongTrinhModal.reset();
    }

    InitTabView(idRecond: number): void {
        this.disableTabView = false;
        this.activeTabView = true;

        this.activeTabSuaChua = false;
        this.activeTabUpdate = false;
        this.activeTabCreate = false;
        this.activeTabSetActive = false;

        this.disableTabSetActive = true;
        this.disableTabUpdate = true;
    }

    InitTabUpdate(idRecond: number) {
        this.disableTabUpdate = false;
        this.activeTabUpdate = true;
        this.disableTabView = true;
        this.disableTabSetActive = true;

        this.activeTabSuaChua = false;
        this.activeTabView = false;
        this.activeTabCreate = false;
        this.activeTabSetActive = false;
    }

    InitTabActive(idRecond: number) {
        console.log("ID recond" + idRecond);
        this.disableTabSetActive = false;
        this.activeTabSetActive = true;
        this.disableTabView = true;
        this.disableTabUpdate = true;

        this.activeTabSuaChua = false;
        this.activeTabView = false;
        this.activeTabCreate = false;
        this.activeTabUpdate = false;
    }

    GetDisableTabView(): boolean {
        return this.disableTabView;
    }
    GetDisableTabUpdate(): boolean {
        return this.disableTabUpdate;
    }

    GetDisableTabActive(): boolean {
        return this.disableTabSetActive;
    }

    /**
     * Component funtions
     */
    show(): void {
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
     * Hàm get danh sách CongTrinh
     * @param event
     */
    getCongTrinhs(event?: LazyLoadEvent) {
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

    reloadList(congtrinhName, macongtrinh, maKeHoach, event?: LazyLoadEvent) {
        this._congtrinhService.getDsCongTrinhThuocDuAnByFilter(macongtrinh, maKeHoach, congtrinhName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteCongTrinh(id): void {
        this._congtrinhService.deleteCongTrinh(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.congtrinhName = params['TenCongTrinh'] || '';
            this.macongtrinh = params['MaCongTrinh'] || '';
            this.maKeHoach = params['MamaKeHoach'] || '';
            this.loaicongtrinh = params['MaLoaiCongTrinh'] || '';
            this.reloadList(this.congtrinhName, this.macongtrinh, this.maKeHoach, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.congtrinhName, this.macongtrinh, this.maKeHoach, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createCongTrinh() {

        this.createCongTrinhModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
