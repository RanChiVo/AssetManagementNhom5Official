import { CustomerForViewDto, PlanServiceProxy, ConstructionServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
import { NumericDictionary } from 'lodash';

@Component({
    selector: 'selectConstructionModal',
    templateUrl: './select-construction-modal.component.html'
})

export class SelectionConstructionModalComponent extends AppComponentBase {

    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    constructor(
        injector: Injector,
        private _constructionService: ConstructionServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    MaCongTrinh: string;
    TenCongTrinh: string;
    MaKeHoach: string;
    NgayThucThiThucTe: string;
    public pConstructionID: number;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(): void {

        this.pConstructionID = 0;
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaCongTrinh = params['MaCongTrinh'] || '';
            this.TenCongTrinh = params['TenCongTrinh'] || '';
            this.MaKeHoach = params['MaKeHoach'] || '';
            this.NgayThucThiThucTe = params['NgayThucThiThucTe'] || '';
            this.reloadList(this.MaCongTrinh, this.TenCongTrinh, this.MaKeHoach, this.NgayThucThiThucTe, null);
        });

        this.modal.show();

    }


    //setActive(): void {
    //    this.active = true;
    //}
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }



    SelectConstruction(ID): void {
        this.pConstructionID = ID;
        this.close()
    }


    /**
     * Hàm get danh sách Plan
     * @param event
     */
    getConstructions(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, null, event);

    }

    reloadList(MaCT, TenCT, MaKH, NgayThucThiThucTe, event?: LazyLoadEvent) {
        this._constructionService.getConstructionsByFilter(MaCT, TenCT, MaKH, NgayThucThiThucTe, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }



    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MaCongTrinh, this.TenCongTrinh, this.MaKeHoach, this.NgayThucThiThucTe, null);
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }


    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
