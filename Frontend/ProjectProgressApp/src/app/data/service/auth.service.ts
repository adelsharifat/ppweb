import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { ILoginRequest } from '../interface/request/ILoginRequest';
import { Observable } from 'rxjs';
import { IApiResponse } from './../interface/response/IApiResponse';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }


  login(loginRequest:ILoginRequest):Observable<IApiResponse>{
    return this.http.post<IApiResponse>(environment.AUTH_API + 'login', {
      userName: loginRequest.userName,
      password:loginRequest.password,
      isRemember: loginRequest.isRemember
    }, httpOptions)
  }

  register(){

  }

  refreshToken(token: string,refreshToken:string):Observable<IApiResponse> {
    return this.http.post<IApiResponse>(environment.AUTH_API + 'refreshtoken', {
      token:token,
      refreshToken: refreshToken
    }, httpOptions);
  }


}
