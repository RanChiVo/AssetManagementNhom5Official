import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class KeHoachXayDungDto
{
    id: number;
    maKeHoachXayDung: string;
    tenKeHoachXayDung:string;
}

export class GetKeHoachXayDungOutput
{
    keHoachXayDung: KeHoachXayDungDto;
    keHoachXayDungs: ComboboxItemDto[];


}
