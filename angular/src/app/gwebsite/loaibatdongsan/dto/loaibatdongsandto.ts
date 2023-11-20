import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class LoaiBatDongSanDto
{
    id: number;
    name: string;
}

export class GetLoaiBatDongSanOutput
{
    loaiBatDongSan: LoaiBatDongSanDto;
    loaiBatDongSans: ComboboxItemDto[];


}
