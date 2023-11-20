import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { GoodsInvoiceServiceProxy, GoodsInvoiceInput, GoodsInvoiceDto, ComboboxItemDto, ContractDto, GoodsContract, SupplierServiceProxy, ContractServiceProxy, ContractPaymentServiceProxy } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Params } from '@angular/router';

@Component({
    selector: 'createOrEditPhieuGoiHangModal',
    templateUrl: './create-or-edit-phieugoihang-modal.component.html',
    styleUrls: ['./create-or-edit-phieugoihang-modal.component.css',]
})
export class CreateOrEditPhieuGoiHangModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hopdongthauCombobox') hopdongthauCombobox: ElementRef;
    @ViewChild('donvithauCombobox') donvithauCombobox: ElementRef;
    @ViewChild('quatrinhthanhtoanCombobox') quatrinhthanhtoanCombobox: ElementRef;
    @ViewChild('tiendogiaohangCombobox') tiendogiaohangCombobox: ElementRef;
    @ViewChild('tinhtranghoadonCombobox') tinhtranghoadonCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    phieugoihang: GoodsInvoiceInput = new GoodsInvoiceInput();

    hopDongThau: ContractDto = new ContractDto();
    hopDongThaus: ComboboxItemDto[] = [];

    hopdongthauCode: string;
    listHopDongHangHoa: GoodsContract[] = [];
    nhacungcapName: string;
    contractName: string;
    tenDonVi: any;
    maDonVi: any;
    diaChi: any;
    donVi: any;
    listNhaCungCap = [];
    hangHoaHopDong: any;

    constructor(
        injector: Injector,
        private _phieugoihangService: GoodsInvoiceServiceProxy,
        private _nhacungcapService: SupplierServiceProxy, 
        private _contractService: ContractServiceProxy,
        private _contractpaymentService: ContractPaymentServiceProxy,
        private router: ActivatedRoute,
        private route: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
        if (this.router.snapshot.queryParamMap.get('id')) {
            this._phieugoihangService.getGoodsInvoiceForEdit(parseInt(this.router.snapshot.queryParamMap.get('id'))).subscribe(result => {
                this.phieugoihang = result;
            })
            //this.ngAfterViewInit();
        }
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    show(phieugoihangId?: number | null | undefined): void {
        this.saving = false;

        this._phieugoihangService.getGoodsInvoiceForEdit(phieugoihangId).subscribe(result => {
            this.phieugoihang = result;
            this.modal.show();

        })

        if (phieugoihangId == null) {
            this._phieugoihangService.getContractComboboxForEditAsync(phieugoihangId).subscribe(result => {
                //this.phieugoihang = result;      
                this.hopDongThau = result.contract;
                this.hopDongThaus = result.contracts;
                this.modal.show();
                setTimeout(() => {
                    $(this.hopdongthauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }
        
    }

    save(): void {
        let input = this.phieugoihang;
        this.saving = true;
        this._phieugoihangService.createOrEditGoodsInvoice(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            //this.close();
            setTimeout(() => {
                this.route.navigate(["/app/gwebsite/phieugoihang"]);
            }, 2000);
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }



    reloadListHopDongHangHoa(hopdongthauCode, event?: LazyLoadEvent) {
        this._phieugoihangService.getGoodsContract(hopdongthauCode).subscribe((hanghoahopdong: GoodsContract[]) => {
            this.listHopDongHangHoa = hanghoahopdong;
        });
    }

    applyFiltersHopDongHangHoa(): void {
        this.hopdongthauCode = this.phieugoihang.contractCode;
        //truyền params lên url thông qua router
        this.reloadListHopDongHangHoa(this.hopdongthauCode, null);
    }

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getNhaCungCaps(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadListNhaCungCap(null, event);

    }

    reloadListNhaCungCap(nhacungcapName, event?: LazyLoadEvent) {
        this._nhacungcapService.getSuppliersByFilter(nhacungcapName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFiltersNhaCungCap(): void {
        //truyền params lên url thông qua router
        this.reloadListNhaCungCap(this.nhacungcapName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    onSelectNhaCungCap(donVi: any) {
        this.phieugoihang.unitCode = donVi.supplierCode;
        this.phieugoihang.unitName = donVi.supplierName;
        this.phieugoihang.unitAddress = donVi.address;

    }

    //onSelectHopDongHangHoa(hopDong: any, hangHoa: any) {
    //    this.phieugoihang.contractName = hopDong;
    //    this.hangHoaHopDong = hangHoa;

    //}

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getContracts(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadListContract(null, event);

    }

    reloadListContract(contractName, event?: LazyLoadEvent) {
        this._contractService.getContractsByFilter(contractName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFiltersContract(): void {
        //truyền params lên url thông qua router
        this.reloadListContract(this.contractName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    onSelectContract(contract: any) {
        this.phieugoihang.contractCode = contract.contractCode;
        this.phieugoihang.totalPriceContract = contract.totalPrice;
        this.phieugoihang.totalPriceContractPayment = contract.totalPricePay;
        this.phieugoihang.contractContent = contract.content;
        this.phieugoihang.contractId = contract.id;
        this.hopdongthauCode = contract.contractCode;
    }

    init(): void {
        this.hopdongthauCode = this.phieugoihang.contractCode;
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.hopdongthauCode = params['contractCode'] || '';
            this.reloadListHopDongHangHoa(this.hopdongthauCode, null);
        });
    }

    /**
     * Hàm get danh sách HangHoa
     * @param event
     */
    getContractPayments(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadListContractPayment(null, event);

    }

    reloadListContractPayment(contractCode, event?: LazyLoadEvent) {
        this._contractpaymentService.getContractPaymentsByFilter(contractCode, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFiltersContractPayment(): void {
        //truyền params lên url thông qua router
        this.reloadListContractPayment(this.phieugoihang.contractId, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
