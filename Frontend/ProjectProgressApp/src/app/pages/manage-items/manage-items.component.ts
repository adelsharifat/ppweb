import { Component, OnInit, Injectable } from '@angular/core';
import {FlatTreeControl} from '@angular/cdk/tree';
import {MatTreeFlatDataSource, MatTreeFlattener} from '@angular/material/tree';
import { Router } from '@angular/router';
import { ItemService } from './../../data/service/item.service';
import { BehaviorSubject } from 'rxjs';


interface FlatNode {
  expandable: boolean;
  name: string;
  id:string;
  level: number;
}


@Component({
  selector: 'app-manage-items',
  templateUrl: './manage-items.component.html',
  styleUrls: ['./manage-items.component.scss'],
})
export class ManageItemsComponent implements OnInit {

  loading=false;

  constructor(private itemService:ItemService,private router:Router) {
    this.getItems();
  }

  private _transformer = (node: Node | any, level: number) => {
    return {
      expandable: !!node.items && node.items.length > 0,
      name: node.name,
      id:node.id,
      count:node.attachments.length,
      itemCount:node.items.length,
      level: level,
    };
  }

  treeControl = new FlatTreeControl<any>(
      node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
      this._transformer, node => node.level, node => node.expandable, node => node.items);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);



  hasChild = (_: number, node: FlatNode) => node.expandable;


  openItem(item:any){
    this.router.navigate(['manage-items/'+item])
  }

  getItems(){
    this.itemService.getItems().subscribe(
        res=>{
          console.log(res.payload)
          this.dataSource.data = res.payload
        },
        err=>{
          console.log(err);
        }
      );

  }

  onFabClick(){
    this.router.navigate(['/manage-items/new'])
  }


  ngOnInit(): void {

  }



}











