import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddIncome, Income } from '../finance.model';
import { FinanceService } from '../finance.service';
@Component({
  selector: 'app-edit-income',
  templateUrl: './edit-income.component.html',
  styleUrls: ['./edit-income.component.css']
})
export class EditIncomeComponent {
  pageParentLink = 'Inventory';
  pageTitle = 'Add Item';
  model: AddIncome = new AddIncome;
  income: Income = new Income;
  categories: string[] = ["Offering","Bonus","Interest","Personal Help","Mission","Others"];
  tithes: Income[] = [];

  constructor(
    private _router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute,
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
    const date = this.route.snapshot.paramMap.get('id');
    console.log(date);
    this._service.getIncome(date).subscribe((data: any) => {
      console.log(data);
    })
    // window.location.reload();
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
