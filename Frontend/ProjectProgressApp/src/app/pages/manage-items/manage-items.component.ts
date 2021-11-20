import { Component, OnInit, Injectable } from '@angular/core';
import {FlatTreeControl} from '@angular/cdk/tree';
import {MatTreeFlatDataSource, MatTreeFlattener} from '@angular/material/tree';
import { Router } from '@angular/router';
import { ItemService } from './../../data/service/item.service';
import { BehaviorSubject } from 'rxjs';

interface Node {
  id:number;
  parentId:number;
  name: string;
  children?: Node[];
}

// const TREE_DATA: Node[] = [
//   {
//     name: 'Fruit',
//     children: [
//       {name: 'Apple'},
//       {name: 'Banana'},
//       {name: 'Fruit loops'},
//     ]
//   }, {
//     name: 'Vegetables',
//     children: [
//       {
//         name: 'Green',
//         children: [
//           {name: 'Broccoli'},
//           {name: 'Brussels sprouts'},
//         ]
//       }, {
//         name: 'Orange',
//         children: [
//           {name: 'Pumpkins'},
//           {name: 'Carrots'},
//         ]
//       },
//     ]
//   },
// ];

interface FlatNode {
  expandable: boolean;
  name: string;
  level: number;
}


@Component({
  selector: 'app-manage-items',
  templateUrl: './manage-items.component.html',
  styleUrls: ['./manage-items.component.scss'],
})
export class ManageItemsComponent implements OnInit {

  loading=false;

  itemData = new BehaviorSubject<Node[]>([]);

  constructor(private itemService:ItemService,private router:Router) {
    this.getItems();
  }

  ngOnInit(): void {
    this.dataSource.data = this.itemData.value;
  }

  private _transformer = (node: Node, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  }

  treeControl = new FlatTreeControl<FlatNode>(
      node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
      this._transformer, node => node.level, node => node.expandable, node => node.children);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);



  hasChild = (_: number, node: FlatNode) => node.expandable;


  openItem(item:any){
    this.router.navigate(['manage-items/'+item])
  }

  getItems(){
    this.itemService.getItems().subscribe(
        res=>{
          this.itemData.next(res.payload);
          console.log(res.payload)
        },
        err=>{
          console.log(err);
        }
      );

  }







}











