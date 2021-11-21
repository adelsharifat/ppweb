import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IApiResponse } from './../interface/response/IApiResponse';
import { environment } from './../../../environments/environment';
import { IAttachmentRequest } from './../interface/request/IAttachmentRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttachmentService {

  constructor(private http:HttpClient) { }


  findAttachmentByObjectId(objectId:string|null){
    return this.http.get<any>(environment.ATTACHMENT_API + 'FindAll/'+objectId);
  }


  saveAttachments(formData:any):Observable<any>{
    return this.http.post<any>(environment.ATTACHMENT_API + 'SaveAttachments',formData, {
      reportProgress: true,
      observe: 'events'
    })
  }

}
