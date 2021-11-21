import { LEADING_TRIVIA_CHARS } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ItemService } from 'src/app/data/service/item.service';

@Component({
  selector: 'app-manage-item',
  templateUrl: './manage-item.component.html',
  styleUrls: ['./manage-item.component.scss']
})
export class ManageItemComponent implements OnInit {

  loading = false;
  itemId:string | null = null;
  item:BehaviorSubject<any> = new BehaviorSubject<any>(null);
  itemData:any = [];
  constructor(private itemService:ItemService,private route:ActivatedRoute,private router:Router) {
    this.itemId = this.route.snapshot.paramMap.get('id')
  }

  ngOnInit(): void {
    if(this.itemId !== 'new')
      this.getItemById();
  }

  openAddItemPage(){
    this.router.navigate(['add-item/'+this.itemId])
  }

  openAddAttachmentPage(){
    this.router.navigate(['add-attachment/'+this.itemId])
  }

  getItemById(){
    this.itemService.getItemById(this.itemId).subscribe(
      res=>{
        this.item.next(res.payload)
      },
      err=>{
        console.log(err)
      }
    ).add(()=>{
      this.itemData = this.item.value;
      console.log(this.itemData)
    })
  }


}
