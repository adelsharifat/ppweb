import { Component, OnInit } from '@angular/core';
import { AttachmentService } from 'src/app/data/service/attachment.service';
import { ItemService } from 'src/app/data/service/item.service';

@Component({
  selector: 'app-find-components',
  templateUrl: './find-components.component.html',
  styleUrls: ['./find-components.component.scss']
})
export class FindComponentsComponent implements OnInit {

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
