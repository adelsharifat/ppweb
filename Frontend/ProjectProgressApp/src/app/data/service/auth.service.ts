import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { ILoginRequest } from '../interface/request/ILoginRequest';
import { BehaviorSubject, Observable, ObservableInput, of } from 'rxjs';
import { IApiResponse } from './../interface/response/IApiResponse';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { IRegisterRequest } from '../interface/request/IRegisterRequest';
import { IUser } from '../interface/model/User';
import { TokenService } from './token.service';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient,private tokenService:TokenService,private jwtHelper:JwtHelperService,private router:Router) {

  }


  isAdmin():String{
    return this.jwtHelper.decodeToken(this.tokenService.getToken()?.toString()).IsAdmin;
  }

  userId(){
    return <number>this.jwtHelper.decodeToken(this.tokenService.getToken()?.toString()).Id;
  }


  fullName(){
    return <number>this.jwtHelper.decodeToken(this.tokenService.getToken()?.toString()).FullName;
  }

  seenDesktopMode():String{
    return <String>this.jwtHelper.decodeToken(this.tokenService.getToken()?.toString()).SeenDesktopMode;
  }




  public isAuthenticated(): boolean {
    const token = window.localStorage.getItem('token');
    if(token)
    {
      console.log(!this.jwtHelper.isTokenExpired(token))
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }


  login(loginRequest:ILoginRequest):Observable<IApiResponse>{
    return this.http.post<IApiResponse>(environment.AUTH_API + 'login', {
      userName: loginRequest.userName,
      password:loginRequest.password,
      isRemember: loginRequest.isRemember
    }, httpOptions)
  }

  register(registerRequest:IRegisterRequest):Observable<IApiResponse>{
    return this.http.post<IApiResponse>(environment.AUTH_API + 'register', {
      userName: registerRequest.userName,
      password:registerRequest.password,
      firstName: registerRequest.firstName,
      lastName:registerRequest.lastName,
      isAdmin:registerRequest.isAdmin
    }, httpOptions)

  }


  logout(){
    window.sessionStorage.clear()
    this.router.navigate(['/login'])
  }

  refreshToken(token: string | undefined |null,refreshToken:string |undefined| null):Observable<IApiResponse> {
    return this.http.post<IApiResponse>(environment.AUTH_API + 'refreshtoken', {
      token:token,
      refreshToken: refreshToken
    }, httpOptions);
  }


}
