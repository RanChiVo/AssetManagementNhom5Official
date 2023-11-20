import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { AppIncomeStatisticsDateInterval } from '@shared/AppEnums';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AssetDashboardDataOutput, AssetDashboardServiceProxy } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';
import { Table } from 'primeng/components/table/table';

@Component({
    templateUrl: './asset-dashboard.component.html',
    styleUrls: ['./asset-dashboard.component.less'],
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class AssetDashboardComponent extends AppComponentBase implements AfterViewInit, OnInit {
    @ViewChild('DashboardDateRangePicker') dateRangePickerElement: ElementRef;
    @ViewChild('AssetTotalNumberStatisticsChart') assetTotalNumberStatisticsChart: ElementRef;
    @ViewChild('AssetStatusStatisticsChart') assetStatusStatisticsChart: ElementRef;

    loading = false;
    loadingAssetTotalNumberStatistics = false;
    isInitialized: boolean;
    assetDashboardDataOutput: AssetDashboardDataOutput;
    initialStartDate: moment.Moment = moment().add(-7, 'days').startOf('day');
    initialEndDate: moment.Moment = moment().endOf('day');
    currency = '$';
    appIncomeStatisticsDateInterval = AppIncomeStatisticsDateInterval;//keep this parameter because dont need to create new parameter
    selectedAssetTotalNumberStatisticsDateInterval: number;
    assetTotalNumberStatisticsHasData: boolean;
    assetStatusStatisticsHasData: boolean;
    selectedDateRange = {
        startDate: this.initialStartDate,
        endDate: this.initialEndDate
    };

    private _$editionsTable: JQuery;



    constructor(
        injector: Injector,
        private _dateTimeService: DateTimeService,
        private _assetDashboardService: AssetDashboardServiceProxy
    ) {
        super(injector);
    }

    init(): void {
        this.selectedAssetTotalNumberStatisticsDateInterval = AppIncomeStatisticsDateInterval.Daily;
    }

    ngOnInit(): void {
        this.init();
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.createDateRangePicker();
            this.getAssetDashboardStatisticsData();
            this.bindToolTipForAssetTotalNumberStatisticsChart($(this.assetTotalNumberStatisticsChart.nativeElement));
            mApp.initScroller($('.m-scrollable'), {});
        }, 0);
    }

    createDateRangePicker(): void {
        $(this.dateRangePickerElement.nativeElement)
            .daterangepicker(
                $.extend(true, this._dateTimeService.createDateRangePickerOptions(), this.selectedDateRange),
                (start, end, label) => {
                    this.selectedDateRange.startDate = start;
                    this.selectedDateRange.endDate = end;
                    this.getAssetDashboardStatisticsData();
                });
    }

    getAssetDashboardStatisticsData(): void {
        this.loading = true;
        this._assetDashboardService
            .getAssetDashboardData(
                this.selectedAssetTotalNumberStatisticsDateInterval,
                this.selectedDateRange.startDate,
                this.selectedDateRange.endDate
            )
            .subscribe(result => {
                this.assetDashboardDataOutput = result;
                this.drawAssetStatusStatisticsData(result.assetStatusStatistics);
                this.drawAssetTotalNumberStatisticsChart(result.assetTotalNumberStatistics);
                this.loading = false;
            });
    }

    /*
    * Edition statistics pie chart
    */

    normalizeAssetStatusStatisticsData(data): Array<any> {
        const colorPalette = ['#81A17E', '#BA9B7C', '#569BC6', '#e08283', '#888888'];
        const chartData = new Array(data.length);
        let pie: any;
        for (let i = 0; i < data.length; i++) {
            pie = {
                label: data[i].label,
                data: data[i].value
            };

            if (colorPalette[i]) {
                pie.color = colorPalette[i];
            }

            chartData[i] = pie;
        }

        return chartData;
    }

    drawAssetStatusStatisticsData(data): void {
        this.assetStatusStatisticsHasData = (data && data.length > 0);
        if (!this.assetStatusStatisticsHasData) {
            return;
        }

        setTimeout(() => {
            const self = this;
            const normalizedData = this.normalizeAssetStatusStatisticsData(data);

            ($ as any).plot($(self.assetStatusStatisticsChart.nativeElement), normalizedData, {
                series: {
                    pie: {
                        show: true,
                        innerRadius: 0.3,
                        radius: 1,
                        label: {
                            show: true,
                            radius: 1,
                            formatter(label, series) {
                                return '<div class=\'pie-chart-label\'>' + label + ' : ' + Math.round(series.percent) + '%</div>';
                            },
                            background: {
                                opacity: 0.8
                            }
                        }
                    }
                },
                legend: {
                    show: false
                },
                grid: {
                    hoverable: true,
                    clickable: true
                }
            });
        }, 0);
    }

    /*
     * Income statistics line chart
     */


    normalizeAssetTotalNumberStatisticsData(data): Array<any> {
        const chartData = [];
        for (let i = 0; i < data.length; i++) {
            const point = new Array(2);
            point[0] = moment(data[i].date).utc().valueOf();
            point[1] = data[i].amount;
            chartData.push(point);
        }

        return chartData;
    }

    drawAssetTotalNumberStatisticsChart(data): void {
        this.assetTotalNumberStatisticsHasData = (data && data.length > 0);
        if (!this.assetTotalNumberStatisticsHasData) {
            return;
        }

        const self = this;
        const normalizedData = this.normalizeAssetTotalNumberStatisticsData(data);
        setTimeout(() => {
            ($ as any).plot($(self.assetTotalNumberStatisticsChart.nativeElement),
                [{
                    data: normalizedData,
                    lines: {
                        fill: 0.2,
                        lineWidth: 1
                    },
                    color: ['#BAD9F5']
                }, {
                    data: normalizedData,
                    points: {
                        show: true,
                        fill: true,
                        radius: 4,
                        fillColor: '#9ACAE6',
                        lineWidth: 2
                    },
                    color: '#9ACAE6',
                    shadowSize: 1
                }, {
                    data: normalizedData,
                    lines: {
                        show: true,
                        fill: false,
                        lineWidth: 3
                    },
                    color: '#9ACAE6',
                    shadowSize: 0
                }],
                {
                    xaxis: {
                        mode: 'time',
                        timeformat: this.l('ChartDateFormat'),
                        minTickSize: [5, 'day'],
                        font: {
                            lineHeight: 20,
                            style: 'normal',
                            variant: 'small-caps',
                            color: '#6F7B8A',
                            size: 10
                        }
                    },
                    yaxis: {
                        ticks: 10,
                        tickDecimals: 0,
                        tickColor: '#eee',
                        font: {
                            lineHeight: 14,
                            style: 'normal',
                            variant: 'small-caps',
                            color: '#6F7B8A'
                        }
                    },
                    grid: {
                        hoverable: true,
                        clickable: false,
                        tickColor: '#eee',
                        borderColor: '#eee',
                        borderWidth: 1,
                        margin: {
                            bottom: 20
                        }
                    }
                });
        }, 0);
    }

    assetTotalNumberStatisticsDateIntervalChange(interval: number) {
        this.selectedAssetTotalNumberStatisticsDateInterval = interval;
        this.refreshAssetTotalNumberStatisticsData();
    }

    refreshAssetTotalNumberStatisticsData(): void {
        this.loadingAssetTotalNumberStatistics = true;
        this._assetDashboardService.getAssetTotalNumberStatistics(
            this.selectedAssetTotalNumberStatisticsDateInterval,
            this.selectedDateRange.startDate,
            this.selectedDateRange.endDate)
            .subscribe(result => {
                this.drawAssetTotalNumberStatisticsChart(result);
                this.loadingAssetTotalNumberStatistics = false;
            });
    }

    bindToolTipForAssetTotalNumberStatisticsChart(assetTotalNumberStatisticsChartContainer: any): void {
        let assetTotalNumberStatisticsChartLastTooltipIndex = null;

        const removeChartTooltipIfExists = () => {
            const $chartTooltip = $('#chartTooltip');
            if ($chartTooltip.length === 0) {
                return;
            }

            $chartTooltip.remove();
        };

        const showChartTooltip = (x, y, label, value) => {
            removeChartTooltipIfExists();
            $('<div id=\'chartTooltip\' class=\'chart-tooltip\'>' + label + '<br/>' + value + '</div >')
                .css({
                    position: 'absolute',
                    display: 'none',
                    top: y - 60,
                    left: x - 40,
                    border: '0',
                    padding: '2px 6px',
                    opacity: '0.9'
                })
                .appendTo('body')
                .fadeIn(200);
        };

        assetTotalNumberStatisticsChartContainer.bind('plothover', (event, pos, item) => {
            if (!item) {
                return;
            }

            if (assetTotalNumberStatisticsChartLastTooltipIndex !== item.dataIndex) {
                let label = '';
                const isSingleDaySelected = this.selectedDateRange.startDate.format('L') === this.selectedDateRange.endDate.format('L');
                if (this.selectedAssetTotalNumberStatisticsDateInterval === AppIncomeStatisticsDateInterval.Daily ||
                    isSingleDaySelected) {
                    label = moment(item.datapoint[0]).format('dddd, DD MMMM YYYY');
                } else {
                    const isLastItem = item.dataIndex === item.series.data.length - 1;
                    label += moment(item.datapoint[0]).format('LL');
                    if (isLastItem) {
                        label += ' - ' + this.selectedDateRange.endDate.format('LL');
                    } else {
                        const nextItem = item.series.data[item.dataIndex + 1];
                        label += ' - ' + moment(nextItem[0]).format('LL');
                    }
                }

                assetTotalNumberStatisticsChartLastTooltipIndex = item.dataIndex;
                const value = this.l('IncomeWithAmount', '<strong>' + item.datapoint[1] + this.currency + '</strong>');
                showChartTooltip(item.pageX, item.pageY, label, value);
            }
        });

        assetTotalNumberStatisticsChartContainer.bind('mouseleave', () => {
            assetTotalNumberStatisticsChartLastTooltipIndex = null;
            removeChartTooltipIfExists();
        });
    }
}
