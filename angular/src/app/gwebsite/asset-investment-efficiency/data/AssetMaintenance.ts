import moment from 'moment';
import { STARTING_DATE, ENDING_DATE, MIN_AMOUNT, MAX_AMOUNT, MIN_NUMBER, MAX_NUMBER } from './constants';
import { getRandomValue } from '../utils';
import AssetType from './AssetType';

let data = [];

for (let d = STARTING_DATE; d <= ENDING_DATE; d.setDate(d.getDate() + 1)) {
    const assetTypes = getRandomValue(1, AssetType.length);

    for(let i = 0; i < assetTypes; i++) {
        const assetType = AssetType[getRandomValue(0, AssetType.length - 1)];

        data.push({
            RecordedDate: moment(d),
            AssetTypeId: assetType && assetType['Id'],
            AssetTypeName: assetType && assetType['Name'],
            Amount: getRandomValue(MIN_AMOUNT, MAX_AMOUNT),
            Quantity: getRandomValue(MIN_NUMBER, MAX_NUMBER)
        });
    }
}

export default data;