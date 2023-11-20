import { ViewComputerModalComponent} from './view-computer-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ComputerServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditComputerModalComponent } from './create-or-edit-computer-modal.component';


@Component({
    templateUrl: './computer.component.html',
    animations: [appModuleAnimation()]
} )
export class ComputerComponent extends AppComponentBase implements AfterViewInit, OnInit {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditComputerModalComponent;
    @ViewChild('viewComputerModal') viewComputerModal: ViewComputerModalComponent;

    computerName: string;

    constructor(
        injector: Injector,
        private _computerService: ComputerServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    ngOnInit(): void {
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        } );
    }

    getcurrentComputer(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.reloadList(null, event);
    }

    getComputers(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.reloadList(null, event);
    }

    reloadList(computerName, event?: LazyLoadEvent) {
        this._computerService.getComputersByFilter(computerName, this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe( result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        } );
    }

    init(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.computerName = params['name'] || '';
            this.reloadList(this.computerName , null);
        } );
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.computerName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    createComputer() {
        this.createOrEditModal.show();
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}

