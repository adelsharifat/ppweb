import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutingModule } from './home-routing.module';
import { HomeComponent } from './homecomponent';
import { ToolbarComponent } from './../../../components/toolbar/toolbar.component';
import { SidebarComponent } from './../../../components/sidebar/sidebar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { AvatarModule } from 'ngx-avatar';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [HomeComponent,ToolbarComponent,SidebarComponent],
  imports: [
  CommonModule,
    MainRoutingModule,
    MatToolbarModule,
    MatIconModule,
    AvatarModule,
    MatButtonModule
  ],
})
export class HomeModule { }
