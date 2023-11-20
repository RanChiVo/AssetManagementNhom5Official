import { ComboboxItemDto } from '@shared/service-proxies/service-proxies';

export class CategoryDto {
    id: number;
    status: boolean;
    name: string;
    symbol: string;
    description: string;
    categoryType: string;
    categoryId: string;
    createdDate: Date;
    createdBy: string;
    updatedDate: Date;
    updatedBy: string;
}

export class GetCategoryOutput {
    category: CategoryDto;
    categories: ComboboxItemDto[];
}
