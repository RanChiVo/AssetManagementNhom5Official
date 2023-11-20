import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class HoSoThauDto {
    maHoSo!: string | undefined;
    hangMucThau!: string | undefined;
    hinhThucThau!: string | undefined;
    soTienBaoLanh!: string | undefined;
    trangThaiDuyet!: string | undefined;
    ngayBatDauHoSo!: string | undefined;
    ngayKetThucHoSo!: string | undefined;
    id!: number | undefined;
}

export class HoSoThauOutput {
    hosoThau: HoSoThauDto;
    hosoThaus: ComboboxItemDto[];
}
