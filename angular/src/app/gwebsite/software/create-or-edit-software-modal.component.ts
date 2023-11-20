import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { SoftwareInput, SoftwareServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditSoftwareModal',
    templateUrl: './create-or-edit-software-modal.component.html'
})
export class CreateOrEditSoftwareModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('softwareCombobox') softwareCombobox: ElementRef;
    @ViewChild('iconCombobix') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    saving = false;

    software: SoftwareInput = new SoftwareInput();

    constructor(
        injector: Injector,
        private _softwareService: SoftwareServiceProxy
    ) {
        super(injector);
    }

    show(softwareID?: number | null | undefined): void {
        this.saving = false;


        this._softwareService.getSoftwareForEdit(softwareID).subscribe(result => {
            this.software = result;
            this.modal.show();

        } );
    }

    save(): void {
        let input = this.software;
        this.saving = true;
        this._softwareService.createOrEditSoftware(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        } );

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
