import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BidServiceProxy, BidInput, BidDto, ComboboxItemDto, ProjectDto, ProjectServiceProxy, SupplierServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { ActivatedRoute, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';

@Component({
    selector: 'viewHoSoThauModal',
    templateUrl: './view-hosothau-modal.component.html',
    styles: ['../node_modules/bootstrap/dist/css/bootstrap.css',
        '../node_modules/font-awesome/css/font-awesome.css',
        'styles.scss']
})

export class ViewHoSoThauModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('hosothauCombobox') hosothauCombobox: ElementRef;
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

    hosothau: BidInput = new BidInput();

    duAn: ProjectDto = new ProjectDto();
    duAns: ComboboxItemDto[] = [];

    duanName: string;
    nhacungcapName: string;
    selectedItem: any;
    donViThau: any;
    listDonViThau = [];
    donViTrungThau: any;

    constructor(
        injector: Injector,
        private _hosothauService: BidServiceProxy,
        private _duanService: ProjectServiceProxy,
        private _nhacungcapService: SupplierServiceProxy,
        private router: ActivatedRoute,
        private route: Router

    ) {
        super(injector);
        if (this.router.snapshot.queryParamMap.get('id')) {
            this._hosothauService.getBidForEdit(parseInt(this.router.snapshot.queryParamMap.get('id'))).subscribe(result => {
                this.hosothau = result;
            })
        }

    }

    show(hosothauId?: number | null | undefined): void {
        this.saving = false;

        this._hosothauService.getBidForEdit(hosothauId).subscribe(result => {
            this.hosothau = result;
            //this.modal.show();

        })

        if (hosothauId == null) {
            this._hosothauService.getProjectComboboxForEditAsync(hosothauId).subscribe(result => {
                //this.hosothau = result;      
                this.duAn = result.project;
                this.duAns = result.projects;
                this.modal.show();
                setTimeout(() => {
                    $(this.hosothauCombobox.nativeElement).selectpicker('refresh');
                }, 0);
            })
        }

    }

    save(): void {
        let input = this.hosothau;
        this.saving = true;
        this._hosothauService.createOrEditBid(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            //this.close();
            setTimeout(() => {
                this.route.navigate(["/app/gwebsite/hosothau"]);
            }, 2000);
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    /**
     * Hàm get danh sách Customer
     * @param event
     */
    getDuAns(event?: LazyLoadEvent) {
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

    reloadList(duanName, event?: LazyLoadEvent) {
        this._duanService.getProjectsByFilter(duanName, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.duanName, null);

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

    onSelect(selectedItem: any) {
        this.hosothau.projectName = selectedItem;
    }

    onSelectNhaCungCap(donViThau: any) {
        //this.donViThau = new DonViThau(donViThau.maDuAn, donViThau.tenDuAn, donViThau.ngayTaoDuAn);

        if (this.listDonViThau.find(x => x.id == donViThau.maNhaCungCap) === undefined) {
            this.listDonViThau.push({
                id: donViThau.supplierCode, name: donViThau.supplierName,
                address: donViThau.address, phone: donViThau.phoneNumber, email: donViThau.email
            });
        }

        //console.log(this.listDonViThau);
    }

    removeFromListDonViThau(donViThauID: any) {
        this.listDonViThau.splice(donViThauID, 1); // Removes one element, starting from index

        //console.log(this.listDonViThau);
    }

    setSelectedDonViThau(donViTrungThau: any) {
        this.hosothau.bidUnit = donViTrungThau;
    }
}
