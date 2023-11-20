import { CustomerForViewDto, ConstructionServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
@Component({
    selector: 'selectionConstructionInPlan',
    templateUrl: './select-construction-in-plan.modal.conponent.html'
})

export class SelectionConstructionInPlanModalComponent extends AppComponentBase {


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

    showCongTrinh: boolean = false;
    public pConstructionID: number;

    //@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(maKeHoach): void {
       
        this._activatedRoute.params.subscribe((params: Params) => {         
            this.reloadList(maKeHoach, null);
        });
        if (this.showCongTrinh == false)
            this.modal.show();
        else
            this.modal.hide();
    }



    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    SeletionConstruction(ID): void {
        this.pConstructionID = ID;
        this.close();
    }

    /**
     * Hàm get danh sách CongTrinh
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

        this.reloadList(null, event);

    }


    reloadList(maKeHoach, event?: LazyLoadEvent) {

        this._constructionService.getConstructionsByFilter(null, null, maKeHoach, null, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }


    close(): void {
        this.modal.hide();
        this.showCongTrinh = false;
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
