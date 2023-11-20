import { AssetController_9ServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'assetModal',
    templateUrl: './asset-component.html',
})

export class AssetComponent9 extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('assetModal') modal: ModalDirective;
    /**
     * tạo các biến dể filters
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    public pmaTaiSan: string;

    constructor(
        injector: Injector,
        private _assetService: AssetController_9ServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {  
        super(injector);
    }
    MaTaiSan: string;
    LoaiTaiSan: string;

    

    show(): void {

        this._activatedRoute.params.subscribe((params: Params) => {
            this.MaTaiSan = params['MaTaiSan'] || '';
            this.LoaiTaiSan = params['LoaiTaiSan'] || '';
            this.reloadList(this.MaTaiSan, this.LoaiTaiSan, null);
        })

       this.modal.show();
   }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

   selectionMTS(mts): void {
       this.pmaTaiSan = mts;
       close();
   }
    /**
     * Hàm get danh sách TaiSan
     * @param event
     */
    getAssets(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, event);

    }


    reloadList(MaTaiSan, LoaiTaiSan, event?: LazyLoadEvent) {
        this._assetService.getAssetsByFilter(MaTaiSan, LoaiTaiSan, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.MaTaiSan, this.LoaiTaiSan, null);

    }



    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
