import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { PlanServiceProxy, PlanInput, ConstructionServiceProxy, ConstructionInput } from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator, LazyLoadEvent } from 'primeng/primeng';
import { ConstructionModalComponent } from '../construction/construction.modal.component';

@Component({
    selector: 'createOrEditPlanModal',
    templateUrl: './create-or-edit-plan-modal.component.html'
})
export class CreateOrEditPlanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditPlanModal') modal: ModalDirective;
    @ViewChild('PlanCombobox') PlanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEdit1ConstructionModal') createOrEdit1ConstructionModal: ConstructionModalComponent;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    pID: number = 0;
    public pCount: number;
    plan: PlanInput = new PlanInput();

    dsCongtrinh: Array<ConstructionInput> = [];
    constructor(
        injector: Injector,
        private _planService: PlanServiceProxy,
        private _constructionService: ConstructionServiceProxy,
    ) {
        super(injector);
    }

    show(PlanId?: number | null | undefined): void {
        //reset list when modal show
        this.dsCongtrinh = [];
        this.saving = false;


        this._planService.getPlanForEdit(PlanId).subscribe(result => {
            this.plan = result;
            this.modal.show();

        })
    }

    getConstructions(event?: LazyLoadEvent) {
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

    createConstruction() {
        this.createOrEdit1ConstructionModal.bool = true;
        this.createOrEdit1ConstructionModal.show();
    }

    save(): void {
        this.plan.trangThaiDuyet = "Đã duyệt";
        let tongChiPhi = 0;
        this.pID++;
        if (this.pID < 10)
            this.plan.maKeHoach = "KH0" + (this.pID + this.pCount);
        else
            this.plan.maKeHoach = "KH" + (this.pID + this.pCount);
        for (let item of this.dsCongtrinh) {
            tongChiPhi += item.chiPhiDuocDuyet;
        }
        this.plan.tongChiPhiĐuocDuyet = tongChiPhi.toString();
        let input = this.plan;
        this.saving = true;
        this._planService.createOrEditPlan(input).subscribe(result => {
            for (let item of this.dsCongtrinh) {
                let inputCT = item;
                inputCT.maKeHoach = this.plan.maKeHoach;
                this._constructionService.createOrEditConstruction(inputCT).subscribe(result => {
                    this.notify.info(this.l('SavedCongTrinh'));
                })
            }
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
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

    loadConstruction() {
        this.dsCongtrinh.push(this.createOrEdit1ConstructionModal.construction);
    }

    deleteConstruction(ID) {      
        this.dsCongtrinh.pop();       
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);

    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
