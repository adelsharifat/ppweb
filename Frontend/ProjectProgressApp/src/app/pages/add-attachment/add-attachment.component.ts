import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AttachmentService } from './../../data/service/attachment.service';
import { AuthService } from './../../data/service/auth.service';
import { BehaviorSubject } from 'rxjs';
import { ItemService } from './../../data/service/item.service';
import { IAttachment, IAttachmentRequest } from 'src/app/data/interface/request/IAttachmentRequest';

@Component({
  selector: 'app-add-attachment',
  templateUrl: './add-attachment.component.html',
  styleUrls: ['./add-attachment.component.scss']
})
export class AddAttachmentComponent implements OnInit {

  loading = false;
  item = new BehaviorSubject<any>(null)
  fileContentArrray = new BehaviorSubject<any>(null)


  itemName :string | null = null;
  constructor(private itemService:ItemService,private authService:AuthService,private attchmentService:AttachmentService,private route:ActivatedRoute,private router:Router) { }


  fileInputValue:any;
  fileInput:any;
  remark = '';

  uploadPreloading =true;
  resetPreloading =true;






  reset(){
    this.fileInputValue = null;
    this.fileInput = null;
    this.remark = '';
  }

  onChangeFileInput(event:any)
  {
    this.fileInput = <File>event.target.files[0];
    console.log(event.target.files[0].name)
  }


  upload()
  {
    var formData = new FormData();
    formData.append(this.fileInputValue,this.fileInput,this.fileInputValue)
    console.log(this.fileInput)
    this.attchmentService.saveAttachments().subscribe(res=>console.log(res),err=>console.log(err))
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
    this.itemName = this.route.snapshot.paramMap.get('id');
    console.log(this.makeGuid(35));
  }

}
