import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavComponent } from './../../components/nav/nav.component';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [NavComponent],
  imports: [
    CommonModule,
    MatIconModule,
    MatToolbarModule
  ],
  exports:[NavComponent],
  providers:[]
})
export class NavModule { }
