import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users.component';
import { UsersRoutingModule } from './users-routing.module';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { NavModule } from 'src/app/components/nav/nav.module';

@NgModule({
  declarations: [UsersComponent],
  imports: [
    UsersRoutingModule,
    CommonModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    FormsModule,
    NavModule
  ],
  providers:[]
})
export class UsersModule { }
