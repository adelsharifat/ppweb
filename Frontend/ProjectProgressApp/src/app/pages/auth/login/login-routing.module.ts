import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';


const routes:Routes = [
  {
    path: '',
    component:LoginComponent,
    pathMatch:'full'
  },

]



@NgModule({
  declarations: [],
  imports: [
  RouterModule.forChild(routes),
    CommonModule
  ],
  exports:[RouterModule]
})
export class LoginRoutingModule { }
