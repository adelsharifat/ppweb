import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { AdminService } from './../../../data/service/admin.service';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { BehaviorSubject } from 'rxjs';
import { AttachmentService } from './../../../data/service/attachment.service';
import { ItemService } from 'src/app/data/service/item.service';

@Component({
  selector: 'app-main',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  load_tile_body = false;
  itemData:any = [];

  constructor(private itemService:ItemService,private attachmentService:AttachmentService,private adminService:AdminService) {
    this.getItems();
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

  getItems(){
    this.itemService.getItems().subscribe(
        res=>{
          this.itemData = res.payload
        },
        err=>{
          console.log(err);
        }
      );

  }



  ngOnInit() {
    this.load_tile_body = true;
    this.adminService.index();

  }

  sidebarState = false;

  onSidebarState(data:any):void{
    this.sidebarState = data;
  }


}
