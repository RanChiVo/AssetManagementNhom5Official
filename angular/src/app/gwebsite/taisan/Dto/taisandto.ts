import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class TaiSanDto
{
    id: number;
    maTaiSan: string;
    tenTaiSan:string;
}

export class GetTaiSanOutput
{
    taiSan: TaiSanDto;
    taiSans: ComboboxItemDto[];


}
