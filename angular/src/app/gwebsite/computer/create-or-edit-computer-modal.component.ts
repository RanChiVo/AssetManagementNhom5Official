import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ComputerInput, ComputerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditComputerModal',
    templateUrl: './create-or-edit-computer-modal.component.html'
} )
export class CreateOrEditComputerModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('computerCombobox') computerCombobox: ElementRef;
    @ViewChild('iconCombobix') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    saving = false;

    computer: ComputerInput = new ComputerInput();

    constructor(
        injector: Injector,
        private _computerService: ComputerServiceProxy
    ) {
        super(injector);
    }

    show(computerID?: number | null | undefined): void {
        this.saving = false;


        this._computerService.getComputerForEdit(computerID).subscribe(result => {
            this.computer = result;
            this.modal.show();

        } );
    }

    save(): void {
        let input = this.computer;
        this.saving = true;
        this._computerService.createOrEditComputer(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        } );

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
