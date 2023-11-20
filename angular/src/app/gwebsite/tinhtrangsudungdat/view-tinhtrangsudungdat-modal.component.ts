import { TinhTrangSuDungDatForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { TinhTrangSuDungDatServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewTinhTrangSuDungDatModal',
    templateUrl: './view-tinhtrangsudungdat-modal.component.html'
})

export class ViewTinhTrangSuDungDatModalComponent extends AppComponentBase {

    tinhtrangsudungdat : TinhTrangSuDungDatForViewDto = new TinhTrangSuDungDatForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _tinhtrangsudungdatService: TinhTrangSuDungDatServiceProxy
    ) {
        super(injector);
    }

    show(tinhtrangsudungdatId?: number | null | undefined): void {
        this._tinhtrangsudungdatService.getTinhTrangSuDungDatForView(tinhtrangsudungdatId).subscribe(result => {
            this.tinhtrangsudungdat = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
