import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/data/service/admin.service';
import { ItemService } from 'src/app/data/service/item.service';
import { AttachmentService } from './../../../../data/service/attachment.service';

@Component({
  selector: 'app-home-items',
  templateUrl: './home-items.component.html',
  styleUrls: ['./home-items.component.scss']
})
export class HomeItemsComponent implements OnInit {
  itemData:any = [];

  constructor(private itemService:ItemService,private attachmentService:AttachmentService)
  {
    this.getItems();
  }

  ngOnInit(): void {
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

}
