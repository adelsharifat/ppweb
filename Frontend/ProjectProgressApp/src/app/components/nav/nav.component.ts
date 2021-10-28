import { Location } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  constructor(private location:Location) { }

  ngOnInit(): void {
  }

  @Input() pageTitle: string | undefined = 'Title'

  backLocation(){
    console.log(this.location.path)
    this.location.back();
  }

}
