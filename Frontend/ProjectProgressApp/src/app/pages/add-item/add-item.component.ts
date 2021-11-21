import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ItemService } from './../../data/service/item.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.scss']
})
export class AddItemComponent implements OnInit {

  loading = false;
  message = '';
  itemId:string|null = null;
  item:BehaviorSubject<any> = new BehaviorSubject<any>(null)
  itemData:any = [];
  operationResultStatus:number = 1;
  constructor(private itemService:ItemService,private route:ActivatedRoute,private router:Router)
  {
     this.itemId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    if(this.itemId !== 'new')
      this.getItemById();
  }

  getItemById(){
    this.itemService.getItemById(this.itemId).subscribe(
      res=>{
        this.item.next(res.payload)

      },
      err=>{

      }
    ).add(()=>{
      this.itemData = this.item.value;
    })
  }

  addItem(itemName:any){
    const parentId = this.itemId == 'new'?null:this.itemId
    const newItemObject = {name:itemName,parentId:parentId,userId:1}
    console.log(newItemObject)



    this.itemService.addItem(newItemObject).subscribe(
      res=>{
        this.message = 'Opertion Success!';
        this.operationResultStatus = 1;
      },
      err=>{
        this.message = err;
        this.operationResultStatus = 0;
      }
    ).add(()=>{
      this.itemData = this.item.value;
      this.message = '';
      this.router.navigate(['/manage-items'])
    })
  }


  delete(){
    if(confirm("Are you sure to delete this item")) {

      this.itemService.deleteItem(this.itemId).subscribe(
        res=>{
          this.message = 'Opertion Success!';
          this.operationResultStatus = 1;
          this.router.navigate(['/manage-items'])
        },
        err=>{
          this.message = err;
          this.operationResultStatus = 0;
        }
      ).add(()=>{
        this.itemData = this.item.value;
        this.message = '';
      })




    }
  }



}
