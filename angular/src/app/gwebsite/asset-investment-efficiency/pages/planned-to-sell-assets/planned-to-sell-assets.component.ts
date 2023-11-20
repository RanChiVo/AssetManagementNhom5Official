import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, NgModule } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AssetActivityServiceProxy } from '@shared/service-proxies/service-proxies';
import moment from 'moment';
import { getGeneralStatisticsData, getDetailedData } from '../../api/asset-purchase';

import { 
    addThousandSeparator,
    getDateRangeString,
    groupBy,
    isDateBetween,
    getRandomColor
} from '../../utils';

@Component({
    templateUrl: './planned-to-sell-assets.component.html',
    styleUrls: ['./planned-to-sell-assets.component.css'],
    animations: [appModuleAnimation()]
})
export class PlannedToSellAssetsComponent extends AppComponentBase implements OnInit {
    private generalStatisticsData;
    private generalStatisticsChart1Data;

    private mainTabLabels = ['Thống kê chung', 'So sánh'];
    private activeMainTab = 0;
    private mainTabTitle = this.mainTabLabels[this.activeMainTab];

    private activeGeneralStatisticsChart1Tab = 0;
    private activeGeneralStatisticsChart2Tab = 0;

    private addThousandSeparator = addThousandSeparator;
    private getDateRangeString = getDateRangeString;

    private showDateRangePicker = false;
    private showGeneralStatisticsChart1ValueTypeSelection = true;
    private showGeneralStatisticsChart2ValueTypeSelection = true;
    private showDetailedPopup = false;

    private startingDate = moment().format('YYYY-MM-DD');
    private endingDate = moment().format('YYYY-MM-DD');
    private statisticsPeriod = 0;

    private detailedDataTableData = [];
    private detailedDataTablePage = 1;
    private detailedDataTableHasNextPage;
    private detailedDataTableStartingDate = moment().format('YYYY-MM-DD');
    private detailedDataTableEndingDate = moment().format('YYYY-MM-DD');
    private detailedDataTableKeyword = '';
    private detailedDataTablePageSize = 10;
    private detailedDataTableAssetTypes = [];
    private detailedDataTableTotalRecords = 0;
    private detailedDataTableTotalPages = 0;
    private detailedDataTableAssetType = -1;
    private detailedPopupDate;

    private generalStatisticsChart1Dataset;
    private generalStatisticsChart1Labels;
    private generalStatisticsChart1Options;
    private generalStatisticsChart1Type = 'bar';
    private generalStatisticsChart1ValueType = 0;
    private generalStatisticsChart1HorizontalAxeLabel = 'Thời gian (Ngày/ Tháng/ Năm)';
    private generalStatisticsChart1VerticalAxeLabel;
    private generalStatisticsChart1ComparisonValue = 0;

    private generalStatisticsChart2Dataset = [];
    private generalStatisticsChart2Labels = [];
    private generalStatisticsChart2Options = [];
    private generalStatisticsChart2Colors = [];
    private generalStatisticsChart2Type = 'pie';
    private generalStatisticsChart2ValueType = 0;
    private generalStatisticsChart2ComparisonValue = 0;

    private generalStatisticsChart3Dataset = [];
    private generalStatisticsChart3Labels = [];
    private generalStatisticsChart3Options = [];
    private generalStatisticsChart3Colors = [];
    private generalStatisticsChart3Type = 'pie';

