import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class BatDongSanDTO
{
    id: number;
    maBatDongSan: string;
    mataisan: string;
    nguyengiataisan:string;
    diachi:string;
}

export class GetBatDongSanOutput
{
    batDongsan: BatDongSanDTO;
    listBatdongsan: ComboboxItemDto[];
}
