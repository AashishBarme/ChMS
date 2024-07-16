import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from 'src/app/components/shared/header/header.component';
import { FooterComponent } from 'src/app/components/shared/footer/footer.component';
import { BreadcrumbComponent } from 'src/app/components/shared/breadcrumb/breadcrumb.component';
import { SidebarComponent } from 'src/app/components/shared/sidebar/sidebar.component';
import { LoaderComponent } from 'src/app/components/shared/loader/loader.component';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    BreadcrumbComponent,
    SidebarComponent,
    LoaderComponent
  ],
  exports:[
    HeaderComponent,
    FooterComponent,
    BreadcrumbComponent,
    SidebarComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class LayoutModule { }
