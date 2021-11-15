import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IApiResponse } from './../interface/response/IApiResponse';
import { environment } from './../../../environments/environment';
import { IAttachmentRequest } from './../interface/request/IAttachmentRequest';
import { Observable } from 'rxjs';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};





@Injectable({
  providedIn: 'root'
})
export class AttachmentService {

  constructor(private http:HttpClient) { }

  saveAttachments(attachmentRequest:IAttachmentRequest[]):Observable<IApiResponse>{
    return this.http.post<IApiResponse>(environment.ATTACHMENT_API + 'saveattachments', attachmentRequest, httpOptions)
  }

}
