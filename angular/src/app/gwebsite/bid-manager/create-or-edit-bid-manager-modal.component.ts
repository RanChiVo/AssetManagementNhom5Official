import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ConstructionServiceProxy, ConstructionInput, PlanServiceProxy, BidManagerInput, BidManagerServiceProxy, ContractorServiceProxy, ContractorInput } from '@shared/service-proxies/service-proxies';
import { SelectionConstructionModalComponent } from '../construction/select-construction-modal.component';
import { ActivatedRoute, Params } from '@angular/router';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { CreateOrEditContractorModalComponent } from './create-or-edit-contractor-modal.component';


@Component({
    selector: 'createOrEditBidManagerModal',
    templateUrl: './create-or-edit-bid-manager-modal.component.html'
})
export class CreateOrEditBidManagerModalComponent extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('bidManagerCombobox') bidManagerCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('selectConstructionModal') selectConstructionModal: SelectionConstructionModalComponent;
    @ViewChild('createOrEditContractorModal') createOrEditContractorModal: CreateOrEditContractorModalComponent;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    bidManager: BidManagerInput = new BidManagerInput();
    construction: ConstructionInput = new ConstructionInput();
    dsNguoiDauThau: Array<ContractorInput> = [];

    constructor(
        injector: Injector,
        private _bidManagerService: BidManagerServiceProxy,
        private _constructionService: ConstructionServiceProxy,
        private _contractorService: ContractorServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    show(ID?: number | null | undefined): void {
        this.saving = false;
        this.dsNguoiDauThau = [];

        this._bidManagerService.getBidManagerForEdit(ID).subscribe(result => {
            this.bidManager = result;
            this._activatedRoute.params.subscribe((params: Params) => {
                this.reloadList( null);
            })
            this.modal.show();
            setTimeout(() => {
                $(this.bidManagerCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        })
      
    }

    getContractors(event?: LazyLoadEvent) {
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


    reloadList( event?: LazyLoadEvent) {
 
    }

    save(): void {
        let input = this.bidManager;
        this.saving = true;
        this._bidManagerService.createOrEditBidManager(input).subscribe(result => {
            for (let item of this.dsNguoiDauThau) {
                let inputNDT = item;
                inputNDT.maHoSoThau = this.bidManager.maHoSoThau;
                this._contractorService.createOrEditContractor(inputNDT).subscribe(result => {
                    this.notify.info(this.l('SavedCongTrinh'));
                })
            }
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();

        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);

    }

    contractorShow(): void {
        this.createOrEditContractorModal.pBool = true;
        this.createOrEditContractorModal.show();
    }

    constructionShow(): void {
        this.selectConstructionModal.show();
    }

    loadContractor() {
        this.dsNguoiDauThau.push(this.createOrEditContractorModal.contractor);
    }

    deleteContractor(ID) {
        this.dsNguoiDauThau.pop();
    }

    reloadConstruction(): void {
        this._constructionService.getConstructionForEdit(this.selectConstructionModal.pConstructionID).subscribe(result => {
            this.construction = result;
            this.bidManager.maCongTrinh = result.maCongTrinh;
            this.bidManager.phanTram = result.tenCongTrinh;

        })
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
