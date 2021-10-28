import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-attachment',
  templateUrl: './add-attachment.component.html',
  styleUrls: ['./add-attachment.component.scss']
})
export class AddAttachmentComponent implements OnInit {

  loading = false;
  itemName :string | null = null;
  constructor(private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.itemName = this.route.snapshot.paramMap.get('id');
  }

}
