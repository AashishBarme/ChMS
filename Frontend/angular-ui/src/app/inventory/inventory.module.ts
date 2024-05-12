import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InventoryRoutingModule } from './inventory-routing.module';
import { AddInventoryComponent } from './add/add.component';
import { EditInventoryComponent } from './edit/edit.component';
import { ListInventoryComponent } from './list/list.component';


@NgModule({
  declarations: [
    AddInventoryComponent,
    EditInventoryComponent,
    ListInventoryComponent
  ],
  imports: [
    CommonModule,
    InventoryRoutingModule
  ]
})
export class InventoryModule { }
