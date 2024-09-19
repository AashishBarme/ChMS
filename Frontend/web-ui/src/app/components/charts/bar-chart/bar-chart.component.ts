import { Component, Input } from '@angular/core';
import { ChartConfiguration } from 'chart.js';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent {
  public barChartLegend = true;
  public barChartPlugins = [];
  @Input() xValue : number[] = [];
  @Input() yValue: string[] = [];
  @Input() label: string = "";


  // dataSet : any[] = [];
  // for(i = 0; i > this.xValue.length; i++)
  // {
  //   this.dataSet.push({
  //     data: []
  //   })
  // }

  transformedArray = this.xValue.map((item,index) => ({
    data: [item],
    label: this.yValue[index]
  }));





  public barChartData: ChartConfiguration<'bar'>['data'] = {
    labels: [ this.label],
    datasets: [


      { data: [ 65 ], label: 'Series A' },
      { data: [ 28 ], label: 'Series B' }
    ]
  };

  public barChartOptions: ChartConfiguration<'bar'>['options'] = {
    responsive: false,
  };
}
