import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users.component';
import { AuthGuard } from 'src/app/middleware/auth/auth.guard';


const routes:Routes = [
  {
    path: '',
    pathMatch: 'full',
    component:UsersComponent,
    canActivate:[AuthGuard]
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports:[RouterModule],
  providers:[]
})
export class UsersRoutingModule { }
