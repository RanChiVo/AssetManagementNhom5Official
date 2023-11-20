import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild
} from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import {
    VehicleServiceProxy,
    VehicleInput,
    TypeVehicleDto,
    ModelVehicleDto,
    ComboboxItemDto,
    Asset_8Input,
    TypeVehicleServiceProxy
} from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Router } from "@angular/router";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
import { SelectAsset_8ModalComponent } from "../asset_8/select-asset_8-modal.component";
import { nextTick } from "q";
import { Asset_8ServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditVehicleModal",
    templateUrl: "./create-or-edit-vehicle-modal.component.html"
})
export class CreateOrEditVehicleModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("vehicleCombobox") vehicleCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;
    @ViewChild("TypeVehicleCombobox") TypeVehicleCombobox: ElementRef;
    @ViewChild("ModelVehicleCombobox") ModelVehicleCombobox: ElementRef;
    @ViewChild("selectAsset_8Modal")
    selectAsset_8Modal: SelectAsset_8ModalComponent;
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vehicle: VehicleInput = new VehicleInput();
    typeVehicle: TypeVehicleDto = new TypeVehicleDto();
    selectedType: number;
    selectedModel: number;
    temp: string;
    typevehicles: Array<TypeVehicleDto> = [];
    modelvehicles: Array<ModelVehicleDto> = [];
    listVehicles: Array<VehicleInput> = [];
    selectedAsset: number;
    nextID: any;
    taisan: Asset_8Input = new Asset_8Input();

    constructor(
        injector: Injector,
        private _vehicleService: VehicleServiceProxy,
        private _typeVehicle: TypeVehicleServiceProxy,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _assetService: Asset_8ServiceProxy,
        private _apiService: WebApiServiceProxy
    ) {
        super(injector);
        this.getTypes();
        this.getModels();
    }
    getTypes(): void {
        // this._apiService
        //     .get("api/Vehicle/getAllTypeVehicles")
        //     .subscribe(result => {
        //         this.listVehicles = result.items;
        //     });

        this._typeVehicle
            .getTypeVehiclesByFilter(null, "", 20, 0)
            .subscribe(result => {
                this.typevehicles = result.items;
            });
    }
    getModels(): void {
        // get category type
        this._apiService
            .get("api/ModelVehicle/GetModelVehiclesByFilter")
            .subscribe(result => {
                this.modelvehicles = result.items;
            });
    }
    getNewListVehicle() {
        this._apiService
            .get("api/Vehicle/GetVehiclesByFilter")
            .subscribe(result => {
                this.listVehicles = result.items;
            });
    }
    onChangeType(): void {
        this._apiService
            .getForEdit(
                "api/TypeVehicle/GetTypeVehicleForView",
                this.selectedType
            )
            .subscribe(result => {
                this.temp = result.nameTypeCar;
                this.vehicle.idTypeCar = result.nameTypeCar;
            });
    }
    onChangeModel(): void {
        this._apiService
            .getForEdit(
                "api/ModelVehicle/GetModelVehicleForView",
                this.selectedModel
            )
            .subscribe(result => {
                this.temp = result.nameModel;
                this.vehicle.model = result.nameModel;
            });
        console.log(this.vehicle.idModel);
    }
    show(vehicleId?: number | null | undefined): void {
        this.saving = false;

        this._vehicleService.getVehicleForEdit(vehicleId).subscribe(result => {
            this.vehicle = result;

            this.modal.show();
        });
    }

    showTaiSan(): void {
        console.log("Mo tai san");
        this.selectAsset_8Modal.show();
    }
    save(): void {
        let input = this.vehicle;
        this.saving = true;
        this._vehicleService
            .createOrEditVehicle(input, this.selectedAsset)
            .subscribe(result => {
                this.notify.info(this.l("SavedSuccessfully"));
                this.close();
            });
    }
    updateAsset(): void {
        if (this.selectAsset_8Modal.selectedMaTS != -1) {
            this.selectedAsset = this.selectAsset_8Modal.selectedMaTS;
            this._apiService
                .getForEdit("api/Asset_8/GetAsset_8ForView", this.selectedAsset)
                .subscribe(result => {
                    // this.mataisanName = result.maTaiSan;
                    this.taisan = result;
                    // this.taisan.maTaiSan = result.maTaiSan;
                    // this.taisan.maNhomTaiSan = result.maNhomTaiSan;
                    // this.taisan.maLoaiTaiSan = result.maLoaiTaiSan;
                    // this.taisan.diaChi = result.diaChi;
                    // this.taisan.tenTaiSan = result.tenTaiSan;
                    // this.taisan.tinhTrangTaiSan=result.tinhTrangTaiSan;
                    // this.taisan.giaTinhKhauHao=result.giaTinhKhauHao;
                    // this.taisan.nguyenGiaTaiSan = result.nguyenGiaTaiSan;
                    // this.taisan.ghiChu = result.ghiChu;
                    // this.taisan.id=result.id;
                    // this.taisan.ngayBatDauKhauHao=result.ngayBatDauKhauHao;
                    // this.tai
                });
        }
    }
    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
