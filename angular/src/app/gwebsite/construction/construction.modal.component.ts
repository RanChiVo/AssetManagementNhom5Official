import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ConstructionServiceProxy, ConstructionInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEdit1ConstructionModal',
    templateUrl: './construction.modal.component.html'
})
export class ConstructionModalComponent extends AppComponentBase {


    @ViewChild('createOrEdit1ConstructionModal') modal: ModalDirective;
    @ViewChild('constructionCombobox') constructionCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    public bool = false;
    construction: ConstructionInput = new ConstructionInput();

    constructor(
        injector: Injector,
        private _constructionService: ConstructionServiceProxy
    ) {
        super(injector);
    }

    show(ID?: number | null | undefined): void {
        this.saving = false;


        this._constructionService.getConstructionForEdit(ID).subscribe(result => {
            this.construction = result;
            this.modal.show();

        })
    }

    save(): void {
        if (this.bool) {
            this.close();
            return;
        }
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

    deleteConstruction(ID) {
        this._constructionService.deleteConstruction(ID).subscribe(result => {
            this.close();
        })
    }
}
