import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageItemsComponent } from './manage-items.component';
import { ManageItemsRoutingModule } from './manage-items-routing.module';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTreeModule } from '@angular/material/tree';
import { MatButtonModule } from '@angular/material/button';
import { CdkTreeNode } from '@angular/cdk/tree';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NavModule } from 'src/app/components/nav/nav.module';

@NgModule({
  declarations: [ManageItemsComponent],
  imports: [
  CommonModule,
    ManageItemsRoutingModule,
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
export class ManageItemsModule { }
