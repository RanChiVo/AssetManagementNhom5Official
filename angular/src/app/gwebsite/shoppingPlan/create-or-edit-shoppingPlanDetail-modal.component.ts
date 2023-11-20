import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild,Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ShoppingPlanDetailServiceProxy, ShoppingPlanDetailInput, ShoppingPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';
import { filter } from 'rxjs/operators';
import { SelectableRow } from 'primeng/table';

@Component({
    selector: 'createOrEditShoppingPlanDetailModal',
    templateUrl: './create-or-edit-shoppingPlanDetail-modal.component.html'
})
export class CreateOrEditShoppingPlanDetailModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('shoppingPlanDetailCombobox') shoppingPlanDetailCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Input() maKeHoach: string;

    saving = false;

    shoppingPlanDetail: ShoppingPlanDetailInput = new ShoppingPlanDetailInput();

    constructor(
        injector: Injector,
        private _shoppingPlanDetailService: ShoppingPlanDetailServiceProxy
    ) {
        super(injector);
    }

    show(shoppingPlanDetailId?: number | null | undefined): void {
        this.saving = false;
        this._shoppingPlanDetailService.getShoppingPlanDetailForEdit(shoppingPlanDetailId).subscribe(result => {
            this.shoppingPlanDetail = result;
            if (this.shoppingPlanDetail.maKeHoach == null) {
                this.shoppingPlanDetail.maKeHoach = this.maKeHoach;
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.shoppingPlanDetail;
        this.saving = true;
        this._shoppingPlanDetailService.createOrEditShoppingPlanDetail(input).subscribe(result => {
            this.notify.info(this.l('Them thanh cong!'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
