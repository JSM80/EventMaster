import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import {TableOfContentComponent} from "../table-of-content/table-of-content.component";
import {NavBarComponent} from "../nav-bar/nav-bar.component";
import {SideMenuComponent} from "../side-menu/side-menu.component";
import {AppModule} from "../app.module";

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        HomePageRoutingModule,
        AppModule
    ],
  declarations: [HomePage, TableOfContentComponent, NavBarComponent, SideMenuComponent]
})
export class HomePageModule {}
