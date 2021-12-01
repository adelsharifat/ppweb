import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { AuthGuard } from 'src/app/middleware/auth/auth.guard';
import { ManageItemComponent } from './manage-item.component';


const routes:Routes = [
  {
    path: '',
    pathMatch: 'full',
    component:ManageItemComponent,
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
export class ManageItemRoutingModule { }
