import { Component } from '@angular/core';

@Component({
  selector: 'expense-edit-modal',
  templateUrl: './edit-modal.component.html',
  styleUrls: ['./edit-modal.component.css']
})
export class ExpenseEditModalComponent {
  editDate : any = "";
  validateEditLink(editDate : string)
  {
    if(editDate == "")
    {
      alert("Edit Date is not selected");
      return false;
    }

    window.location.href = `/finance/expense/edit/${editDate}`;
    return true;
  }

}
