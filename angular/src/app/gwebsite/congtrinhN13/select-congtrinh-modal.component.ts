import { CustomerForViewDto, CongTrinhServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
import { BatDongSanComponent } from '../batdongsan/batdongsan.component';

@Component({
    selector: 'selectCongTrinhModal',
    templateUrl: './select-congtrinh-modal.component.html'
})

export class SelectCongTrinhModalComponent extends AppComponentBase {

    customer : CustomerForViewDto = new CustomerForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    constructor(
        injector: Injector,
        private _congtrinhService: CongTrinhServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }


    maCongTrinh: string;
  
    maKeHoach:string;
    tenCongTrinh:string;
    public selectedMaTS:number;
   
    //@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
     @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(customerId?: number | null | undefined): void {
        // this._congtrinhService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.maCongTrinh = params['MaCongTrinh'] || '';
            this.maKeHoach= params['MaKeHoach'] || '';
            this.tenCongTrinh= params['TenCongTrinh'] || '';
            this.reloadList(this.maCongTrinh,this.maKeHoach,this.tenCongTrinh, null);
        });
            this.selectedMaTS=-1;
            this.modal.show();

    }


    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    selectedCongTrinh(mats):void{
        this.selectedMaTS=mats;
        this.close();
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

         this.reloadList(null,null,null, event);

    }


    reloadList(macongtrinh,maKeHoach,tenCongTrinh, event?: LazyLoadEvent) {
        this._congtrinhService.getCongTrinhsByFilter(macongtrinh,maKeHoach,tenCongTrinh, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.maCongTrinh,this.maKeHoach,this.tenCongTrinh, null);
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }


  
    close() : void{
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
