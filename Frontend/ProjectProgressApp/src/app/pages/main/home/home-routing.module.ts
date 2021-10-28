import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { HomeComponent } from './homecomponent';
import { AuthGuard } from 'src/app/middleware/auth/auth.guard';


const routes:Routes = [
  {
    path: '',
    pathMatch: 'full',
    component:HomeComponent,
    //canActivate:[AuthGuard],
  }
]



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports:[RouterModule],
  providers:[AuthGuard]
})
export class MainRoutingModule { }
