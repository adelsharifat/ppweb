import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IApiResponse } from './../interface/response/IApiResponse';
import { Observable } from 'rxjs';
import { environment } from './../../../environments/environment';
import { IItemAddRequest } from './../interface/request/IItemAddRequest';



@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http:HttpClient) { }

  getAllItems(){
    return this.http.get<IApiResponse>(environment.ITEM_API+'getAllItems');
  }


  getItems(){
    return this.http.get<IApiResponse>(environment.ITEM_API+'getItems');
  }


  getManagementItems(){
    return this.http.get<IApiResponse>(environment.ITEM_API+'getManagementItems');
  }

  getItemById(itemId:string|null):Observable<IApiResponse>
  {
    return this.http.get<IApiResponse>(environment.ITEM_API+'getitembyid/'+itemId)
  }

  addItem(itemAddRequest:IItemAddRequest){
    return this.http.post<IApiResponse>(environment.ITEM_API+'additem',itemAddRequest)
  }

  deleteItem(itemId:string|null){
    return this.http.get<IApiResponse>(environment.ITEM_API+'deleteitem/'+itemId)
  }

}
