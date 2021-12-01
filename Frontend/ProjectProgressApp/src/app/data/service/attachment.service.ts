import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../../environments/environment';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root'
})
export class AttachmentService {

  constructor(private http:HttpClient) { }


  findAttachmentByObjectId(objectId:string|null){
    return this.http.get<any>(environment.ATTACHMENT_API + 'FindAll/'+objectId);
  }


  downloadAttachment(streamId:string):Observable<any>
  {
    return this.http.get<any>(environment.ATTACHMENT_API + 'downloadattachment/'+streamId,httpOptions)
  }


  saveAttachments(formData:any):Observable<any>{
    return this.http.post<any>(environment.ATTACHMENT_API + 'SaveAttachments',formData, {
      reportProgress: true,
      observe: 'events'
    })
  }

}
