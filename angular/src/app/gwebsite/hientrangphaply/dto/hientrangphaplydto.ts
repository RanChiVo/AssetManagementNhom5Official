import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class HienTrangPhapLyDto
{
    id: number;
    name: string;
}

export class GetLoaiSoHuuOutput
{
    hientrangphaply: HienTrangPhapLyDto;
    listhientrangphaply: ComboboxItemDto[];

}
