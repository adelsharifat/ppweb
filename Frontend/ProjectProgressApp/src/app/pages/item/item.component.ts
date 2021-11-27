import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as FileSaver from 'file-saver';
import { BehaviorSubject, Observable } from 'rxjs';
import { AttachmentService } from 'src/app/data/service/attachment.service';
import { AuthService } from 'src/app/data/service/auth.service';
import { ItemService } from 'src/app/data/service/item.service';
import { IDownloadAttachmentRequest } from './../../data/interface/request/IDownloadAttachmentRequest';
import { DownloadService } from './../../data/service/download.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  bodyPreloading =false;
  attachmentData = new BehaviorSubject<any>(null);
  item:BehaviorSubject<any> = new BehaviorSubject<any>(null)
  itemId:string|null = null;
  itemData:any = [];
  fileStream:string|Uint8Array='';
  fileContent:string|undefined = '';
  loading = false;

  constructor(private itemService:ItemService,
    private downloadService:DownloadService,
    private authService:AuthService,
    private attachmentService:AttachmentService,
    private fb:FormBuilder,
    private route:ActivatedRoute,
    private router:Router) {
      this.itemId = this.route.snapshot.paramMap.get('id')
     }


  // download(streamId:any){
  //   this.downloadService.downloadFile(streamId);
  // }

  download(streamId:any){
    this.handleFileApi(streamId).add(()=>{
      this.downloadService.fileStream.next(<string>this.fileStream);
      this.router.navigate(['../../viewer']);
    });
  }


  handleFileApi(streamId: string) {
     return this.attachmentService
      .downloadAttachment(streamId).subscribe(res=>
        {console.log(res);
          // const byteCharacters = atob(res.payload.fileStream);
          // const byteNumbers = new Array(byteCharacters.length);
          // for (let i = 0; i < byteCharacters.length; i++)
          //   byteNumbers[i] = byteCharacters.charCodeAt(i);
          // const byteArray = new Uint8Array(byteNumbers);
        //this.fileContent = URL.createObjectURL(new Blob([byteArray], { type:'application/pdf;base64'}))
        this.fileStream = res.payload.fileStream
        },err=>console.log(err));
  }


  findAllAttachmentByObjectId(objectId:string | null){
    this.bodyPreloading = true;
    this.attachmentService.findAttachmentByObjectId(objectId).subscribe(
      res=>{
        this.attachmentData.next(res.payload);
        this.bodyPreloading = false;
      },
      err=>{
        console.log(err);
      }
    )
  }



  ngOnInit(): void {
    this.item.next(null);
    this.itemData = [];
    this.itemService.getItemById(this.itemId).subscribe(
      res=>{
        this.item.next(res.payload);
      },
      err=>{
        console.log(err)
      }
    ).add(()=>{
      this.itemData = this.item.value;
      this.findAllAttachmentByObjectId(this.itemId)
    })

  }


}
