import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ContractServiceProxy, ContractInput, ContractDto, ComboboxItemDto, BidDto, SupplierDto, BidServiceProxy, GoodsServiceProxy, ContractPaymentServiceProxy, ContractPaymentInput, GoodsInput } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Params } from '@angular/router';

@Component({
    selector: 'createOrEditHopDongThauModal',
    templateUrl: './create-or-edit-hopdongthau-modal.component.html'
})
export class CreateOrEditHopDongThauModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hopdongthauCombobox') hopdongthauCombobox: ElementRef;
    @ViewChild('hosothauCombobox') hosothauCombobox: ElementRef;
    @ViewChild('nhacungcapCombobox') nhacungcapCombobox: ElementRef;
    @ViewChild('trangthaiduyetCombobox') trangthaiduyetCombobox: ElementRef;
    @ViewChild('hinhthucthauCombobox') hinhthucthauCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    hopdongthau: ContractInput = new ContractInput();

    contractpayment: ContractPaymentInput = new ContractPaymentInput();

    hoSoThau: BidDto = new BidDto();
    hoSoThaus: ComboboxItemDto[] = [];

    nhaCungCap: SupplierDto = new SupplierDto();
    nhaCungCaps: ComboboxItemDto[] = [];

    hopDongThau: ContractDto = new ContractDto();
    hopDongThaus: ComboboxItemDto[] = [];

    hosothauName: string;
    hanghoaName: string;
    contractCode: string;
    contractId: number;
    listHangHoa = [];

    totalPrice: number;
    totalPricePay: number;

    hanghoa: GoodsInput = new GoodsInput();

    constructor(
        injector: Injector,
        private _hopdongthauService: ContractServiceProxy,
        private _hosothauService: BidServiceProxy,
        private _hanghoaService: GoodsServiceProxy,
        private _contractpaymentService: ContractPaymentServiceProxy,
        private router: ActivatedRoute,
        private route: Router,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
        if (this.router.snapshot.queryParamMap.get('id')) {
            this._hopdongthauService.getContractForEdit(parseInt(this.router.snapshot.queryParamMap.get('id'))).subscribe(result => {
                this.hopdongthau = result;
            })
        }
        this._hopdongthauService.getContractComboboxForEditAsync(this.contractId).subscribe(result => {
            this.hopDongThau = result.contract;
            this.hopDongThaus = result.contracts;
            setTimeout(() => {
                $(this.hopdongthauCombobox.nativeElement).selectpicker('refresh');
            });
        })

        //this.ngAfterViewInit();
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

    show(hopdongthauId?: number | null | undefined): void {
        this.saving = false;

        this._hopdongthauService.getContractForEdit(hopdongthauId).subscribe(result => {
            this.hopdongthau = result;
            this.modal.show();

        })

        if (hopdongthauId == null) {
            this._hopdongthauService.getBidComboboxForEditAsync(hopdongthauId).subscribe(result => {
                //this.hopdongthau = result;      
                this.hoSoThau = result.bid;
                this.hoSoThaus = result.bids;
                this.modal.show();
                setTimeout(() => {
                    $(this.hosothauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
            this._hopdongthauService.getSupplierComboboxForEditAsync(hopdongthauId).subscribe(result => {
                //this.hopdongthau = result;      
                this.nhaCungCap = result.supplier;
                this.nhaCungCaps = result.suppliers;
                this.modal.show();
                setTimeout(() => {
                    $(this.nhacungcapCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }
        
    }

    save(): void {
        let input = this.hopdongthau;
        this.saving = true;
        this._hopdongthauService.createOrEditContract(input).subscribe(result => {
            //this.notify.info(this.l('SavedSuccessfully'));
            setTimeout(() => {
                this.route.navigate(["/app/gwebsite/hopdongthau"]);
            }, 2000); 
        })

        let input_hanghoa = this.hanghoa;
        this._hanghoaService.createOrEditGoods(input_hanghoa).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    savePayment(): void {
        let input_payment = this.contractpayment;
        this._contractpaymentService.createOrEditContractPayment(input_payment)
            .subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();

            })

        this.reloadListContractPayment(this.hopdongthau.id, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    setBindMaDonViTrungThau(bindingMaDonViTrungThau: any) {
        this.hopdongthau.unitAcceptedCode = bindingMaDonViTrungThau;
    }

    /**
     * Hàm get danh sách HoSoThau
     * @param event
     */
    getHoSoThaus(event?: LazyLoadEvent) {
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

    reloadList(hosothauName, event?: LazyLoadEvent) {
        this._hosothauService.getBidsByFilter(hosothauName, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.hosothauName, null);

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

    onSelect(maGoiThau: any, donViThau: any) {
        this.hopdongthau.bidCode = maGoiThau;
        this.hopdongthau.unitAcceptedCode = donViThau;
    }

    /**
     * Hàm get danh sách HangHoa
     * @param event
     */
    getHangHoas(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadListHangHoa(null, event);

    }

    reloadListHangHoa(hanghoaName, event?: LazyLoadEvent) {
        this._hanghoaService.getGoodsByFilter(hanghoaName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    applyFiltersHangHoa(): void {
        //truyền params lên url thông qua router
        this.reloadListHangHoa(this.hanghoaName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateStringHangHoa(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
}



    onSelectHangHoa(hangHoa: any) {
        if (this.listHangHoa.find(x => x.id == hangHoa.maHangHoa) === undefined) {
            this.listHangHoa.push({
                id: hangHoa.goodsCode, name: hangHoa.goodsName,
                type: hangHoa.type, price: hangHoa.price, hanghoa_id: hangHoa.id, hanghoa_NCC: hangHoa.countryOfManufacture, disable: false,
            });
        }
    }

    removeFromListHangHoa(hangHoaID: any) {
        this.listHangHoa.splice(hangHoaID, 1); // Removes one element, starting from index

        console.log(hangHoaID);
    }

    setSelectedHangHoa(hangHoa: any, hangHoaID: any, hanghoaType: any, hanghoaPrice: any, hanghoaNCC: any) {
        if (this.hopdongthau.goodsName === null) {
            this.hopdongthau.goodsName = "";
        }


        this.hopdongthau.goodsName += hangHoa + ', ';

        this.hanghoa.contractCode = this.router.snapshot.queryParamMap.get('contractId');

        this.hanghoa.id = +hangHoaID;
        this.hanghoa.goodsName = hangHoa;
        this.hanghoa.type = hanghoaType;
        this.hanghoa.price = hanghoaPrice;
        this.hanghoa.countryOfManufacture = hanghoaNCC;

        if (this.totalPrice === undefined) {
            this.totalPrice = 0;
        }
        this.totalPrice += +hanghoaPrice;
        this.hopdongthau.totalPrice = this.totalPrice.toString();
        console.log(this.totalPrice);
    }

    setSelectedPayment(payment: any) {

        if (this.totalPricePay === undefined) {
            this.totalPricePay = 0;
        }
        this.totalPricePay += +payment.money;
        this.hopdongthau.totalPricePay = this.totalPricePay.toString();
        console.log(this.totalPricePay);
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
        this.reloadListContractPayment(this.hopdongthau.id, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.contractCode = params['contractCode'] || '';
            this.reloadListContractPayment(this.hopdongthau.id, null);
        });
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateStringContractPayment(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

}
