import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ConstructionPlanServiceProxy, ConstructionPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';

@Component({
    selector: 'createOrEditConstructionPlanModal',
    templateUrl: './create-or-edit-constructionPlan-modal.component.html'
})
export class CreateOrEditConstructionPlanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('constructionPlanCombobox') constructionPlanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    constructionPlan: ConstructionPlanInput = new ConstructionPlanInput();

    constructor(
        injector: Injector,
        private _constructionPlanService: ConstructionPlanServiceProxy
    ) {
        super(injector);
    }

    show(constructionPlanId?: number | null | undefined): void {
        this.saving = false;
        this._constructionPlanService.getConstructionPlanForEdit(constructionPlanId).subscribe(result => {
            this.constructionPlan = result;
            if (this.constructionPlan.trangThai == null) {
                this.constructionPlan.trangThai = 'Chưa duyệt';
            }
            if (this.constructionPlan.tinhTrang == null) {
                this.constructionPlan.tinhTrang = 'not check';
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.constructionPlan;
        this.saving = true;
        var now = new Date();
        this.constructionPlan.ngayHieuLuc = moment(now);
        this._constructionPlanService.createOrEditConstructionPlan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
