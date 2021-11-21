import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { ToolbarService } from './../../data/service/toolbar.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
  encapsulation:ViewEncapsulation.None
})
export class ToolbarComponent implements OnInit {

  constructor(private toolbarService:ToolbarService) { }

  ngOnInit(): void {
  }

  sidebarState = false;

  public openSidebar(): void {
    this.toolbarService.sidebarState.next(!this.sidebarState)
  }

}
