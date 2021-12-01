import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { AuthGuard } from 'src/app/middleware/auth/auth.guard';
import { AddItemComponent } from './add-item.component';


const routes:Routes = [
  {
    path: '',
    pathMatch: 'full',
    component:AddItemComponent,
    canActivate:[AuthGuard],
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
export class AddItemRoutingModule { }
