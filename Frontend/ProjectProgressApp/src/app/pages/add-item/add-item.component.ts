import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.scss']
})
export class AddItemComponent implements OnInit {

  loading = false;
  itemName :string | null = null;
  constructor(private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.itemName = this.route.snapshot.paramMap.get('id');
  }


}
