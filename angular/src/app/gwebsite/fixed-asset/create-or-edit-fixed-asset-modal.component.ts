import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { FixedAssetServiceProxy, FixedAssetInput } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditFixedAssetModal',
    templateUrl: './create-or-edit-fixed-asset-modal.component.html',
})

export class CreateOrEditFixedAssetModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('fixedAssetCombobox') fixedAssetCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    messageUpload: string;
    imageURL: any;
    saving = false;
    selected: string;
    fixedAsset: FixedAssetInput = new FixedAssetInput();
    typeAssets = ["fixed assets", "labor assets"];
    assetStatus = ["true", "false"];

    constructor(
        injector: Injector,
        private _fixedAssetService: FixedAssetServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.selected = "fixed assets";
    }

    show(fixedAssetId?: number | null | undefined): void {
        this.saving = false;
        this._fixedAssetService.getFixedAssetForEdit(fixedAssetId).subscribe(result => {
            this.fixedAsset = result;
            this.imageURL = this.fixedAsset.linkofImage;
            this.modal.show();
        });
    }

    chooseImage(files: any) {
        var fileType = files[0].type;
        var fileReader = new FileReader();

        if (files.length === 0)
            return;

        if (fileType.match(/image\/*/) == null) {
            this.messageUpload = "This images is not supported!";
            return;
        }
        fileReader.readAsDataURL(files[0]);
        fileReader.onload = (_event) => {
            this.imageURL = fileReader.result;
        }
    }

    save(): void {
        let input = this.fixedAsset;
        this.fixedAsset.typeofAsset = this.selected;
        this.fixedAsset.linkofImage = this.imageURL;
        this.saving = true;
        this._fixedAssetService.createOrEditFixedAsset(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}