import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { HomeComponent } from './homecomponent';
import { AuthGuard } from 'src/app/middleware/auth/auth.guard';
import { HomeItemsComponent } from './home-items/home-items.component';
import { FindComponentsComponent } from './find-components/find-components.component';
import { HomeItemComponent } from './home-item/home-item.component';


const routes:Routes = [
  {
    path: '',
    pathMatch: 'full',
    component:HomeComponent,
    canActivate:[AuthGuard],

    children:[
      {
        path: '',
        pathMatch:'full',
        component:HomeItemsComponent,
      },
    ]
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
