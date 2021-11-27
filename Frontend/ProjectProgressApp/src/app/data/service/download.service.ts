import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import {AttachmentService} from './attachment.service'
import { map } from 'rxjs/operators';
import { saveAs } from 'file-saver';

@Injectable({
  providedIn: 'root'
})
export class DownloadService {

  constructor(private attachmentService:AttachmentService) { }

  fileStream:BehaviorSubject<string|Uint8Array>  = new BehaviorSubject<string|Uint8Array>('');



  downloadFile(streamId:string) {
    const path = streamId;
    if(path!==null)
    {
       this.handleFileApi(streamId).subscribe(
        (success:any) => {
          console.log(success)
          this.HandleBase64(
            success.fileStream,
            'application/octet-stream',
            success.fileName,success.extention
          );
        },
        (err) => {
          alert('Server error while downloading file.' + err);
        }
      );
    }
  }

  handleFileApi(streamId: string): Observable<any> {
    return this.attachmentService
      .downloadAttachment(streamId)
      .pipe(map((res) => res.payload));
  }

  HandleBase64(data:any, contentType:string, fileName:string,extention:string) {
    const byteCharacters = atob(data);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++)
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: contentType });

    switch (extention) {
      case '.pdf':
        window.open(URL.createObjectURL(new Blob([byteArray], { type:'application/pdf;base64'})));
        break;

      case '.jpg':
        window.open(URL.createObjectURL(new Blob([byteArray], { type:'image/jpg;base64'})));
      break;

      case '.png':
        window.open(URL.createObjectURL(new Blob([byteArray], { type:'image/jpg;base64'})));
      break;

      case '.bmp':
        window.open(URL.createObjectURL(new Blob([byteArray], { type:'image/bmp;base64'})));
      break;
      default:
        saveAs(blob, fileName);
        break;
    }

  }

}
