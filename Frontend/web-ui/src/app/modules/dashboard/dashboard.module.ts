import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { LayoutModule } from '../layout/layout.module';
import { DashboardRoutingModule } from './dashboard-routing.module';



@NgModule({
  declarations: [
    IndexComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    LayoutModule
  ]
})
export class DashboardModule { }
