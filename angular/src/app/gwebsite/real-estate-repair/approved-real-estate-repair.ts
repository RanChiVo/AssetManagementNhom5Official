import { RealEstateRepairForViewDto_9, RealEstateRepairInput_9 } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild, EventEmitter, Output } from "@angular/core";
import { RealEstateRepairServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'approvedRealEstateRepairModal',
    templateUrl: './approved-real-estate-repair.html'
})

export class ApprovedRealEstateRepairModalComponent extends AppComponentBase {

    realEstateRepairInput: RealEstateRepairInput_9 = new RealEstateRepairInput_9();
    realEstateRepair: RealEstateRepairForViewDto_9 = new RealEstateRepairForViewDto_9();
    @ViewChild('approvedRealEstateRepairModal') modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    constructor(
        injector: Injector,
        private _realEstateRepairService: RealEstateRepairServiceProxy
    ) {
        super(injector);
    }

    show(customerId?: number | null | undefined): void {
        this._realEstateRepairService.getRealEstateRepairForView(customerId).subscribe(result => {
            this.realEstateRepair = result;
            this.modal.show();
        })
        this._realEstateRepairService.getRealEstateRepairForEdit(customerId).subscribe(result => {
            this.realEstateRepairInput = result;
        })
    }

    yes(): void {
        this.realEstateRepairInput.trangThaiDuyet = "Đã duyệt";
        this._realEstateRepairService.createOrEditRealEstateRepair(this.realEstateRepairInput).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }

    no(): void {
        this.realEstateRepairInput.trangThaiDuyet = "Đã hủy";
        this._realEstateRepairService.createOrEditRealEstateRepair(this.realEstateRepairInput).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }


    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
