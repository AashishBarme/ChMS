import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { SidebarComponent } from './components/shared/sidebar/sidebar.component';
import { AuthModule } from './modules/auth/auth.module';
import { InventoryModule } from './modules/inventory/inventory.module';
import { MemberModule } from './modules/member/member.module';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    InventoryModule,
    MemberModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
