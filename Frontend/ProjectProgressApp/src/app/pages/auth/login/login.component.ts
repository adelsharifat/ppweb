import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../../../data/service/auth.service';
import { TokenService } from './../../../data/service/token.service';
import { ToolbarService } from './../../../data/service/toolbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  loading = false;

  errorMessage = '';
  isLoginFaild = false;

  loginForm = this.fb.group({
    userName: ['',Validators.required],
    password: ['',Validators.required],
    isRemember: [false]
  });


  constructor(private authService:AuthService,
    private fb:FormBuilder,
    private tokenService:TokenService,
    private toolbarService:ToolbarService,
    private tostrService:ToastrService,
    private router:Router) {

    }

  ngOnInit(): void {
    // if(this.tokenService.isLoggedIn()===true) this.router.navigate([''])
    // return;
  }

  onSubmit(): void {
    this.loading = true;
    this.authService.login(this.loginForm.value).subscribe(
      data => {

        this.tokenService.saveToken(data.payload.token);
        this.tokenService.saveRefreshToken(data.payload.refreshToken);
        this.toolbarService.sidebarState.next(false);
        this.loginForm.reset();
        this.router.navigate([''])
      },
      err => {
        this.isLoginFaild = true;
        this.tostrService.error(err.error.error)
      }
    ).add(()=>{
      this.loading = false;
    });
  }






}
