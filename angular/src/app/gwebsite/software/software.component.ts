import { ViewSoftwareModalComponent} from './view-software-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { SoftwareServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditSoftwareModalComponent } from './create-or-edit-software-modal.component';
import { ComponentLoader } from 'ngx-bootstrap';

@Component({
    templateUrl: './software.component.html',
    animations: [appModuleAnimation()]
})
export class SoftwareComponent extends AppComponentBase implements AfterViewInit, OnInit {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditSoftwareModalComponent;
    @ViewChild('viewSoftwareModal') viewSoftwareModal: ViewSoftwareModalComponent;

    computerName: string;

    constructor(
        injector: Injector,
        private _softwareService: SoftwareServiceProxy,
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

    getcurrentSoftware(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.reloadList(null, event);
    }

    getSoftwares(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.reloadList(null, event);
    }

    reloadList(computerName, event?: LazyLoadEvent) {
        this._softwareService.getSoftwaresByFilter(computerName, this.primengTableHelper.getSorting(this.dataTable),
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

    createSoftware() {
        this.createOrEditModal.show();
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}

