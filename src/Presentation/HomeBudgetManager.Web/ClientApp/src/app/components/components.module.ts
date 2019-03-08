import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ConfirmDialogComponent } from './dialogs/confirm-dialog/confirm-dialog.component';
import { BusyIndicatorComponent } from './busy-indicator/busy-indicator.component';

import { MatProgressSpinnerModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatProgressSpinnerModule
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    ConfirmDialogComponent,
    BusyIndicatorComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    ConfirmDialogComponent,
    BusyIndicatorComponent
  ],
  entryComponents: [
    ConfirmDialogComponent
  ]
})
export class ComponentsModule { }
