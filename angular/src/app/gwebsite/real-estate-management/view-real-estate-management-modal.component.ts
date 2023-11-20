import { RealEstateForViewDto_9, RealEstateRepairServiceProxy, RealEstateInput_9 } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, OnInit, EventEmitter, Output } from "@angular/core";
import { RealEstateServiceProxy } from "@shared/service-proxies/service-proxies";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { ModalDirective } from 'ngx-bootstrap';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import * as _ from 'lodash';

@Component({
    selector: 'viewRealEstateModal',
    templateUrl: './view-real-estate-management-modal.component.html'
})

export class ViewRealEstateModalComponent extends AppComponentBase  {

    
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('viewModal') modal: ModalDirective;
    /**
     * tạo các biến dể filters
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    constructor(
        injector: Injector,
        private _realEstateService: RealEstateServiceProxy,
        private _realEstateRepairService: RealEstateRepairServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    //realEstate: RealEstateInput_9 = new RealEstateInput_9();
    realEstate: RealEstateForViewDto_9 = new RealEstateForViewDto_9();

    show(realEstateID): void {

        this._realEstateService.getRealEstateForView(realEstateID).subscribe(result => {
            this.realEstate = result;
            this._activatedRoute.params.subscribe((params: Params) => {            
                this.reloadList(this.realEstate.maTaiSan, null);
            })
            this.modal.show();
        })
        
        
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /**
     * Hàm get danh sách TaiSan
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

        this.reloadList(this.realEstate.maTaiSan, event);

    }


    reloadList(MaTaiSan, event?: LazyLoadEvent) {
        this._realEstateRepairService.getRealEstateRepairsByFilter(MaTaiSan, null, null, null, null, null , null, this.primengTableHelper.getSorting(this.dataTable),
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
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
