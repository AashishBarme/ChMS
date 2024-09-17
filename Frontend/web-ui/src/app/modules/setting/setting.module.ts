import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingRoutingModule } from './setting-routing.module';
import { PageSettingComponent } from './page-setting/page-setting.component';
import { AccountComponent } from './page-setting/account/account.component';
import { PasswordComponent } from './page-setting/password/password.component';


@NgModule({
  declarations: [
    PageSettingComponent,
    AccountComponent,
    PasswordComponent
  ],
  imports: [
    CommonModule,
    SettingRoutingModule
  ]
})
export class SettingModule { }