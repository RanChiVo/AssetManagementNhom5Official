import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class CategoryTypeDto {
    id: number;
    name: string;
    prefixWord: string;
    description?: string;
    status: boolean;
}

export class GetCategoryTypeOutput {
    categoryType: CategoryTypeDto;
    categoryTypes: ComboboxItemDto[];
}
