import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BatDongSanServiceProxy, BatDongSanInput, LoaiBatDongSanDto, LoaiSoHuuDto, TaiSanInput, TaiSanDto } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
import * as moment from 'moment';
import { ViewBatDongSanModalComponent } from './view-batdongsan-modal.component';
import { SelectTaiSanModalComponent } from '../taisan/select-taisan-modal.component';
import { Constain } from '../constain/constain';
@Component({
    selector: 'createOrEditBatDongSanModal',
    templateUrl: './create-or-edit-batdongsan-modal.component.html'
})
export class CreateOrEditBatDongSanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('batdongsanCombobox') batdongsanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('SampleDateTimePicker') sampleDateTimePicker: ElementRef;
    @ViewChild('viewBatDongSanModal') viewBatDongSanModal: ViewBatDongSanModalComponent;
    @ViewChild('selectTaiSanModel') selectTaiSanModel: SelectTaiSanModalComponent;
    selectedLBDS: number; //get selectedLBDS id for edit
    selectedLSH: number;

    selectedTaiSan: number;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    batdongsan: BatDongSanInput = new BatDongSanInput();
    taisan: TaiSanInput = new TaiSanInput();


    constructor(
        injector: Injector,
        private _batdongsanService: BatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,

    ) {
        super(injector);
        this.getListTypes();// fill data to list loaibatdongsan when component created
        this.getListLoaiSoHuu();// binding data to list loaisohuu when component created
        this.getListTaiSan();

    }

    listItems: Array<LoaiBatDongSanDto> = [];
    loaibatdongsan: LoaiBatDongSanDto = new LoaiBatDongSanDto();
    listLSH: Array<LoaiSoHuuDto> = [];
    loaisohuu: LoaiSoHuuDto = new LoaiSoHuuDto();

    listTaiSans: Array<TaiSanDto> = [];
    static test: number;
    getListTypes(): void {
        
        // get loaibatdongsan type
        this._apiService.get('api/LoaiBatDongSan/GetLoaiBatDongSansByFilter').subscribe(result => {
            this.listItems = result.items;
        });
    }

    getListLoaiSoHuu(): void {
        this._apiService.get('api/LoaiSoHuu/GetLoaiSoHuusByFilter').subscribe(result => {
            this.listLSH = result.items;
        });
    }


    getListTaiSan(): void {

        this._apiService.get('api/TaiSan/GetTaiSansByFilter').subscribe(result => {
            this.listTaiSans = result.items;

        });
    }

    onChangeTaiSan(): void {

        this._apiService.getForEdit('api/TaiSan/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
            // this.batdongsan.maTaiSan = result.maTaiSan;
            this.taisan.maTaiSan = result.maTaiSan;
            this.taisan.diaChi = result.diaChi;
            this.taisan.tenTaiSan = result.tenTaiSan;
            this.taisan.maNhomTaiSan = result.maNhomTaiSan;
            this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
            this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
            this.taisan.ghiChu = result.ghiChu;
        });
    }

    updateTaiSan(): void {
        console.log("update data");
        if (this.selectTaiSanModel.selectedMaTS != -1) {
            this.selectedTaiSan = this.selectTaiSanModel.selectedMaTS;
            this._apiService.getForEdit('api/TaiSan/GetTaiSanForView', this.selectedTaiSan).subscribe(result => {
                // this.batdongsan.maTaiSan = result.maTaiSan;
                this.taisan.maTaiSan = result.maTaiSan;
                this.taisan.diaChi = result.diaChi;
                this.taisan.tenTaiSan = result.tenTaiSan;
                this.taisan.maNhomTaiSan = result.maNhomTaiSan;
                this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
                this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
                this.taisan.ghiChu = result.ghiChu;
            });
        }

    }



    // onChangeLSH(): void {
    //     this._apiService.getForEdit('api/LoaiSoHuu/GetLoaiSoHuuForView', this.selectedLSH).subscribe(result => {
    //         this.batdongsan.maLoaiSoHuu = result.name;

    //     });
    // }



    show(batdongsanId?: number | null | undefined): void {
        this.saving = false;


        this._batdongsanService.getBatDongSanForEdit(batdongsanId).subscribe(result => {
            this.batdongsan = result;
            if (this.batdongsan.maBatDongSan != "") {

                // this.selectedLBDS= Number(this.batdongsan.maLoaiBDS);
                for (let item of this.listTaiSans) {
                    if (item.maTaiSan == this.batdongsan.maTaiSan) {
                        this.selectedTaiSan = item.id;
                        this.onChangeTaiSan();
                        break;
                    }

                }





            }
            this.modal.show();

        })
    }

    selectTaiSan() {
        console.log("mo modal");
        this.selectTaiSanModel.show();

    }


    save(): void {
        if (Constain.showConsoleLog)
            console.log("tu dong luu");
        this.batdongsan.maTaiSan = this.taisan.maTaiSan;
        let input = this.batdongsan;
        this.saving = true;
        this._batdongsanService.createOrEditBatDongSan(input, this.selectedTaiSan).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })


    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
