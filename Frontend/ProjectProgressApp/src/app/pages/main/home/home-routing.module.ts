import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './homecomponent';


const routes:Routes = [
  {
    path: '',
    pathMatch: 'full',
    component:HomeComponent
  }
]



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports:[RouterModule]
})
export class MainRoutingModule { }
