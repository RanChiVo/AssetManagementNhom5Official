import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild,Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { DisposalPlanDetailServiceProxy, DisposalPlanDetailInput, DisposalPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';
import { filter } from 'rxjs/operators';
import { SelectableRow } from 'primeng/table';

@Component({
    selector: 'createOrEditDisposalPlanDetailModal',
    templateUrl: './create-or-edit-disposalPlanDetail-modal.component.html'
})
export class CreateOrEditDisposalPlanDetailModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('disposalPlanDetailCombobox') disposalPlanDetailCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Input() maKeHoach: string;

    saving = false;

    disposalPlanDetail: DisposalPlanDetailInput = new DisposalPlanDetailInput();

    constructor(
        injector: Injector,
        private _disposalPlanDetailService: DisposalPlanDetailServiceProxy
    ) {
        super(injector);
    }

    show(disposalPlanDetailId?: number | null | undefined): void {
        this.saving = false;
        this._disposalPlanDetailService.getDisposalPlanDetailForEdit(disposalPlanDetailId).subscribe(result => {
            this.disposalPlanDetail = result;
            if (this.disposalPlanDetail.maKeHoach == null) {
                this.disposalPlanDetail.maKeHoach = this.maKeHoach;
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.disposalPlanDetail;
        this.saving = true;
        this._disposalPlanDetailService.createOrEditDisposalPlanDetail(input).subscribe(result => {
            this.notify.info(this.l('Them thanh cong!'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}