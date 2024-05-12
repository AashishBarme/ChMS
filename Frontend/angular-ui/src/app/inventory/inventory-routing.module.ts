import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListInventoryComponent } from './list/list.component';
import { AddInventoryComponent } from './add/add.component';
import { EditInventoryComponent } from './edit/edit.component';

const routes: Routes = [{
  path:"inventory",
  "children": [
    {path:"list", component:ListInventoryComponent},
    {path:"add", component:AddInventoryComponent},
    {path:"edit/:id", component:EditInventoryComponent},
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule { }
