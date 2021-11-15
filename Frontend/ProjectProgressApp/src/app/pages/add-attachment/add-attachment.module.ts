import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTreeModule } from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { CdkTreeNode } from '@angular/cdk/tree';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NavModule } from './../../components/nav/nav.module';
import { AddAttachmentComponent } from './add-attachment.component';
import { AddAttachmentRoutingModule } from './add-attachment-routing.module';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [AddAttachmentComponent],
  imports: [
  CommonModule,
    AddAttachmentRoutingModule,
    MatIconModule,
    MatToolbarModule,
    MatTreeModule,
    MatButtonModule,
    MatTreeModule,
    MatProgressSpinnerModule,
    NavModule,
    NgxDropzoneModule,
    FormsModule
  ],
  providers:[CdkTreeNode]
})
export class AddAttachmentModule { }
