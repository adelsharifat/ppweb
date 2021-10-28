import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { ILoginRequest } from '../interface/request/ILoginRequest';
import { Observable } from 'rxjs';
import { IApiResponse } from './../interface/response/IApiResponse';
import { JwtHelperService } from '@auth0/angular-jwt';
import { windowWhen } from 'rxjs/operators';
import { Router } from '@angular/router';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient,private jwtHelper:JwtHelperService,private router:Router) { }


  public isAuthenticated(): boolean {
    const token = window.sessionStorage.getItem('token');
    if(token)
    {
      console.log(this.jwtHelper.isTokenExpired(token))
      return !this.jwtHelper.isTokenExpired(token);
    }
    console.log('+++')
    return false;
  }


  login(loginRequest:ILoginRequest):Observable<IApiResponse>{
    return this.http.post<IApiResponse>(environment.AUTH_API + 'login', {
      userName: loginRequest.userName,
      password:loginRequest.password,
      isRemember: loginRequest.isRemember
    }, httpOptions)
  }

  register(){

  }


  logout(){
    window.sessionStorage.clear();
    this.router.navigate(['login']);
  }

  refreshToken(token: string | undefined |null,refreshToken:string |undefined| null):Observable<IApiResponse> {
    return this.http.post<IApiResponse>(environment.AUTH_API + 'refreshtoken', {
      token:token,
      refreshToken: refreshToken
    }, httpOptions);
  }


}