    constructor(
        injector: Injector,
        private _assetActivityService: AssetActivityServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    ngOnInit() {
        this.fetchData();
    }

    fetchData() {
        this.fetchGeneralStatisticsData();
        this.fetchGeneralStatisticsChart1Data();
    }

    fetchGeneralStatisticsData() {
        setTimeout(() => {
            this.generalStatisticsData = getGeneralStatisticsData({
                starting_date: this.startingDate,
                ending_date: this.endingDate,
                statistics_period: this.statisticsPeriod
            });
        }, 1000);
    }

    fetchGeneralStatisticsChart1Data() {
        setTimeout(() => {
            this.generalStatisticsChart1Data = getDetailedData({
                starting_date: this.startingDate,
                ending_date: this.endingDate,
                statistics_period: this.statisticsPeriod
            });

            this.loadGeneralStatisticsChart1();
            this.loadGeneralStatisticsChart2();
            this.loadDetailedDataTableData();
        }, 1000);
    }

    changeMainTab(value) {
        this.mainTabTitle = this.mainTabLabels[value];
        this.activeMainTab = value;
    }

    changeGeneralStatisticsChart1Tab(value) {
        this.activeGeneralStatisticsChart1Tab = value;
        this.generalStatisticsChart1ValueType = 0;
        this.loadGeneralStatisticsChart1();
    }

    changeGeneralStatisticsChart2Tab(value) {
        this.activeGeneralStatisticsChart2Tab = value;
        this.generalStatisticsChart2ValueType = 0;
        this.loadGeneralStatisticsChart2();
    }

    changeStatisticsPeriod(e) {
        const selectedValue = parseInt(e.target.value);

        switch (selectedValue) {
            case 0:
                this.startingDate = moment().format('YYYY-MM-DD');
                this.endingDate = moment().format('YYYY-MM-DD');
                this.detailedDataTableStartingDate = moment().format('YYYY-MM-DD');
                this.detailedDataTableEndingDate = moment().format('YYYY-MM-DD');
                this.showDateRangePicker = false;
                break;

            case 1:
                this.startingDate = moment().startOf('week').format('YYYY-MM-DD');
                this.endingDate = moment().endOf('week').format('YYYY-MM-DD');
                this.detailedDataTableStartingDate = moment().startOf('week').format('YYYY-MM-DD');
                this.detailedDataTableEndingDate = moment().endOf('week').format('YYYY-MM-DD');
                this.showDateRangePicker = false;
                break;

            case 2:
                this.startingDate = moment().startOf('month').format('YYYY-MM-DD');
                this.endingDate = moment().endOf('month').format('YYYY-MM-DD');
                this.detailedDataTableStartingDate = moment().startOf('month').format('YYYY-MM-DD');
                this.detailedDataTableEndingDate = moment().endOf('month').format('YYYY-MM-DD');
                this.showDateRangePicker = false;
                break;

            case 3:
                this.startingDate = moment().startOf('quarter').format('YYYY-MM-DD');
                this.endingDate = moment().endOf('quarter').format('YYYY-MM-DD');
                this.detailedDataTableStartingDate = moment().startOf('quarter').format('YYYY-MM-DD');
                this.detailedDataTableEndingDate = moment().endOf('quarter').format('YYYY-MM-DD');
                this.showDateRangePicker = false;
                break;

            case 4:
                this.startingDate = moment().startOf('year').format('YYYY-MM-DD');
                this.endingDate = moment().endOf('year').format('YYYY-MM-DD');
                this.detailedDataTableStartingDate = moment().startOf('year').format('YYYY-MM-DD');
                this.detailedDataTableEndingDate = moment().endOf('year').format('YYYY-MM-DD');
                this.showDateRangePicker = false;
                break;

            case 5:
                this.startingDate = moment().format('YYYY-MM-DD');
                this.endingDate = moment().format('YYYY-MM-DD');
                this.detailedDataTableStartingDate = moment().format('YYYY-MM-DD');
                this.detailedDataTableEndingDate = moment().format('YYYY-MM-DD');
                this.showDateRangePicker = true;
                break;
        }
        
        this.statisticsPeriod = parseInt(e.target.value);
        this.activeGeneralStatisticsChart1Tab = 0;
        this.activeGeneralStatisticsChart2Tab = 0;
        this.generalStatisticsChart1ValueType = 0;
        this.generalStatisticsChart2ValueType = 0;

        this.resetDetailedDataTableFilters();
        this.fetchData();
    }

    changeStartingDate(e) {
        if (e.target.value === '' || new Date(e.target.value) > new Date(this.endingDate)) {
            this.startingDate = moment().format('YYYY-MM-DD');
        }
        else {
            this.fetchData();
        }
    }

    changeEndingDate(e) {
        if (e.target.value === '' || new Date(e.target.value) < new Date(this.startingDate)) {
            this.endingDate = moment().format('YYYY-MM-DD');
        }
        else {
            this.fetchData();
        }
    }

    changeDetailedDataTableStartingDate(e) {
        if (e.target.value === '' || new Date(e.target.value) < new Date(this.startingDate) || new Date(e.target.value) > new Date(this.detailedDataTableEndingDate)) {
            this.detailedDataTableStartingDate = moment().format('YYYY-MM-DD');
        }
        else {
            this.loadDetailedDataTableData();
        }
    }

    changeDetailedDataTableEndingDate(e) {
        if (e.target.value === '' || new Date(e.target.value) > new Date(this.endingDate) || new Date(e.target.value) < new Date(this.detailedDataTableStartingDate)) {
            this.detailedDataTableEndingDate = moment().format('YYYY-MM-DD');
        }
        else {
            this.loadDetailedDataTableData();
        }
    }

    changeGeneralStatisticsChart1ValueType(e) {
        this.generalStatisticsChart1ValueType = parseInt(e.target.value);
        this.loadGeneralStatisticsChart1();
    }

    changeGeneralStatisticsChart2ValueType(e) {
        this.generalStatisticsChart2ValueType = parseInt(e.target.value);
        this.loadGeneralStatisticsChart2();
    }

    changeGeneralStatisticsChart1ComparisonValue(e) {
        const value = parseInt(e.target.value);
        this.generalStatisticsChart1ComparisonValue = value;

        if (value === 1) {
            this.showGeneralStatisticsChart1ValueTypeSelection = false;
        }
        else {
            this.showGeneralStatisticsChart1ValueTypeSelection = true;
        }

        this.loadGeneralStatisticsChart1();
    }

    changeGeneralStatisticsChart2ComparisonValue(e) {
        const value = parseInt(e.target.value);
        this.generalStatisticsChart2ComparisonValue = value;

        if (value === 1) {
            this.showGeneralStatisticsChart2ValueTypeSelection = false;
        }
        else {
            this.showGeneralStatisticsChart2ValueTypeSelection = true;
        }

        // this.fetchGeneralStatisticsChart2Data();
    }

    loadDetailedDataTableData() {
        let assetTypes = [];
        let totalRecords = 0;

        this.detailedDataTableData = this.generalStatisticsChart1Data.filter(d => {
            const recordedDate = d['RecordedDate'];
            let condition = isDateBetween(recordedDate, this.detailedDataTableStartingDate, this.detailedDataTableEndingDate);

            if (condition) {
                let contained = false;

                contained = assetTypes.find(type => {
                    return type['AssetTypeId'] === d['AssetTypeId'];
                });

                if (!contained) assetTypes.push({ AssetTypeName: d['AssetTypeName'], AssetTypeId: d['AssetTypeId'] });
            }
        });

        this.detailedDataTableData = this.generalStatisticsChart1Data.filter(d => {
            const recordedDate = d['RecordedDate'];
            let condition = isDateBetween(recordedDate, this.detailedDataTableStartingDate, this.detailedDataTableEndingDate);

            if (this.detailedDataTableAssetType !== -1) {
                condition = condition && (d['AssetTypeId'] === this.detailedDataTableAssetType);
            }

            if (this.detailedDataTableKeyword !== '') {
                condition = condition && d['AssetTypeName'].toLowerCase().includes(this.detailedDataTableKeyword.toLowerCase());
            }

            if (condition) {
                totalRecords++;
                return d;
            }
        }).slice((this.detailedDataTablePage - 1) * this.detailedDataTablePageSize, (this.detailedDataTablePage - 1) * this.detailedDataTablePageSize + this.detailedDataTablePageSize - 1);
        
        this.detailedDataTableAssetTypes = assetTypes;
        this.detailedDataTableTotalPages = Math.ceil(totalRecords / this.detailedDataTablePageSize);
    }

    loadGeneralStatisticsChart2() {
        let chartLabels = [];
        let chartData = [];

        if (this.generalStatisticsChart2ComparisonValue === 0) {
            let processedData = [];

            this.generalStatisticsChart1Data.forEach(d => {
                const recordedDate = d['RecordedDate'];

                if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                    processedData.push(d);
                }
            });

            processedData = groupBy(processedData, 'AssetTypeName');

            if (this.activeGeneralStatisticsChart2Tab === 0) {
                if (this.generalStatisticsChart2ValueType === 0) {
                    let tempData = [];
    
                    for(const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordAmount = 0;
        
                        processedData[key].forEach(d => {
                            recordAmount += d['Amount'];
                        });
        
                        tempData.push(recordAmount);
                    }
    
                    chartData = tempData;
                }
                else {
                    let tempData = [];
                    let totalAmount = 0;
    
                    for (const key of Object.keys(processedData)) {
                        processedData[key].forEach(d => {
                            totalAmount += d['Amount'];
                        });
                    }
    
                    for (const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordAmount = 0;
    
                        processedData[key].forEach(d => {
                            recordAmount += d['Amount'];
                        });
    
                        tempData.push(((recordAmount / totalAmount) * 100).toFixed(2));
                     }

                     chartData = tempData;
                }
            }
            else {
                if (this.generalStatisticsChart2ValueType === 0) {
                    let tempData = [];
    
                    for(const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordAmount = 0;
        
                        processedData[key].forEach(d => {
                            recordAmount += d['Quantity'];
                        });
        
                        tempData.push(recordAmount);
                    }
    
                    chartData = tempData;
                }
                else {
                    let tempData = [];
                    let totalAmount = 0;
    
                    for (const key of Object.keys(processedData)) {
                        processedData[key].forEach(d => {
                            totalAmount += d['Quantity'];
                        });
                    }
    
                    for (const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordAmount = 0;
    
                        processedData[key].forEach(d => {
                            recordAmount += d['Quantity'];
                        });
    
                        tempData.push(((recordAmount / totalAmount) * 100).toFixed(2));
                    }
    
                    chartData = tempData;
                }
            }
        }
        else {

        }

        this.generalStatisticsChart2Labels = chartLabels;
        this.generalStatisticsChart2Dataset = chartData;
        this.generalStatisticsChart2Colors = [{
            backgroundColor: chartData.map(d => {
                return getRandomColor();
            })
        }]
    }

