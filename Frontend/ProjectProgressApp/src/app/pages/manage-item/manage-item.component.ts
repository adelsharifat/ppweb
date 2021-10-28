import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';

@Component({
  selector: 'app-manage-item',
  templateUrl: './manage-item.component.html',
  styleUrls: ['./manage-item.component.scss']
})
export class ManageItemComponent implements OnInit {

  loading = false;
  itemName:string | null = null;
  constructor(private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.itemName = this.route.snapshot.paramMap.get('id')
  }

  openAddItemPage(){
    this.router.navigate(['add-item/'+this.itemName])
  }

  openAddAttachmentPage(){
    this.router.navigate(['add-attachment/'+this.itemName])
  }

}
