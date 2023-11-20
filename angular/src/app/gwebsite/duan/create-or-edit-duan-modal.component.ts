import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProjectServiceProxy, ProjectInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditDuAnModal',
    templateUrl: './create-or-edit-duan-modal.component.html'
})
export class CreateOrEditDuAnModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('duanCombobox') duanCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    duan: ProjectInput = new ProjectInput();

    constructor(
        injector: Injector,
        private _duanService: ProjectServiceProxy
    ) {
        super(injector);
    }

    show(duanId?: number | null | undefined): void {
        this.saving = false;


        this._duanService.getProjectForEdit(duanId).subscribe(result => {
            this.duan = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.duan;
        this.saving = true;
        this._duanService.createOrEditProject(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
