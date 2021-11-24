import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavComponent } from './../../components/nav/nav.component';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [NavComponent],
  imports: [
    CommonModule,
    MatIconModule,
    MatToolbarModule,
    RouterModule
  ],
  exports:[NavComponent],
  providers:[]
})
export class NavModule { }
