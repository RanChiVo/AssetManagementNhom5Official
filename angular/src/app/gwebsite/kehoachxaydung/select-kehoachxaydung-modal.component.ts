import { CustomerForViewDto, KeHoachXayDungServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, Output, EventEmitter } from "@angular/core";
import { CustomerServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { ActivatedRoute, Params } from '@angular/router';
import { BatDongSanComponent } from '../batdongsan/batdongsan.component';
import { SelectKHCongTrinhModalComponent } from './select-khcongtrinh-modal.component';
import { NumericDictionary } from 'lodash';

@Component({
    selector: 'selectKeHoachXayDungModal',
    templateUrl: './select-kehoachxaydung-modal.component.html'
})

export class SelectKeHoachXayDungModalComponent extends AppComponentBase {

    customer : CustomerForViewDto = new CustomerForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('selectKHCongtrinhModal') selectKHCongtrinhModal: SelectKHCongTrinhModalComponent;
    constructor(
        injector: Injector,
        private _kehoachxaydungService: KeHoachXayDungServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    active=false;
    kehoachxaydungName: string;
    makehoachxaydung:string;
    nhomkehoachxaydung:string;
    loaikehoachxaydung:string;
    public selectedIDCongTrinh:number;
    selectedMaKH:string;
    //@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
     @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();


    show(customerId?: number | null | undefined): void {
        // this._kehoachxaydungService.getCustomerForView(customerId).subscribe(result => {
        //     this.customer = result;
        //     this.modal.show();
        // })
        //get params từ url để thực hiện filter
        this.selectedMaKH='';
        this.selectedIDCongTrinh=0;
        this._activatedRoute.params.subscribe((params: Params) => {
            this.kehoachxaydungName = params['TenKeHoachXayDung'] || '';
            this.makehoachxaydung = params['MaKeHoachXayDung'] || '';
            this.nhomkehoachxaydung= params['MaNhomKeHoachXayDung'] || '';
            this.loaikehoachxaydung= params['MaLoaiKeHoachXayDung'] || '';
            this.reloadList(this.kehoachxaydungName,this.makehoachxaydung,this.nhomkehoachxaydung,this.loaikehoachxaydung, null);
        });
           
            this.modal.show();

    }


    setActive():void{
        this.active=true;
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

 

    SetSelectedCongTrinhID():void{
        this.selectedIDCongTrinh=this.selectKHCongtrinhModal.selectedMaCongTrinh;
        // console.log("ID:"+ this.selectedIDCongTrinh);
        this.close()
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


    reloadList(kehoachxaydungName,makehoachxaydung,nhomkehoachxaydung,loaikehoachxaydung, event?: LazyLoadEvent) {
        this._kehoachxaydungService.getKeHoachXayDungsByFilter(null,makehoachxaydung,nhomkehoachxaydung,loaikehoachxaydung,kehoachxaydungName, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.kehoachxaydungName,this.makehoachxaydung,this.nhomkehoachxaydung,this.loaikehoachxaydung, null);
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    SetFilterSelectKHCongTrinh(kehoacName:string):void{
        this.selectKHCongtrinhModal.showCongTrinh=true;
        this.selectKHCongtrinhModal.show(kehoacName);
        this.selectedMaKH=kehoacName;
    }
  
    close() : void{
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