    loadGeneralStatisticsChart1() {
        let chartLabels = [];
        let chartData = [];

        if (this.generalStatisticsChart1ComparisonValue === 0) {
            let processedData = [];

            this.generalStatisticsChart1Data.forEach(d => {
                const recordedDate = d['RecordedDate'];

                if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                    processedData.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                }
            });

            processedData = groupBy(processedData, 'RecordedDate');

            if (this.activeGeneralStatisticsChart1Tab === 0) {
                if (this.generalStatisticsChart1ValueType === 0) {
                    // BIỂU ĐỒ TỔNG SỐ VỐN
                    let tempData = [];

                    for (const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordAmount = 0;

                        processedData[key].forEach(d => {
                            recordAmount += d['Amount'];
                        });

                        tempData.push(recordAmount);
                    }

                    this.generalStatisticsChart1VerticalAxeLabel = 'Số vốn dự kiến thu về (VNĐ)';
                    chartData = [{ data: tempData, label: 'Số vốn dự kiến thu về (VNĐ)' }];
                }
                else {
                    // BIỂU ĐỒ TỈ LỆ SỐ VỐN
                    let tempData = [];
                    let totalAmount = 0;

                    for (const key of Object.keys(processedData)) {
                        processedData[key].forEach(d => {
                            totalAmount += d['Amount'];
                        });
                    }

                    for (const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordAmount = 0;

                        processedData[key].forEach(d => {
                            recordAmount += d['Amount'];
                        });

                        tempData.push(((recordAmount / totalAmount) * 100).toFixed(2));
                    }

                    this.generalStatisticsChart1VerticalAxeLabel = 'Tỉ lệ phần trăm so với tổng số vốn dự kiến thu về (%)';
                    chartData = [{ data: tempData, label: 'Tỉ lệ phần trăm so với tổng số vốn dự kiến thu về (%)' }];
                }
            }
            else {
                if (this.generalStatisticsChart1ValueType === 0) {
                    // BIỂU ĐỒ TỔNG SỐ LƯỢNG TÀI SẢN
                    let tempData = [];

                    for (const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordQuantity = 0;

                        processedData[key].forEach(d => {
                            recordQuantity += d['Quantity'];
                        });

                        tempData.push(recordQuantity);
                    }

                    this.generalStatisticsChart1VerticalAxeLabel = 'Số lượng tài sản dự kiến thanh lý (Tài sản)';
                    chartData = [{ data: tempData, label: 'Số lượng tài sản dự kiến thanh lý (Tài sản)' }];
                }
                else {
                    // BIỂU ĐỒ TỈ LỆ SỐ LƯỢNG TÀI SẢN
                    let tempData = [];
                    let totalQuantity = 0;

                    for (const key of Object.keys(processedData)) {
                        processedData[key].forEach(d => {
                            totalQuantity += d['Quantity'];
                        });
                    }

                    for (const key of Object.keys(processedData)) {
                        chartLabels.push(key);
                        let recordQuantity = 0;

                        processedData[key].forEach(d => {
                            recordQuantity += d['Quantity'];
                        });

                        tempData.push(((recordQuantity / totalQuantity) * 100).toFixed(2));
                    }

                    this.generalStatisticsChart1VerticalAxeLabel = 'Tỉ lệ phần trăm so với tổng số lượng tài sản dự kiến thanh lý (%)';
                    chartData = [{ data: tempData, label: 'Tỉ lệ phần trăm so với tổng số lượng tài sản dự kiến thanh lý (%)' }];
                }
            }
        }
        else {
            let processedData1 = [];
            let processedData2 = [];

            this.generalStatisticsChart1Data.forEach(d => {
                const recordedDate = d['RecordedDate'];
                const previousStartingDate = new Date(moment(new Date(this.startingDate)).subtract(1, 'years').startOf('day').toString());
                const previousEndingDate = new Date(moment(new Date(this.endingDate)).subtract(1, 'years').endOf('day').toString());

                if (isDateBetween(recordedDate, this.startingDate, this.endingDate)) {
                    processedData1.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                }
                else {
                    if (this.statisticsPeriod <= 4) {
                        processedData2.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                    }
                    else {
                        if (isDateBetween(recordedDate, previousStartingDate, previousEndingDate)) {
                            processedData2.push({ ...d, RecordedDate: moment(recordedDate).format('DD/MM/YYYY') });
                        }
                    }
                }
            });

            processedData1 = groupBy(processedData1, 'RecordedDate');
            processedData2 = groupBy(processedData2, 'RecordedDate');

            if (this.activeGeneralStatisticsChart1Tab === 0) {
                // BIỂU ĐỒ TỔNG SỐ VỐN
                let tempData1 = [];
                let tempData2 = [];
                let i = 0;

                for (const key of Object.keys(processedData1)) {
                    i++;
                    switch (this.statisticsPeriod) {
                        case 0:
                            chartLabels.push('Hôm qua và hôm nay');
                            break;
                        
                        case 1:
                            const dayOfWeek = moment(key, 'DD/MM/YYYY').day();
                            const dayOfWeekString = dayOfWeek === 0 ? 'Chủ nhật' : `Thứ ${ dayOfWeek + 1}`;
                            chartLabels.push(dayOfWeekString);
                            break;
                        
                        case 2:
                            chartLabels.push(`Ngày ${ i }`);
                            break;

                        case 3:
                            chartLabels.push(`Ngày ${ i }`);
                            break;
                        
                        case 4:
                            chartLabels.push(key.split('/').slice(0, 2).join('/'));
                            break;

                        case 5:
                            chartLabels.push(key.split('/').slice(0, 2).join('/'));
                            break;
                    }

                    let recordAmount = 0;

                    processedData1[key].forEach(d => {
                        recordAmount += d['Amount'];
                    });

                    tempData1.push(recordAmount);
                }

                for (const key of Object.keys(processedData2)) {
                    let recordAmount = 0;

                    processedData2[key].forEach(d => {
                        recordAmount += d['Amount'];
                    });

                    tempData2.push(recordAmount);
                }

                this.generalStatisticsChart1VerticalAxeLabel = 'Số vốn dự kiến thu về (VNĐ)';

                chartData = [
                    { data: tempData1, label: `${ moment(new Date(this.startingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.endingDate)).format('DD/MM/YYYY') }` },
                    { data: tempData2, label: `${ Object.keys(processedData2)[0] } - ${ Object.keys(processedData2)[Object.keys(processedData2).length - 1] }` }
                ];
            }
            else {
                // BIỂU ĐỒ TỔNG SỐ LƯỢNG TÀI SẢN
                let tempData1 = [];
                let tempData2 = [];
                let i = 0;

                for (const key of Object.keys(processedData1)) {
                    i++;
                    switch (this.statisticsPeriod) {
                        case 0:
                            chartLabels.push('Hôm qua và hôm nay');
                            break;
                        
                        case 1:
                            const dayOfWeek = moment(key, 'DD/MM/YYYY').day();
                            const dayOfWeekString = dayOfWeek === 0 ? 'Chủ nhật' : `Thứ ${ dayOfWeek + 1}`;
                            chartLabels.push(dayOfWeekString);
                            break;
                        
                        case 2:
                            chartLabels.push(`Ngày ${ i }`);
                            break;

                        case 3:
                            chartLabels.push(`Ngày ${ i }`);
                            break;
                        
                        case 4:
                            chartLabels.push(key.split('/').slice(0, 2).join('/'));
                            break;

                        case 5:
                            chartLabels.push(key.split('/').slice(0, 2).join('/'));
                            break;
                    }

                    let recordAmount = 0;

                    processedData1[key].forEach(d => {
                        recordAmount += d['Quantity'];
                    });

                    tempData1.push(recordAmount);
                }

                for (const key of Object.keys(processedData2)) {
                    let recordAmount = 0;

                    processedData2[key].forEach(d => {
                        recordAmount += d['Quantity'];
                    });

                    tempData2.push(recordAmount);
                }

                this.generalStatisticsChart1VerticalAxeLabel = 'Số lượng tài sản dự kiến thanh lý (Tài sản)';

                chartData = [
                    { data: tempData1, label: `${ moment(new Date(this.startingDate)).format('DD/MM/YYYY') } - ${ moment(new Date(this.endingDate)).format('DD/MM/YYYY') }` },
                    { data: tempData2, label: `${ Object.keys(processedData2)[0] } - ${ Object.keys(processedData2)[Object.keys(processedData2).length - 1] }` }
                ];
            }
        }

