import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTreeModule } from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { CdkTreeNode } from '@angular/cdk/tree';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ManageItemComponent } from './manage-item.component';
import { ManageItemRoutingModule } from './manage-item-routing.module';
import { NavModule } from './../../components/nav/nav.module';

@NgModule({
  declarations: [ManageItemComponent],
  imports: [
CommonModule,
    ManageItemRoutingModule,
    MatIconModule,
    MatToolbarModule,
    MatTreeModule,
    MatButtonModule,
    MatTreeModule,
    MatProgressSpinnerModule,
    NavModule
  ],
  providers:[CdkTreeNode]
})
export class ManageItemModule { }
