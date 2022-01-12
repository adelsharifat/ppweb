import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginRoutingModule } from './login-routing.module';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [


  CommonModule,
    FormsModule,
    MatIconModule,
    ReactiveFormsModule,
    LoginRoutingModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,

  ]
})
export class LoginModule { }
