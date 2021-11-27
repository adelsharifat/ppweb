import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CdkTreeNode } from '@angular/cdk/tree';
import { NavModule } from '../../components/nav/nav.module';
import { ViewerComponent } from './viewer.component';
import { ViewerRoutingModule } from './viewer-routing.module';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';
@NgModule({
  declarations: [ViewerComponent],
  imports: [
    CommonModule,
    ViewerRoutingModule,
    NavModule,
    NgxExtendedPdfViewerModule,
  ],
  providers:[CdkTreeNode]
})
export class ViewerModule { }
