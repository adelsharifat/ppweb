import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './../../../data/service/auth.service';
import { TokenService } from './../../../data/service/token.service';
import { ToolbarService } from './../../../data/service/toolbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  errorMessage = '';
  isLoginFaild = false;

  loginForm = new FormGroup({
    userName: new FormControl('admin'),
    password: new FormControl('admin'),
    isRemember: new FormControl(true)
  });


  constructor(private authService:AuthService,
    private tokenService:TokenService,
    private toolbarService:ToolbarService,
    private router:Router) {}

  ngOnInit(): void {
  }




  onSubmit(): void {
    this.authService.login(this.loginForm.value).subscribe(
      data => {
        this.tokenService.saveToken(data.payload.token);
        this.tokenService.saveRefreshToken(data.payload.refreshToken);
        this.toolbarService.sidebarState.next(false);
        this.router.navigate([''])

      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFaild = true;
      }
    );
  }






}
