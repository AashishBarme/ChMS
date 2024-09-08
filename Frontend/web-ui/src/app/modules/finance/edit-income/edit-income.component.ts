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
  isButtonLoading : boolean = false;

  constructor(
    private router: Router,
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
      // this.model.income = data;
      this.model.income = data.filter((x : Income) => x.category != "Tithe")
      this.tithes = data.filter( (x: Income) => x.category == "Tithe");
      this.model.date = this.model.income[0].incomeDate;
    })
  }

  onSubmit():void{
    for(let i = 0; i< this.tithes.length; i++)
    {
      this.model.income.push(this.tithes[i])
    }
    this._service.updateIncome(this.model).subscribe({
      next: () => {
        this.toastr.success('Data Updated Successfully');
        this.router.navigate(['/finance/income']);
      },
      error: (error) => {
        this.toastr.error('Something went wrong');
        console.error('Error updating data', error);
        this.isButtonLoading = false;
      }
    });
  }
}
