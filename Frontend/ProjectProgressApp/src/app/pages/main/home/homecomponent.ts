import { Component, OnInit } from '@angular/core';
import { AdminService } from './../../../data/service/admin.service';

@Component({
  selector: 'app-main',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  load_tile_body = false;
  constructor(private adminService:AdminService) { }

  ngOnInit() {
    this.load_tile_body = true;
    this.adminService.index();

  }

  sidebarState = false;

  onSidebarState(data:any):void{
    this.sidebarState = data;
  }


}
