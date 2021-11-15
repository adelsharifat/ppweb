import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IAttachmentRequest } from 'src/app/data/interface/request/IAttachmentRequest';
import { AttachmentService } from './../../data/service/attachment.service';
import { AuthService } from './../../data/service/auth.service';
import { BehaviorSubject } from 'rxjs';
import { ItemService } from './../../data/service/item.service';

@Component({
  selector: 'app-add-attachment',
  templateUrl: './add-attachment.component.html',
  styleUrls: ['./add-attachment.component.scss']
})
export class AddAttachmentComponent implements OnInit {

  loading = false;
  item = new BehaviorSubject<any>(null)
  itemName :string | null = null;
  constructor(private itemService:ItemService,private authService:AuthService,private attchmentService:AttachmentService,private route:ActivatedRoute,private router:Router) { }


  files: File[] = [];
  remark = '';

  uploadPreloading =true;
  resetPreloading =true;


  onSelect(event:any) {
    console.log(event);
    this.files.push(...event.addedFiles);
  }

  onRemove(event:any) {
    console.log(event);
    this.files.splice(this.files.indexOf(event), 1);
  }

  reset(){
    this.files = [];
    this.remark = '';
  }

  upload()
  {
    this.itemService.getItemById(1).subscribe(res=>{
      this.item.next(res.payload)

    },err=>console.log(err)).add(()=>{

      var attachments:IAttachmentRequest[] =[];
      this.files.forEach((file)=>{
        this.fileToBase64(file)
        var attachment:IAttachmentRequest = {
          fileName:file.name,
          fileStream:file.arrayBuffer,
          remark:this.remark,
          createdBy: 1,
          itemId:this.item.value.id
        }
        attachments.push(attachment)
        console.log(attachments)
      })
      this.attchmentService.saveAttachments(attachments).subscribe(res=>console.log(res),err=>console.log(err));
    })
  }


  fileToBase64 = (file:File):Promise<Int8Array> => {
    return new Promise<Int8Array> ((resolve,reject)=> {
         const reader = new FileReader();
         reader.readAsArrayBuffer(file);
     })
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
