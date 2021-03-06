import { Component, Input, OnInit } from '@angular/core';
import { ToolbarService } from './../../data/service/toolbar.service';
import { AuthService } from './../../data/service/auth.service';
import { IUser } from 'src/app/data/interface/model/User';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  fullName:any;
  isAdmin:Boolean|undefined = false;

  constructor(private toolbarService:ToolbarService,private authService:AuthService) {
    this.fullName = this.authService.fullName();
    this.isAdmin = this.authService.isAdmin() === "True";
  }

  ngOnInit(): void {

  }

  getSidebarState(){
    return this.toolbarService.sidebarState.value;
  }

  closeSidebar(){
    this.toolbarService.sidebarState.next(false)
  }


  signout(){
    this.authService.logout();
  }

}
