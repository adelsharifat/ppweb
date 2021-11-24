import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTreeModule } from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { CdkTreeNode } from '@angular/cdk/tree';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NavModule } from './../../components/nav/nav.module';
import { AddItemComponent } from './add-item.component';
import { AddItemRoutingModule } from './add-item-routing.module';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [AddItemComponent],
  imports: [
    CommonModule,
    AddItemRoutingModule,
    MatIconModule,
    MatToolbarModule,
    MatTreeModule,
    MatButtonModule,
    MatTreeModule,
    MatProgressSpinnerModule,
    FormsModule,
    NavModule
  ],
  providers:[CdkTreeNode]
})
export class AddItemModule { }
