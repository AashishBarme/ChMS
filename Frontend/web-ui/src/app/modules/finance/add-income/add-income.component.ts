import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddIncome, Income } from '../finance.model';
import { FinanceService } from '../finance.service';

@Component({
  selector: 'app-add-income',
  templateUrl: './add-income.component.html',
  styleUrls: ['./add-income.component.css']
})
export class AddIncomeComponent {
  pageParentLink = 'Inventory';
  pageTitle = 'Add Item';
  model: AddIncome = new AddIncome;
  income: Income = new Income;
  categories: string[] = ["Offering","Bonus","Interest","Personal Help","Mission","Others"];
  tithes: Income[] = [];
  isLoading: boolean = false;
  constructor(
    private _router: Router,
    private toastr: ToastrService,
    private _service: FinanceService
  ){
    for(let i = 0; i< this.categories.length; i++)
    {
      let income = new Income;
      income.category = this.categories[i];
      this.model.income.push(income);
    }
    this.addTithe();
  }

  addTithe():void
  {
    let titheIncome = new Income;
    titheIncome.category = "Tithe"
    this.tithes.push(titheIncome);
    console.log(this.tithes);
  }

  removeTithe(index:number):void
  {
    if(index > 0){
      this.tithes.splice(index, 1)
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
    this.isLoading = true;

    this._service.createIncome(this.model).subscribe({
      next: (data) => {
        this.toastr.success('Income Added Successfully');
        this._router.navigate(['/finance/income']);
      },
      error: (err) => {
        this.toastr.error('Something went wrong');
        console.error('Error creating member', err);
        this.isLoading = false;
      }
    });
  }
}
