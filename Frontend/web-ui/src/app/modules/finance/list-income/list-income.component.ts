import { Component } from '@angular/core';
import { FinanceService } from '../finance.service';
import { ToastrService } from 'ngx-toastr';
import { FilterVm, ListIncome } from '../finance.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-income',
  templateUrl: './list-income.component.html',
  styleUrls: ['./list-income.component.css']
})
export class ListIncomeComponent {
  constructor(private _service: FinanceService, private toastr: ToastrService, private _router: Router) { }
  pageParentLink = 'Member';
  pageTitle = 'List Income Finance';
  items: any[] = [];
  errorMessage: string = '';
  isLoading: Boolean = false;
  data: ListIncome[] = [];
  filterModel = new FilterVm();
  totalAmount: number = 0;
  SearchFormDisplay = "";
  editDate : any = "";

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

  validateEditLink(editDate : string)
  {
    if(editDate == "")
    {
      alert("Edit Date is not selected");
      return false;
    }

    window.location.href = `/finance/income/edit/${editDate}`;
    return true;
  }
}
