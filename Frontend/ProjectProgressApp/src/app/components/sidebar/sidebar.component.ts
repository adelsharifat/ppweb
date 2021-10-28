import { Component, Input, OnInit } from '@angular/core';
import { ToolbarService } from './../../data/service/toolbar.service';
import { AuthService } from './../../data/service/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  constructor(private toolbarService:ToolbarService,private authService:AuthService) { }

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
