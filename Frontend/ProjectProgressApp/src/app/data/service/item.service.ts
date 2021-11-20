import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IApiResponse } from './../interface/response/IApiResponse';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';



@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http:HttpClient) { }


  getItems(){
    return this.http.get<IApiResponse>(environment.ITEM_API+'getItems');
  }

  getItemById(itemId:string|null):Observable<IApiResponse>
  {
    return this.http.get<IApiResponse>(environment.ITEM_API+'getitembyid/'+itemId)
  }

}
