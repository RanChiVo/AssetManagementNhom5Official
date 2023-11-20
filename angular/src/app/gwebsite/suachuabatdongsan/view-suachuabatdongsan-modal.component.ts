import { SuaChuaBatDongSanForViewDto, TaiSanInput, BatDongSanInput } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { SuaChuaBatDongSanServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'viewSuaChuaBatDongSanModal',
    templateUrl: './view-suachuabatdongsan-modal.component.html'
})



export class ViewSuaChuaBatDongSanModalComponent extends AppComponentBase {

    suachuabatdongsan: SuaChuaBatDongSanForViewDto = new SuaChuaBatDongSanForViewDto();
    taisan: TaiSanInput = new TaiSanInput();
    batdongsan: BatDongSanInput = new BatDongSanInput();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _suachuabatdongsanService: SuaChuaBatDongSanServiceProxy,
        private _apiService: WebApiServiceProxy,
    ) {
        super(injector);
    }

    show(suachuabatdongsanId: number | null | undefined): void {
        this._suachuabatdongsanService.getSuaChuaBatDongSanForView(suachuabatdongsanId).subscribe(result => {
            this.suachuabatdongsan = result;
            this.modal.show();
        })
    }

    updateTaiSan(selectedTaiSan:number) {
        console.log("update data");
        this._apiService.getForEdit('api/TaiSan/GetTaiSanForView',selectedTaiSan).subscribe(result => {
            this.taisan = result;
        });


    }



    close(): void {
        this.modal.hide();
    }
}
