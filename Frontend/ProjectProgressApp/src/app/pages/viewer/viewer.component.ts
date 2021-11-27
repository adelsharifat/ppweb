import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DownloadService } from '../../data/service/download.service';
import { pdfDefaultOptions } from 'ngx-extended-pdf-viewer';



@Component({
  selector: 'app-item',
  templateUrl: './viewer.component.html',
  styleUrls: ['./viewer.component.scss']
})
export class ViewerComponent implements OnInit {

  pdfSrc:string = '';


  constructor(private route:ActivatedRoute,private router:Router,private downloadService:DownloadService) {
  }

  ngOnInit(): void {
    this.pdfSrc = this.downloadService.fileStream.value as string
  }
}
