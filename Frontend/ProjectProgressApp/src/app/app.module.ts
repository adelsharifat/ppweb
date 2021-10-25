import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthService } from './data/service/auth.service';
import { TokenService } from './data/service/token.service';
import { HttpClientModule } from '@angular/common/http';
import { AuthInterceptorProviders } from './middleware/auth/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [AuthService,TokenService,AuthInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
