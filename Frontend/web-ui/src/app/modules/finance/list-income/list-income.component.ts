import { Component } from '@angular/core';
import { FinanceService } from '../finance.service';
import { ToastrService } from 'ngx-toastr';
import { FilterVm, ListIncome } from '../finance.model';

@Component({
  selector: 'app-list-income',
  templateUrl: './list-income.component.html',
  styleUrls: ['./list-income.component.css']
})
export class ListIncomeComponent {
  constructor(private _service: FinanceService, private toastr: ToastrService) { }
  pageParentLink = 'Member';
  pageTitle = 'List Income Finance';
  items: any[] = [];
  errorMessage: string = '';
  isLoading: Boolean = false;
  data: ListIncome[] = [];
  filterModel = new FilterVm();
  totalAmount: number = 0;
  SearchFormDisplay = "";

  ngOnInit(): void {
    this.loadData();
  }

  loadData(page: number = 0): void {
    this.isLoading = true;
    this.filterModel.offset = page * this.filterModel.limit;
    this._service.listIncome(this.filterModel).subscribe({
      next: (res: any) => {
        this.data = res
        this.data.forEach((item:any) => {
            this.totalAmount += item.totalAmount
        });
        this.isLoading = false
      },
      error: (error) => {
        this.toastr.error('Something went wrong');
        console.error('Error loading inventory data', error);
        this.isLoading = false
      }
    });
  }
}
