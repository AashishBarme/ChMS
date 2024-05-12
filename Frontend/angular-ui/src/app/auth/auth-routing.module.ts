import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { VerifyEmailComponent } from './verify-email/verify-email.component';
import { CreatePasswordComponent } from './create-password/create-password.component';


const routes: Routes = [
  {"path":"login",component:LoginComponent},
  {"path":"reset-password", component: ResetPasswordComponent},
  {"path":"verify-email", component: VerifyEmailComponent },
  { "path" : "create-password", component: CreatePasswordComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
