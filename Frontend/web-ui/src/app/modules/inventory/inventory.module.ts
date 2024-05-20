import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventoryRoutingModule } from './inventory-routing.module';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { ListComponent } from './list/list.component';
import { LayoutModule } from '../layout/layout.module';


@NgModule({
  declarations: [
    AddComponent,
    EditComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    InventoryRoutingModule,
    LayoutModule
  ]
})
export class InventoryModule { }
