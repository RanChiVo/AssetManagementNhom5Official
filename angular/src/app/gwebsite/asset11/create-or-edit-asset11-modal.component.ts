import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild
} from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import {
    Asset11ServiceProxy,
    Asset11Input
} from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditAsset11Modal',
    templateUrl: './create-or-edit-asset11-modal.component.html'
})
export class CreateOrEditAsset11ModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('asset11Combobox') asset11Combobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    asset11: Asset11Input = new Asset11Input();

    constructor(
        injector: Injector,
        private _asset11Service: Asset11ServiceProxy
    ) {
        super(injector);
    }

    show(asset11Id?: number | null | undefined): void {
        this.saving = false;

        this._asset11Service.getAsset11ForEdit(asset11Id).subscribe(result => {
            this.asset11 = result;
            this.modal.show();
        });
    }

    save(): void {
        let input = this.asset11;
        this.saving = true;
        this._asset11Service.createOrEditAsset11(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
