
    import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
    import { AppComponentBase } from '@shared/common/app-component-base';
    import { ModalDirective } from 'ngx-bootstrap';
    import { NhaCungCapHangHoaServiceProxy, NhaCungCapHangHoaInput, LoaiNhaCungCapDto, ComboboxItemDto , LoaiNhaCungCapServiceProxy} from '@shared/service-proxies/service-proxies';
    import { ActivatedRoute, Router } from '@angular/router';
    import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';
    
    
    @Component({
        selector: 'createOrEditNhaCungCapHangHoaModal',
        templateUrl: './create-or-edit-NhaCungCapHangHoa-modal.component.html'
    })
    export class CreateOrEditNhaCungCapHangHoaModalComponent extends AppComponentBase {
    
    
        @ViewChild('createOrEditModal') modal: ModalDirective;
        @ViewChild('NhaCungCapHangHoaCombobox') NhaCungCapHangHoaCombobox: ElementRef;
        @ViewChild('iconCombobox') iconCombobox: ElementRef;
        @ViewChild('dateInput') dateInput: ElementRef;
        @ViewChild('LoaiNhaCungCapCombobox') LoaiNhaCungCapCombobox: ElementRef;
    
        /**
         * @Output dùng để public event cho component khác xử lý
         */
        @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    
        saving = false;
    
        nhaCungCapHangHoa: NhaCungCapHangHoaInput = new NhaCungCapHangHoaInput();
        loaiNhaCungCap: LoaiNhaCungCapDto=new LoaiNhaCungCapDto();
       selectedType: number;
       temp: string;
       loaiNhaCungCaps: Array<LoaiNhaCungCapDto>=[];
        constructor(
            injector: Injector,
            private _nhaCungCapHangHoaService: NhaCungCapHangHoaServiceProxy,
            private _router: Router,
            private _activatedRoute: ActivatedRoute,
            private _apiService: WebApiServiceProxy,
            private _loaiNhaCungCapService: LoaiNhaCungCapServiceProxy
        
        ) {
            super(injector);
            this.getTypes();
        }
        getTypes(): void {
            // get category type
           /* this._apiService.get('api/LoaiNhaCungCap/GetLoaiNhaCungCapsByFilter').subscribe(result => {
                this.loaiNhaCungCaps = result.items;
            });*/
            this._loaiNhaCungCapService.getLoaiNhaCungCapsByFilter(null,"",100,0).subscribe(result =>{
                this.loaiNhaCungCaps=result.items;
            })
        }
        onChangeType(): void {
            this._apiService.getForEdit('api/LoaiNhaCungCap/GetLoaiNhaCungCapForView', this.selectedType).subscribe(result => {
                // this.nhaCungCapHangHoa.maLoaiNhaCungCap = result.tenLoaiNhaCungCap;
                // this.loaiNhaCungCap.maLoaiNhaCungCap = result.maLoaiNhaCungCap; 
                this.temp = result.tenLoaiNhaCungCap;
            });
        }
    
        show(nhaCungCapHangHoaId?: number | null | undefined): void {
            this.saving = false;
    
    
            this._nhaCungCapHangHoaService.getNhaCungCapHangHoaForEdit(nhaCungCapHangHoaId).subscribe(result => {
                this.nhaCungCapHangHoa = result;
                this.modal.show();
    
            })
            /*this._nhaCungCapHangHoaService.getLoaiNhaCungCapComboboxForEditAsync(nhaCungCapHangHoaId).subscribe(result=>{
                this.loaiNhaCungCap=result.loaiNhaCungCap;
                this.loaiNhaCungCaps=result.loaiNhaCungCaps;
                this.modal.show();
                setTimeout(()=>{
                    $(this.LoaiNhaCungCapCombobox.nativeElement).selectpicker('refresh');
                },0);
            })*/
        }
    
        /*save(): void {
            let input = this.nhaCungCapHangHoa;
            this.saving = true;
            
            input.maLoaiNhaCungCap = this.temp;
            this._nhaCungCapHangHoaService.createOrEditNhaCungCapHangHoa(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })

        }*/
        save(): void {
            let input = this.nhaCungCapHangHoa;
            this.saving = true;
            
            input.maLoaiNhaCungCap = this.temp;
            console.log(input.maNhaCungCap);
            this._nhaCungCapHangHoaService.createOrEditNhaCungCapHangHoa(input).subscribe(result => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })

        }
    
        close(): void {
            this.modal.hide();
            this.modalSave.emit(null);
        }
    }
    