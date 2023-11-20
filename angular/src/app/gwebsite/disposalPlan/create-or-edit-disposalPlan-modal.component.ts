import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { DisposalPlanServiceProxy, DisposalPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';

@Component({
    selector: 'createOrEditDisposalPlanModal',
    templateUrl: './create-or-edit-disposalPlan-modal.component.html'
})
export class CreateOrEditDisposalPlanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('disposalPlanCombobox') disposalPlanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    disposalPlan: DisposalPlanInput = new DisposalPlanInput();

    constructor(
        injector: Injector,
        private _disposalPlanService: DisposalPlanServiceProxy
    ) {
        super(injector);
    }

    show(disposalPlanId?: number | null | undefined): void {
        this.saving = false;
        this._disposalPlanService.getDisposalPlanForEdit(disposalPlanId).subscribe(result => {
            this.disposalPlan = result;
            if (this.disposalPlan.trangThai == null) {
                this.disposalPlan.trangThai = 'Chưa duyệt';
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.disposalPlan;
        this.saving = true;
        var now = new Date();
        this.disposalPlan.ngayHieuLuc = moment(now);
        this._disposalPlanService.createOrEditDisposalPlan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}