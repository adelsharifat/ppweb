import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from './../../../data/service/auth.service';
import { TokenService } from './../../../data/service/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  errorMessage = '';
  isLoginFaild = false;

  loginForm = new FormGroup({
    userName: new FormControl('admin'),
    password: new FormControl('admin'),
    isRemember: new FormControl(true)
  });


  constructor(private authService:AuthService,private tokenService:TokenService) {}

  ngOnInit(): void {
  }




  onSubmit(): void {
    const { username, password,isRemember } = this.loginForm.value;
    this.authService.login(this.loginForm.value).subscribe(
      data => {
        this.tokenService.saveToken(data.payload.token);
        this.tokenService.saveRefreshToken(data.payload.refreshToken);
        this.tokenService.saveUser(data);
      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFaild = true;
      }
    );
  }






}
