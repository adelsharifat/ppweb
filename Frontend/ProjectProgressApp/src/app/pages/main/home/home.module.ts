import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutingModule } from './home-routing.module';
import { HomeComponent } from './homecomponent';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    MainRoutingModule
  ],
})
export class HomeModule { }
