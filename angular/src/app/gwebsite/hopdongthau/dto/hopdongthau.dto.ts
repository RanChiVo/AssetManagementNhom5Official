import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class HopDongThauDto {
    maHopDong!: string | undefined;
    maHoSo!: string | undefined;
    tenHopDong!: string | undefined;
    tenNhaCungCap!: string | undefined;
    ngayTaoHopDong!: string | undefined;
    trangThaiDuyet!: string | undefined;
    id!: number | undefined;
}

export class HopDongThauOutput {
    hopdongThau: HopDongThauDto;
    hopdongThaus: ComboboxItemDto[];
}
