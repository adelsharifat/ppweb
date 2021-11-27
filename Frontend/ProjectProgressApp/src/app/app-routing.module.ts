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
    path: 'users',
    loadChildren: () => import('./pages/users/users.module').then(_=>_.UsersModule)
  },
  {
    path: 'privacy',
    loadChildren: () => import('./pages/privacy/privacy.module').then(_=>_.PrivacyModule)
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
  {
    path: 'item/:id',
    loadChildren: () => import('./pages/item/item.module').then(_=>_.ItemModule),
  },
  {
    path: 'viewer',
    loadChildren: () => import('./pages/viewer/viewer.module').then(_=>_.ViewerModule),
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
