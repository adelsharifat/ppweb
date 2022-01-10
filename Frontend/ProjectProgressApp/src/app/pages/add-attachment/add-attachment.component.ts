import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AttachmentService } from './../../data/service/attachment.service';
import { AuthService } from './../../data/service/auth.service';
import { BehaviorSubject, throwError } from 'rxjs';
import { ItemService } from './../../data/service/item.service';
import { IAttachment, IAttachmentRequest } from 'src/app/data/interface/request/IAttachmentRequest';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpEventType, HttpResponse, HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import {ThemePalette} from '@angular/material/core';
import {ProgressBarMode} from '@angular/material/progress-bar';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { LEADING_TRIVIA_CHARS } from '@angular/compiler/src/render3/view/template';
import { computeMsgId } from '@angular/compiler';
import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-attachment',
  templateUrl: './add-attachment.component.html',
  styleUrls: ['./add-attachment.component.scss']
})
export class AddAttachmentComponent implements OnInit {
  progress:number = 0;

  color: ThemePalette = 'primary';
  mode: ProgressBarMode = 'determinate';
  value = 50;
  bufferValue = 75;

  loading = false;
  itemId:string|null = null;
  item:BehaviorSubject<any> = new BehaviorSubject<any>(null)
  itemData:any = [];
  file:string|Blob|any='';


  attachmentData = new BehaviorSubject<any>(null);

  constructor(private itemService:ItemService,
    private authService:AuthService,
    private attchmentService:AttachmentService,
    private fb:FormBuilder,
    private tostrService:ToastrService,
    private route:ActivatedRoute,
    private router:Router) {


      this.itemId = this.route.snapshot.paramMap.get('id')
     }


  fg = this.fb.group({
    file:[null,Validators.required],
    attachmentDateInput:[null,Validators.required],
    fileAddressInput:[null],
    remark:[null]
  });

  uploadPreloading =false;
  bodyPreloading =false;

  reset(){
    this.fg.reset();
    this.progress = 0;
  }

  onChangeFileInput(event:any)
  {
    let fileFullName:string = event.target.files[0].name;
    let fileName = fileFullName.replace(/\.[^/.]+$/, "")
    this.fg.controls['fileAddressInput'].setValue(fileFullName)
    this.fg.controls['remark'].setValue(fileName)
    this.file = event.target.files[0]
    if(this.file.type !== 'application/pdf') {
      this.file = null;
      this.fg.reset()
    }
  }


  findAllAttachmentByObjectId(objectId:string | null){
    this.bodyPreloading = true;
    this.attchmentService.findAttachmentByObjectId(objectId).subscribe(
      res=>{
        this.attachmentData.next(res.payload);
        this.bodyPreloading = false;
      },
      err=>this.tostrService.error(err)
    )
  }

  upload()
  {
    this.uploadPreloading = true;
    const objectId:any = this.itemId?.toString();
    var formData = new FormData();
    formData.append('createdBy',this.authService.userId().toString());
    formData.append('itemId', objectId);
    formData.append('fileName',this.file.name);
    formData.append('file',this.file);
    formData.append('attachmentDate',this.fg.value.attachmentDateInput);
    formData.append('remark',this.fg.value.remark);
    console.log(this.fg.value.attachmentDateInput)
    this.attchmentService.saveAttachments(formData)
    .subscribe( (event) => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else if (event instanceof HttpResponse) {
        this.progress = 0;
        this.uploadPreloading = false;
      }
    }, (error) => {
      console.error(error)
      this.progress = 0;
      this.uploadPreloading = false;
    }).add(()=>{
      this.reset();
      this.progress = 0;
      this.uploadPreloading = false;
      this.findAllAttachmentByObjectId(this.itemId)
    });

  }

  deleteAttachment(userId:number,id:number)
  {
    if(!confirm("Are you sure for delete selected attachment?"))return;
    this.attchmentService.deleteAttachment({UserId:userId,Id:id}).subscribe(
      res=>{
        this.tostrService.success('Opeartion Delete Attachment Suuccessfull');
      },
      err=>this.tostrService.error(err)
    )
  }

  makeGuid(length:Number)
  {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result += characters.charAt(Math.floor(Math.random() *
      charactersLength));
    }
    return result;
  }

  ngOnInit(): void {
    this.item.next(null);
    this.itemData = [];
    this.itemService.getItemById(this.itemId).subscribe(
      res=>{
        this.item.next(res.payload);
      },
      err=>{
        this.tostrService.error(err);
      }
    ).add(()=>{
      this.itemData = this.item.value;
      this.findAllAttachmentByObjectId(this.itemId)
    })
  }
}
