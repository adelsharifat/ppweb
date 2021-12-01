import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './../../data/service/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(public authService: AuthService, public router: Router) {}
  canActivate(): boolean {
    console.log(this.authService.isAuthenticated())
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
