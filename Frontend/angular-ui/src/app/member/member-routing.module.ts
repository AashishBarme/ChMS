import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListMemberComponent } from './list/list.component';
import { AddMemberComponent } from './add/add.component';
import { EditMemberComponent } from './edit/edit.component';

const routes: Routes = [  {
  path:"member",
  "children":[
    {path:"list", component:ListMemberComponent},
    {path:"add", component:AddMemberComponent},
    {path:"edit/:id", component:EditMemberComponent},
  ]
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
