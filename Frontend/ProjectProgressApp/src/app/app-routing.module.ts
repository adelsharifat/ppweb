import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';


const routes:Routes = [
  {
    path: '',
    loadChildren: ()=> import('./pages/main/home/home.module').then(_=>_.HomeModule),
    data: { animation: 'HomePage' }
  },
  {
    path: 'login',
    loadChildren: () => import('./pages/auth/login/login.module').then(_=>_.LoginModule)
  },
  {
    path: 'manage-items',
    loadChildren: () => import('./pages/manage-items/manage-items.module').then(_=>_.ManageItemsModule),
  },
  {
    path: 'manage-items/:id',
    loadChildren: () => import('./pages/manage-item/manage-item.module').then(_=>_.ManageItemModule),
  },
  {
    path: 'add-item/:id',
    loadChildren: () => import('./pages/add-item/add-item.module').then(_=>_.AddItemModule),
  },
  {
    path: 'add-attachment/:id',
    loadChildren: () => import('./pages/add-attachment/add-attachment.module').then(_=>_.AddAttachmentModule),
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
