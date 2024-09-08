import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddIncome, Income } from '../finance.model';
import { FinanceService } from '../finance.service';
@Component({
  selector: 'app-edit-expense',
  templateUrl: './edit-expense.component.html',
  styleUrls: ['./edit-expense.component.css']
})
export class EditExpenseComponent {
  pageParentLink = 'Inventory';
  pageTitle = 'Add Item';
  model: AddIncome = new AddIncome;
  income: Income = new Income;
  categories: string[] = ["Offering","Bonus","Interest","Personal Help","Mission","Others"];
  tithes: Income[] = [];

  constructor(
    private _router: Router,
    private toastr: ToastrService,
    private _service: FinanceService,
    private route: ActivatedRoute
  ){
    for(let i = 0; i< this.categories.length; i++)
    {
      let income = new Income;
      income.category = this.categories[i];
      this.model.income.push(income);
    }
  }
  ngOnInit(): void {
    const date = this.route.snapshot.paramMap.get('id');
    this._service.getIncome(date).subscribe((data: any) => {
      // this.model.income = data;
      this.model.income = data.filter((x : Income) => x.category != "Tithe")
      this.tithes = data.filter( (x: Income) => x.category == "Tithe");
      this.model.date = this.model.income[0].incomeDate;
    })
  }

  onSubmit():void{
    for(let i = 0; i< this.tithes.length; i++)
    {
      if(this.tithes[i].amount > 0)
      {
        this.model.income.push(this.tithes[i])
      }
    }
    this._service.updateIncome(this.model).subscribe({
      next: () => {
        this.toastr.success('Data Updated Successfully');
        this._router.navigate(['/finance/expense']);
      },
      error: (error) => {
        this.toastr.error('Something went wrong');
        console.error('Error updating data', error);
        // this.isButtonLoading = false;
      }
    });
  }


}
