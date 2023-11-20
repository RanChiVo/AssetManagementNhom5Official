import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { KeHoachXayDungServiceProxy, KeHoachXayDungInput, CongTrinhServiceProxy, CongTrinhInput } from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { CreateOrEditCongTrinhModalComponent } from '../congtrinhN13/create-or-edit-congtrinh-modal.component';

@Component({
    selector: 'createOrEditKeHoachXayDungModal',
    templateUrl: './create-or-edit-kehoachxaydung-modal.component.html'
})
export class CreateOrEditKeHoachXayDungModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModalA') modal: ModalDirective;
    @ViewChild('kehoachxaydungCombobox') kehoachxaydungCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditCongTrinhModalComponent;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    kehoachxaydung: KeHoachXayDungInput = new KeHoachXayDungInput();

    dsCongtrinh: Array<CongTrinhInput> = [];
    cttest: CongTrinhInput = new CongTrinhInput();
    constructor(
        injector: Injector,
        private _kehoachxaydungService: KeHoachXayDungServiceProxy,
        private _congtrinhService: CongTrinhServiceProxy,
    ) {
        super(injector);
    }

    show(kehoachxaydungId?: number | null | undefined): void {
        //reset list when modal show
        this.dsCongtrinh = [];
        this.saving = false;


        this._kehoachxaydungService.getKeHoachXayDungForEdit(kehoachxaydungId).subscribe(result => {
            this.kehoachxaydung = result;
            this.modal.show();

        })
    }

    getCongTrinhs(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(event);

    }

    createCongTrinh() {

        this.createOrEditModal.show();
    }

    save(): void {
        this.kehoachxaydung.trangThaiDuyet = "checked";
        let kinhphi=0;
        this.kehoachxaydung.maKeHoach="A"+this.kehoachxaydung.namThucHien;
        for (let item of this.dsCongtrinh) {
            kinhphi+=item.kinhPhiDuocDuyet;
        }
        this.kehoachxaydung.kinhPhiDuocDuyet=kinhphi.toString();
        let input = this.kehoachxaydung;
        this.saving = true;
        this._kehoachxaydungService.createOrEditKeHoachXayDung(input).subscribe(result => {
            for (let item of this.dsCongtrinh) {
                let inputCT = item;
                inputCT.maKeHoach=this.kehoachxaydung.maKeHoach;
                this._congtrinhService.createOrEditCongTrinh(inputCT).subscribe(result => {
                    this.notify.info(this.l('SavedCongTrinh'));
                })
                console.log("Luu tt CT");
            }
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })


    }

    saveCongTrinh(congtrinh: CongTrinhInput) {
        let input = congtrinh;
        input.maKeHoach = this.kehoachxaydung.maKeHoach;
        this._congtrinhService.createOrEditCongTrinh(input).subscribe(result => {
            this.notify.info(this.l('SavedCongTrinh'));
        })
    }

    reloadList(event?: LazyLoadEvent) {

        // this.primengTableHelper.getMaxResultCount(this.paginator, event),
        // this.primengTableHelper.getSkipCount(this.paginator, event),
        // this.primengTableHelper.totalRecordsCount = this.dsCongtrinh.length;

        // this.primengTableHelper.records = result.items;
        // this.primengTableHelper.hideLoadingIndicator();
        // this._congtrinhService.getCongTrinhsByFilter(null, null, null, this.primengTableHelper.getSorting(this.dataTable),
        //     this.primengTableHelper.getMaxResultCount(this.paginator, event),
        //     this.primengTableHelper.getSkipCount(this.paginator, event),
        // ).subscribe(result => {
        //     this.primengTableHelper.totalRecordsCount = result.totalCount;
        //     this.primengTableHelper.records = result.items;
        //     this.primengTableHelper.hideLoadingIndicator();
        // });

    }

    loadDSCongTrinh() {
        this.dsCongtrinh.push(this.createOrEditModal.congtrinh);
    }
    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
