import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ShoppingPlanServiceProxy, ShoppingPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';

@Component({
    selector: 'createOrEditShoppingPlanModal',
    templateUrl: './create-or-edit-shoppingPlan-modal.component.html'
})
export class CreateOrEditShoppingPlanModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('shoppingPlanCombobox') shoppingPlanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    shoppingPlan: ShoppingPlanInput = new ShoppingPlanInput();

    constructor(
        injector: Injector,
        private _shoppingPlanService: ShoppingPlanServiceProxy
    ) {
        super(injector);
    }

    show(shoppingPlanId?: number | null | undefined): void {
        this.saving = false;
        this._shoppingPlanService.getShoppingPlanForEdit(shoppingPlanId).subscribe(result => {
            this.shoppingPlan = result;
            if (this.shoppingPlan.trangThai == null) {
                this.shoppingPlan.trangThai = 'Chưa duyệt';
            }
            if (this.shoppingPlan.tinhTrang == null) {
                this.shoppingPlan.tinhTrang = 'not check';
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.shoppingPlan;
        this.saving = true;
        var now = new Date();
        this.shoppingPlan.ngayHieuLuc = moment(now);
        this._shoppingPlanService.createOrEditShoppingPlan(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
