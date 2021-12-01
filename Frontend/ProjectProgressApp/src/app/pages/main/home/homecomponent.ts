import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/data/service/auth.service';
import { ToolbarService } from './../../../data/service/toolbar.service';
import { TokenService } from './../../../data/service/token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  load_tile_body = false;
  itemData:any = [];
  fullName:any;

  constructor(private toolBarService:ToolbarService,private authService:AuthService,private tokenService:TokenService,private router:Router) {
    this.toolBarService.sidebarState.next(false)
    this.fullName = this.authService.fullName();
  }

  makeGuid(length:Number)
  {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result += characters.charAt(Math.floor(Math.random() *
      charactersLength));
    }
    return result;
  }


  ngOnInit() {
    this.load_tile_body = true;
  }

  sidebarState = false;

  onSidebarState(data:any):void{
    this.sidebarState = data;
  }


}
