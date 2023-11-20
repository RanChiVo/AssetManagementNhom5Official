import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild,Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ConstructionPlanDetailServiceProxy, ConstructionPlanDetailInput, ConstructionPlanInput } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Console } from '@angular/core/src/console';
import { filter } from 'rxjs/operators';
import { SelectableRow } from 'primeng/table';

@Component({
    selector: 'createOrEditConstructionPlanDetailModal',
    templateUrl: './create-or-edit-constructionPlanDetail-modal.component.html'
})
export class CreateOrEditConstructionPlanDetailModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('constructionPlanDetailCombobox') constructionPlanDetailCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @Input() maKeHoach: string;

    saving = false;

    constructionPlanDetail: ConstructionPlanDetailInput = new ConstructionPlanDetailInput();

    constructor(
        injector: Injector,
        private _constructionPlanDetailService: ConstructionPlanDetailServiceProxy
    ) {
        super(injector);
    }

    show(constructionPlanDetailId?: number | null | undefined): void {
        this.saving = false;
        this._constructionPlanDetailService.getConstructionPlanDetailForEdit(constructionPlanDetailId).subscribe(result => {
            this.constructionPlanDetail = result;
            if (this.constructionPlanDetail.maKeHoach == null) {
                this.constructionPlanDetail.maKeHoach = this.maKeHoach;
            }
            this.modal.show();
        })
    }

    save(): void {
        let input = this.constructionPlanDetail;
        this.saving = true;
        this._constructionPlanDetailService.createOrEditConstructionPlanDetail(input).subscribe(result => {
            this.notify.info(this.l('Them thanh cong!'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
