import { Component, OnInit } from '@angular/core';
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
  item = new BehaviorSubject<any>(null)
  file:string|Blob|any='';

  attachmentData = new BehaviorSubject<any>(null);

  constructor(private itemService:ItemService,
    private authService:AuthService,
    private attchmentService:AttachmentService,
    private fb:FormBuilder,
    private route:ActivatedRoute,
    private router:Router) { }


  fg = this.fb.group({
    file:[null,Validators.required],
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
    this.fg.controls['fileAddressInput'].setValue(event.target.files[0].name)
    this.file = event.target.files[0]
  }


  findAllAttachmentByObjectId(objectId:number){
    this.bodyPreloading = true;
    this.attchmentService.findAttachmentByObjectId(objectId).subscribe(
      res=>{
        this.attachmentData.next(res.payload);
        this.bodyPreloading = false;
        console.log(res);
      },
      err=>{
        console.log(err);
      }
    )
  }

  upload()
  {
    this.uploadPreloading = true;
    var formData = new FormData();
    formData.append('createdBy','1');
    formData.append('itemId','1');
    formData.append('fileName',this.file.name);
    formData.append('file',this.file);
    formData.append('remark',this.fg.value.remark);
    this.attchmentService.saveAttachments(formData)
    .subscribe( (event) => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else if (event instanceof HttpResponse) {
        this.progress = 0;
        this.uploadPreloading = false;
        this.findAllAttachmentByObjectId(1);
      }
    }, (error) => {
      console.error(error)
      this.progress = 0;
      this.uploadPreloading = false;
    });

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

    this.itemService.getItemById(this.route.snapshot.paramMap.get('id')).subscribe(
      res=>{
        this.item.next(res.payload);
      },
      err=>{
        console.log(err)
      }
    )

    this.findAllAttachmentByObjectId(1)
  }

}
