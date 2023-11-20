import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class LoaiSoHuuDto
{
    id: number;
    name: string;
}

export class GetLoaiSoHuuOutput
{
    loaisohuu: LoaiSoHuuDto;
    loaisohuus: ComboboxItemDto[];

}
