import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateOrEditTypeModalComponent } from './create-or-edit-category-type-general-modal.component';
import { ViewCategoryTypeModalComponent } from './view-category-type-general-modal.component';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { CategoryTypeServiceProxy } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
    templateUrl: './category-type-general.component.html',
    animations: [appModuleAnimation()],
})
export class CategoryTypeComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('textsTable') textsTable: ElementRef;
    @ViewChild('createOrEditTypeModal') createOrEditTypeModal: CreateOrEditTypeModalComponent;
    @ViewChild('viewCategoryTypeModal') viewCategoryTypeModal: ViewCategoryTypeModalComponent;
    @ViewChild('typeTable') typeTable: Table;
    @ViewChild('paginatorType') paginatorType: Paginator;

    primengTableHelperTypes = new PrimengTableHelper();

    /**
     * tạo các biến dể filters
     */

    public filters: {
        Name: string,
        Prefix: string,
        Status: string,
        Description: string,
        isCreatedCheckedAll: boolean,
        startCreatedDate: moment.Moment,
        endCreatedDate: moment.Moment,
        createdBy: string,
        isUpdatedCheckedAll: boolean,
        startUpdatedDate: moment.Moment,
        endUpdatedDate: moment.Moment,
        updatedBy: string
    } = <any>{};

    constructor(
        injector: Injector,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _categoryTypeService: CategoryTypeServiceProxy,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.filters.Name = '',
        this.filters.Prefix = '',
        this.filters.Status = null,
        this.filters.Description = '',
        this.filters.isCreatedCheckedAll = true;
        this.filters.startCreatedDate = moment().startOf('day'),
        this.filters.endCreatedDate = moment().startOf('day'),
        this.filters.createdBy = '';
        this.filters.isUpdatedCheckedAll = true;
        this.filters.startUpdatedDate = moment().startOf('day'),
        this.filters.endUpdatedDate = moment().startOf('day'),
        this.filters.updatedBy = '';
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    getTypes(event?: LazyLoadEvent) {
        if (this.primengTableHelperTypes.shouldResetPaging(event)) {
            this.paginatorType.changePage(0);

            return;
        }

        //show loading trong gridview
        this.primengTableHelperTypes.showLoadingIndicator();

        /**
         * Sử dụng _apiService để call các api của backend
         */

        // filter
        this._categoryTypeService.getCategoryTypesByFilter(
            this.filters.Name,
            this.filters.Prefix,
            this.filters.Status,
            this.filters.Description,
            this.filters.isCreatedCheckedAll,
            this.filters.startCreatedDate,
            this.filters.endCreatedDate,
            this.filters.createdBy,
            this.filters.isUpdatedCheckedAll,
            this.filters.startUpdatedDate,
            this.filters.endUpdatedDate,
            this.filters.updatedBy,
            this.primengTableHelperTypes.getSorting(this.typeTable),
            this.primengTableHelperTypes.getMaxResultCount(this.paginatorType, event),
            this.primengTableHelperTypes.getSkipCount(this.paginatorType, event),
        ).subscribe(result => {
            this.primengTableHelperTypes.totalRecordsCount = result.totalCount;
            this.primengTableHelperTypes.records = result.items;
            this.primengTableHelperTypes.hideLoadingIndicator();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.filters.Name = params['Name'] || '';
            this.filters.Prefix = params['Prefix'] || '';
            this.filters.Status = params['Status'] || null;
            this.filters.Description = params['Description'] || '';
            this.filters.createdBy = params['createdBy'] || '';
            this.filters.updatedBy = params['updatedBy'] || '';

            //reload lại gridview
            this.reloadPage();
        });
    }

    reloadPage(): void {
        this.paginatorType.changePage(this.paginatorType.getPage());
    }

    applyTypeFilters(event?: LazyLoadEvent): void {
        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category-type', {
            Name: this.filters.Name,
            Prefix: this.filters.Prefix,
            Status: this.filters.Status,
            Description: this.filters.Description,
            CreatedBy: this.filters.createdBy,
            UpdatedBy: this.filters.updatedBy
        }]);

        this.getTypes(event);
    }

    typeRefresh(event?: LazyLoadEvent): void {
        this.filters.Name = '',
        this.filters.Prefix = '',
        this.filters.Status = null,
        this.filters.Description = '',
        this.filters.createdBy = '',
        this.filters.updatedBy = '',

        //truyền params lên url thông qua router
        this._router.navigate(['app/gwebsite/category-type', {
            Name: this.filters.Name,
            Prefix: this.filters.Prefix,
            Status: this.filters.Status,
            Description: this.filters.Description,
            createdBy: this.filters.createdBy,
            updatedBy: this.filters.updatedBy,
        }]);

        // if (this.paginatorType.getPage() !== 0) {
        //     this.paginatorType.changePage(0);
        //     return;
        // }
        this.getTypes(event);
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text: string): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    //Refresh grid khi thực hiện create or edit thành công
    refreshValueFromTypeModal(): void {
        if (this.createOrEditTypeModal.categoryType.id) {
            // for (let i = 0; i < this.primengTableHelperTypes.records.length; i++) {
            //     if (this.primengTableHelperTypes.records[i].id === this.createOrEditTypeModal.categoryType.id) {
            //         this.primengTableHelperTypes.records[i] = this.createOrEditTypeModal.categoryType;
            //         return;
            //     }
            // }
            this.getTypes();
        } else {
            this.reloadPage();
        }
    }

    createType(): void {
        this.createOrEditTypeModal.show();
    }

    viewType(id: number): void {
        this.viewCategoryTypeModal.show(id);
    }

    editType(id: number): void {
        this.createOrEditTypeModal.show(id);
    }

    deleteType(id: number) {
        this._categoryTypeService.deleteCategoryType(id).subscribe(() => {
            this.typeRefresh();
        });
    }

    exportToExcel(): void {
        const self = this;
        self._categoryTypeService.getCategoryTypesToExcel(
            self.filters.Name,
            self.filters.Prefix,
            self.filters.Status === null ? null : self.filters.Status,
            self.filters.Description,
            self.filters.isCreatedCheckedAll,
            self.filters.startCreatedDate,
            self.filters.endCreatedDate,
            self.filters.createdBy,
            self.filters.isUpdatedCheckedAll,
            self.filters.startUpdatedDate,
            self.filters.endUpdatedDate,
            self.filters.updatedBy,
            undefined,
            1,
            0)
            .subscribe(result => {
                self._fileDownloadService.downloadTempFile(result);
            });
    }

    clearFilters(): void {
        this.filters.Name = '',
        this.filters.Status = null,
        this.filters.Prefix = '',
        this.filters.Description = '',
        this.filters.isCreatedCheckedAll = true;
        this.filters.isUpdatedCheckedAll = true;
        this.filters.createdBy = '';
        this.filters.updatedBy = '';

        this.refreshValueFromTypeModal();
    }

    onClickIsCreatedDateCheckedAll(): void {
        this.filters.isCreatedCheckedAll = !this.filters.isCreatedCheckedAll;
    }

    onClickIsUpdatedDateCheckedAll(): void {
        this.filters.isUpdatedCheckedAll = !this.filters.isUpdatedCheckedAll;
    }
}
