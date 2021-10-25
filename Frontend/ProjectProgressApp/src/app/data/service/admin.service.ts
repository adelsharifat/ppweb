import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IApiResponse } from './../interface/response/IApiResponse';
import { HttpClient } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  index(){
    this.http.get<IApiResponse>(environment.ADMIN_API).subscribe(x=>console.log(x.payload))
  }

}
