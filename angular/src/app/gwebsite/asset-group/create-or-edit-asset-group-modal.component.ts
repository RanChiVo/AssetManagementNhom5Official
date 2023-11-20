import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Router } from '@angular/router';
import {
    AssetGroupController_05ServiceProxy, AssetTypeControler_05ServiceProxy,
    AssetGroupInput_05, AssetTypeDto_05, PagedResultDtoOfAssetTypeDto_05, AssetTypeViewDto_05,
    AssetGroupDto_05, ComboboxItemDto
} from '@shared/service-proxies/service-proxies';
@Component({
    templateUrl: './create-or-edit-asset-group-modal.component.html',
    animations: [appModuleAnimation()],

})

export class CreateOrEditAssetGroupModalComponent extends AppComponentBase {

    @ViewChild('assetGroupCombobox') assetGroupCombobox: ElementRef;
    @ViewChild('assetTypeCombobox') assetTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    isReadOnly = false;
    assetGroupId: string = "";
    slectedFatherAssetGroup = "";
    assetGroup: AssetGroupDto_05 = new AssetGroupDto_05();
    fatherAssetGroup: AssetGroupInput_05 = new AssetGroupInput_05();
    assetType: AssetTypeDto_05 = new AssetTypeDto_05();
    // suppliers: 
    assetGroups: ComboboxItemDto[] = [];
    assetTypes: ComboboxItemDto[] = [];
    private _assetTypeService: AssetTypeControler_05ServiceProxy;

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private _assetGroupService: AssetGroupController_05ServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._activatedRoute.params.subscribe((params) => {
            this.assetGroupId = params["assetGroupId"];
            this.isReadOnly = params["readOnly"]
            console.log("Is ReadOnly", this.isReadOnly);
        });
        this.show(this.assetGroupId);
    }

    show(assetGroupId?: string | null | undefined): void {
        this.saving = false;
        this._assetGroupService.getAsseGroupEdit(assetGroupId).subscribe(result => {
            this.assetGroup = result.assetGroup;
            this.assetGroups = result.assetGroups;
            this.assetType = result.assetType;
            this.assetTypes = result.assetTypes;
            setTimeout(() => {
                $(this.assetGroupCombobox.nativeElement).selectpicker('refresh');
                $(this.assetTypeCombobox.nativeElement).selectpicker('refresh');
            }, 0);
        });
    }

    check(leveltemp?: number | null): number {
        if (leveltemp != null) {
            return (leveltemp + 1);
        }
        return 1;
    }

    save(): void {
        this.assetGroup.selectedId = this.slectedFatherAssetGroup;
        if (this.assetGroup.selectedId = "") {
            this.assetGroup.level = 1;
        }
        else {
            this._assetGroupService.getAssetGroupForEdit(this.assetGroup.selectedId).subscribe(result => {
                this.fatherAssetGroup = result;
            });
            if (this.fatherAssetGroup.level != null) {
                this.assetGroup.level = this.fatherAssetGroup.level + 1;
            }
        }

        if (this.assetGroup.assetGroupId.length < 3)
            this.notify.warn(this.l('Asset group Id is wrong!!!'));
        else {
            let input = this.assetGroup;
            this.saving = true;
            this._assetGroupService.createOrEditAssetGroup(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this._router.navigate(['/app/gwebsite/asset-group']);
            })
        }
    }

}