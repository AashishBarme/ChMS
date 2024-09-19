import { Component, OnInit } from '@angular/core';
import { ChartConfiguration, ChartOptions } from 'chart.js';
import { DashboardService } from '../dashboard.service';
import { SummaryData } from '../dashboard.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  isLoading: boolean = false;
  summaryData =  new SummaryData();

  constructor(
    private _service: DashboardService,
  ) { }

  ngOnInit(): void {
    this.loadSummaryData();
  }



  loadSummaryData(): void {
    this.isLoading = true;
      this._service.getSummaryData().subscribe({
        next: (data: SummaryData) => {
          this.summaryData.totalExpense = data.totalExpense;
          this.summaryData.totalIncome = data.totalIncome;
          this.summaryData.totalItems = data.totalItems;
          this.summaryData.totalMembers = data.totalMembers;
          this.isLoading = false;
        },
        error: (error) => {
          console.error('Error loading inventory data', error);
          this.isLoading = false;
        }
      });
  }

}
