import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MemberRoutingModule } from './member-routing.module';
import { AddMemberComponent } from './add/add.component';
import { EditMemberComponent } from './edit/edit.component';
import { ListMemberComponent } from './list/list.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AddMemberComponent,
    EditMemberComponent,
    ListMemberComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MemberRoutingModule
  ]
})
export class MemberModule { }
