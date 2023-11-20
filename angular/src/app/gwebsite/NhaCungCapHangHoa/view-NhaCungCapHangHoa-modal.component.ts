
    import { NhaCungCapHangHoaForViewDto }         from './../../../shared/service-proxies/service-proxies';
    import { AppComponentBase } from "@shared/common/app-component-base";
    import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
    import { NhaCungCapHangHoaServiceProxy } from "@shared/service-proxies/service-proxies";
    import { ModalDirective } from 'ngx-bootstrap';
    
    @Component({
        selector: 'viewNhaCungCapHangHoaModal',
        templateUrl: './view-NhaCungCapHangHoa-modal.component.html'
    })
    
    export class ViewNhaCungCapHangHoaModalComponent extends AppComponentBase {
    
        nhaCungCapHangHoa : NhaCungCapHangHoaForViewDto = new NhaCungCapHangHoaForViewDto();
        @ViewChild('viewModal') modal: ModalDirective;
    
        constructor(
            injector: Injector,
            private _nhaCungCapHangHoaService: NhaCungCapHangHoaServiceProxy
        ) {
            super(injector);
        }
    
        show(nhaCungCapHangHoaId?: number | null | undefined): void {
            this._nhaCungCapHangHoaService.getNhaCungCapHangHoaForView(nhaCungCapHangHoaId).subscribe(result => {
                this.nhaCungCapHangHoa = result;
                this.modal.show();
            })
        }
    
        close() : void{
            this.modal.hide();
        }
    }
    