import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ConstructionServiceProxy, ConstructionInput, PlanServiceProxy } from '@shared/service-proxies/service-proxies';
import { PlanModalComponent } from '../plan/plan.modal.component';


@Component({
    selector: 'createOrEditConstructionModal',
    templateUrl: './create-or-edit-construction.modal.component.html'
})
export class CreateOrEditConstructionModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('constructionCombobox') constructionCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('selectPlanModal') selectPlanModal: PlanModalComponent;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    construction: ConstructionInput = new ConstructionInput();

    constructor(
        injector: Injector,
        private _constructionService: ConstructionServiceProxy,
        private _planService: PlanServiceProxy
    ) {
        super(injector);
    }

    show(ID?: number | null | undefined): void {
        this.saving = false;

        this._constructionService.getConstructionForEdit(ID).subscribe(result => {
            this.construction = result;
            this.modal.show();
            setTimeout(() => {
                $(this.constructionCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        })
    }

    save(): void {
        let input = this.construction;
        this.saving = true;
        this._constructionService.createOrEditConstruction(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
        
    }
    planShow(): void {
        this.selectPlanModal.show();
    }

    reloadPlan(): void {
        this._planService.getPlanForEdit(this.selectPlanModal.pPlanID).subscribe(result => {
            this.construction.maKeHoach = result.maKeHoach;
            this.construction.trangThaiDuyet = result.trangThaiDuyet;
            this.construction.namThucHien = result.namThucHien;
           // this.construction.chiPhiDuocDuyet = result.tongChiPhiĐuocDuyet;
        })
    }
}
