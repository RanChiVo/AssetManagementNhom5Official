import AssetPurchase from '../data/AssetPurchase';
import moment from 'moment';

export const getGeneralStatisticsData = (options) => {
    const currentStartingDate = new Date(options['starting_date']) || new Date();
    const currentEndingDate = new Date(options['ending_date']) || new Date();
    const statisticsPeriod = parseInt(options['statistics_period']) || 0;
    let previousStartingDate;
    let previousEndingDate;

    switch(statisticsPeriod) {
        case 0:
            previousStartingDate = new Date(moment().subtract(1, 'days').startOf('day').toString());
            previousEndingDate = new Date(moment().subtract(1, 'days').endOf('day').toString());
            break;

        case 1:
            previousStartingDate = new Date(moment().subtract(1, 'weeks').startOf('week').toString());
            previousEndingDate = new Date(moment().subtract(1, 'weeks').endOf('week').toString());
            break;

        case 2:
            previousStartingDate = new Date(moment().subtract(1, 'months').startOf('month').toString());
            previousEndingDate = new Date(moment().subtract(1, 'months').endOf('month').toString());
            break;

        case 3:
            previousStartingDate = new Date(moment().subtract(1, 'quarters').startOf('quarter').toString());
            previousEndingDate = new Date(moment().subtract(1, 'quarters').endOf('quarter').toString());
            break;

        case 4:
            previousStartingDate = new Date(moment().subtract(1, 'years').startOf('year').toString());
            previousEndingDate = new Date(moment().subtract(1, 'years').endOf('year').toString());
            break;

        default:
            previousStartingDate = new Date(moment(new Date(currentStartingDate)).subtract(1, 'years').startOf('day').toString());
            previousEndingDate = new Date(moment(new Date(currentEndingDate)).subtract(1, 'years').endOf('day').toString());
    }

    let currentTotalInvestedAmount = 0;
    let currentTotalPurchasedAssets = 0;
    let previousTotalInvestedAmount = 0;
    let previousTotalPurchasedAssets = 0;

    const result = {
        CurrentTotalInvestedAmount: 0,
        CurrentTotalPurchasedAssets: 0,
        CurrentStartingDate: currentStartingDate,
        CurrentEndingDate: currentEndingDate,
        PreviousTotalInvestedAmount: 0,
        PreviousTotalPurchasedAssets: 0,
        PreviousStartingDate: previousStartingDate,
        PreviousEndingDate: previousEndingDate,
        TotalInvestedAmountRatio: 0,
        TotalPurchasedAssetsRatio: 0
    };

    for (let i = 0; i < AssetPurchase.length; i++) {
        let recordedDate = new Date(AssetPurchase[i]['RecordedDate']);

        if (recordedDate >= previousStartingDate && recordedDate <= previousEndingDate) {
            previousTotalInvestedAmount += AssetPurchase[i]['Amount'];
            previousTotalPurchasedAssets += AssetPurchase[i]['Quantity'];
        }
    }

    for (let i = 0; i < AssetPurchase.length; i++) {
        const recordedDate = new Date(AssetPurchase[i]['RecordedDate']);


        if (recordedDate >= currentStartingDate && recordedDate <= currentEndingDate) {
            currentTotalInvestedAmount += AssetPurchase[i]['Amount'];
            currentTotalPurchasedAssets += AssetPurchase[i]['Quantity'];
        }
    }

    const totalInvestedAmountRatio = (((currentTotalInvestedAmount - previousTotalInvestedAmount) / previousTotalInvestedAmount) * 100);
    const totalPurchasedAssetsRatio = (((currentTotalPurchasedAssets - previousTotalPurchasedAssets) / previousTotalPurchasedAssets) * 100);

    result['CurrentTotalInvestedAmount'] = currentTotalInvestedAmount;
    result['CurrentTotalPurchasedAssets'] = currentTotalPurchasedAssets;
    result['PreviousTotalPurchasedAssets'] = previousTotalPurchasedAssets;
    result['PreviousTotalPurchasedAssets'] = previousTotalPurchasedAssets;
    result['TotalInvestedAmountRatio'] = totalInvestedAmountRatio;
    result['TotalPurchasedAssetsRatio'] = totalPurchasedAssetsRatio;

    return result;
}

export const getDetailedData = (options) => {
    const currentStartingDate = new Date(options['starting_date']) || new Date();
    const currentEndingDate = new Date(options['ending_date']) || new Date();
    const statisticsPeriod = parseInt(options['statistics_period']) || 0;
    let previousStartingDate;
    let previousEndingDate;
    let result = [];

    switch(statisticsPeriod) {
        case 0:
            previousStartingDate = new Date(moment().subtract(1, 'days').startOf('day').toString());
            previousEndingDate = new Date(moment().subtract(1, 'days').endOf('day').toString());
            break;

        case 1:
            previousStartingDate = new Date(moment().subtract(1, 'weeks').startOf('week').toString());
            previousEndingDate = new Date(moment().subtract(1, 'weeks').endOf('week').toString());
            break;

        case 2:
            previousStartingDate = new Date(moment().subtract(1, 'months').startOf('month').toString());
            previousEndingDate = new Date(moment().subtract(1, 'months').endOf('month').toString());
            break;

        case 3:
            previousStartingDate = new Date(moment().subtract(1, 'quarters').startOf('quarter').toString());
            previousEndingDate = new Date(moment().subtract(1, 'quarters').endOf('quarter').toString());
            break;

        case 4:
            previousStartingDate = new Date(moment().subtract(1, 'years').startOf('year').toString());
            previousEndingDate = new Date(moment().subtract(1, 'years').endOf('year').toString());
            break;

        default:
            previousStartingDate = new Date(moment(new Date(currentStartingDate)).subtract(1, 'years').startOf('day').toString());
            previousEndingDate = new Date(moment(new Date(currentEndingDate)).subtract(1, 'years').endOf('day').toString());
    }

    for (let i = 0; i < AssetPurchase.length; i++) {
        const recordedDate = new Date(AssetPurchase[i]['RecordedDate']);

        if (recordedDate >= previousStartingDate && recordedDate <= currentEndingDate) {
            result.push(AssetPurchase[i]);
        }
    }

    return result;
}