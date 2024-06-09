import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './modules/auth/auth.module';
import { InventoryModule } from './modules/inventory/inventory.module';
import { MemberModule } from './modules/member/member.module';
import { LayoutModule } from './modules/layout/layout.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { AppConfigInitService } from './appconfig.init';


export function init_app(appLoadService: AppConfigInitService) {
  return () => appLoadService.init();
}
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    InventoryModule,
    MemberModule,
    LayoutModule,
    DashboardModule
  ],
  providers: [
    // AppConfigInitService,
    // {
    //   provide: APP_INITIALIZER,
    //   useFactory: init_app,
    //   deps: [AppConfigInitService],
    //   multi: true
    // },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
