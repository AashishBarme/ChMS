import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MemberRoutingModule } from './member-routing.module';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';


@NgModule({
  declarations: [
    AddComponent,
    EditComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    MemberRoutingModule
  ]
})
export class MemberModule { }
