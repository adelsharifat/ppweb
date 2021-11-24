import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrivacyComponent } from './privacy.component';
import { PrivacyRoutingModule } from './privacy-routing.module';

@NgModule({
  declarations: [PrivacyComponent],
  imports: [
    PrivacyRoutingModule,
    CommonModule,
  ],
  providers:[]
})
export class PrivacyModule { }