        this.generalStatisticsChart1Labels = chartLabels;
        this.generalStatisticsChart1Dataset = chartData;
        this.generalStatisticsChart1Options = {
            scaleShowVerticalLines: false,
            responsive: true,
            scales: {
                yAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: this.generalStatisticsChart1VerticalAxeLabel
                    }
                }],
                xAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: this.generalStatisticsChart1HorizontalAxeLabel
                    }
                }]
            }
        };
    }

    openDetailedPopup(record) {
        this.detailedPopupDate = record['RecordedDate'];
        this.showDetailedPopup = true;
    }

    closeDetailedPopup() {
        this.showDetailedPopup = false;
    }

    changeDetailedDataTableKeyword(e) {
        this.detailedDataTableKeyword = e.target.value;
        this.loadDetailedDataTableData();
    }

    changeDetailedDataTablePageSize(e) {
        this.detailedDataTablePageSize = parseInt(e.target.value);
        this.loadDetailedDataTableData();
    }

    navigateToPreviousPage() {
        if (this.detailedDataTablePage > 1) {
            this.detailedDataTablePage--;
            this.loadDetailedDataTableData();
        }
    }

    navigateToNextPage() {
        if (this.detailedDataTablePage < this.detailedDataTableTotalPages) {
            this.detailedDataTablePage++;
            this.loadDetailedDataTableData();
        }
    }

    changeDetailedDataTableAssetType(e) {
        if (parseInt(e.target.value) === -1) {
            this.detailedDataTableAssetType = -1;
        }
        else {
            this.detailedDataTableAssetType = e.target.value;
        }
        this.loadDetailedDataTableData();
    }

    resetDetailedDataTableFilters() {
        this.detailedDataTableAssetType = -1;
        this.detailedDataTablePage = 1;
        this.detailedDataTablePageSize = 10;
    }
}
