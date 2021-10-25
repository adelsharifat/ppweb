import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';


const routes:Routes = [
  {
    path: '',
    loadChildren: ()=> import('./pages/main/home/home.module').then(_=>_.HomeModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./pages/auth/login/login.module').then(_=>_.LoginModule)
  },


]



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
