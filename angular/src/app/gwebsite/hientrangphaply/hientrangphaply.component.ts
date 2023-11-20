import { ViewHienTrangPhapLyModalComponent } from './view-hientrangphaply-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { HienTrangPhapLyServiceProxy, HienTrangPhapLyInput } from '@shared/service-proxies/service-proxies';
import { NgForm } from '@angular/forms';

@Component({
    templateUrl: './hientrangphaply.component.html',
    animations: [appModuleAnimation()]
})
export class HienTrangPhapLyComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('viewHienTrangPhapLyModal') viewHienTrangPhapLyModal: ViewHienTrangPhapLyModalComponent;

    /**
     * tạo các biến dể filters
     */
    hientrangphaplyName: string;
    Id: string;
    @Input() selectedIndex: number | null; //The index of the active tab.  
    hientrangphaply: HienTrangPhapLyInput = new HienTrangPhapLyInput();
    saving = false;
    activeTabHienTrang=true;
    activeTabCreate=false;
    constructor(
        injector: Injector,
        private _hientrangphaplyService: HienTrangPhapLyServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
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

    /**
     * Hàm get danh sách HienTrangPhapLy
     * @param event
     */
    getHienTrangPhapLys(event?: LazyLoadEvent) {
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

    reloadList(hientrangphaplyName, event?: LazyLoadEvent) {
        this._hientrangphaplyService.getHienTrangPhapLysByFilter(hientrangphaplyName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteHienTrangPhapLy(id): void {
        this._hientrangphaplyService.deleteHienTrangPhapLy(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.hientrangphaplyName = params['name'] || '';
           
            this.reloadList(this.hientrangphaplyName, null);
        });
    }

    initTabHienTrang():void{
        this.activeTabCreate=false;
        
        this.reloadList(null);
        
    }

    getId(): string {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.Id = params['Id'] || '';
        })
     return this.Id;
    };
    

    gotoTabCreate(){
        this.activeTabCreate=true;
    }


    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.hientrangphaplyName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }



    returnTabHienTrang():void{
        this.activeTabHienTrang=true;
        console.log("Go to tab");
    }


/*********************************************
 * 
 *  Tab Create va Tab Edit
 * 
 **********************************************/
   

    initTabCreate():void{
        this.saving=false;
        this.activeTabHienTrang=false;
       
    }
    

    save(): void {
        let input = this.hientrangphaply;
        this.saving = true;
        this._hientrangphaplyService.createOrEditHienTrangPhapLy(input).subscribe(result => {
            this.activeTabHienTrang=true;
            this.notify.info(this.l('SavedSuccessfully'));
        })

    }

    EditHT(htID?: number | null | undefined): void {
        this.initTabCreate();
        this.activeTabCreate=true;
        this._hientrangphaplyService.getHienTrangPhapLyForEdit(htID).subscribe(result => {
            this.hientrangphaply = result;
        })
 
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
