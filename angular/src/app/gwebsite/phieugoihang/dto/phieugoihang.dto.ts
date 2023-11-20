import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class ContractDto {
    contractCode!: string | undefined;
    bidCode!: string | undefined;
    contractName!: string | undefined;
    supplierName!: string | undefined;
    contractDayCreate!: string | undefined;
    ApprovalStatus!: string | undefined;
    id!: number | undefined;
}

export class ContractOutput {
    contract: ContractDto;
    contracts: ComboboxItemDto[];
}
