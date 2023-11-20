import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { InsurranceServiceProxy, InsurranceInput, InsurranceTypeServiceProxy, InsurranceTypeDto } from '@shared/service-proxies/service-proxies';
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";

@Component({
    selector: 'createOrEditInsurranceModal',
    templateUrl: './create-or-edit-insurrance-modal.component.html'
})
export class CreateOrEditInsurranceModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('insurranceCombobox') insurranceCombobox: ElementRef;
    @ViewChild('insurrancetypeCombobox') insurrancetypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    insurrance: InsurranceInput = new InsurranceInput();
    listInsurrances: Array<InsurranceInput> = [];
    
    insurrancetype: InsurranceTypeDto = new InsurranceTypeDto();
    insurrancetypes: Array<InsurranceTypeDto> = [];
    selectedType: number;
    temp: string;

    constructor(
        injector: Injector,
        private _insurranceService: InsurranceServiceProxy,
        private _insurrancetypeService: InsurranceTypeServiceProxy,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
        this.getTypes();
    }

    getTypes(): void {
        this._insurrancetypeService
            .getInsurranceTypesByFilter(null, "", 20, 0)
            .subscribe(result => {
                this.insurrancetypes = result.items;
            });
    }

    getNewListInsurrance() {
        this._apiService
            .get("api/Insurrance/GetInsurrancesByFilter")
            .subscribe(result => {
                this.listInsurrances = result.items;
            });
    }

    onChangeType(): void {
        this._apiService
            .getForEdit(
                "api/InsurranceType/GetInsurranceTypeForView",
                this.selectedType
            )
            .subscribe(result => {
                this.temp = result.insurranceTypeName;
                this.insurrance.insurranceTypeId = result.insurranceTypeName;
            });
    }

    show(insurranceId?: number | null | undefined): void {
        this.saving = false;

        this._insurranceService.getInsurranceForEdit(insurranceId).subscribe(result => {
            this.insurrance = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.insurrance;
        this.saving = true;
        this._insurranceService.createOrEditInsurrance(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
