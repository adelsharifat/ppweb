import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/data/service/item.service';
import { AttachmentService } from './../../../../data/service/attachment.service';

@Component({
  selector: 'app-home-items',
  templateUrl: './home-items.component.html',
  styleUrls: ['./home-items.component.scss']
})
export class HomeItemsComponent implements OnInit {
  itemData:any = [];
  itemManagementData:any = [];

  constructor(private itemService:ItemService,private attachmentService:AttachmentService)
  {
    this.getItems();
    this.getManagementItems();
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


  getManagementItems(){
    this.itemService.getManagementItems().subscribe(
        res=>{
          this.itemManagementData = res.payload
        },
        err=>{
          console.log(err);
        }
      );

  }


  getIconByItemName(itemName:any){
    if(itemName === 'AG')
      return 'assets/img/icons/AG.png'
    if(itemName === 'UG')
      return 'assets/img/icons/UG.png'
    if(itemName === 'CONCRETE')
      return 'assets/img/icons/concrete.png'

    return '';
  }

}
