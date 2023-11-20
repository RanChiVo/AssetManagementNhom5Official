import { ProjectForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ProjectServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewDuAnModal',
    templateUrl: './view-duan-modal.component.html'
})

export class ViewDuAnModalComponent extends AppComponentBase {

    duan: ProjectForViewDto = new ProjectForViewDto();
    @ViewChild('viewDuAnModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _duanService: ProjectServiceProxy
    ) {
        super(injector);
    }

    show(duanId?: number | null | undefined): void {
        this._duanService.getProjectForView(duanId).subscribe(result => {
            this.duan = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
