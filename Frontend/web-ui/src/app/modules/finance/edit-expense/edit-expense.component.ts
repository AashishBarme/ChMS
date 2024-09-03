import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddIncome, Income } from '../finance.model';
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
    private toastr: ToastrService
  ){
    for(let i = 0; i< this.categories.length; i++)
    {
      let income = new Income;
      income.category = this.categories[i];
      this.model.income.push(income);
    }
  }



  ngOnInit(): void {
    // this.incomeForm = this.fb.group
  }

  onSubmit():void{
    for(let i = 0; i< this.tithes.length; i++)
    {
      this.model.income.push(this.tithes[i])
    }
    console.log(this.model);
  }
}
