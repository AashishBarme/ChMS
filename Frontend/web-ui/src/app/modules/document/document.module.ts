import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { FilterComponent } from './list/filter/filter.component';



@NgModule({
  declarations: [
    ListComponent,
    AddComponent,
    EditComponent,
    FilterComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DocumentModule { }
