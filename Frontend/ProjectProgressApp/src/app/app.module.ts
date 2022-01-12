import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthService } from './data/service/auth.service';
import { TokenService } from './data/service/token.service';
import { HttpClientModule } from '@angular/common/http';
import { AuthInterceptorProviders } from './middleware/auth/auth.interceptor';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AuthGuard } from './middleware/auth/auth.guard';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(
      {
        positionClass: 'toast-bottom-center',
      }
    ),
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production
    }),

  ],
  providers: [{ provide: JWT_OPTIONS, useValue: JWT_OPTIONS },JwtHelperService,AuthGuard,AuthService,TokenService,AuthInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
