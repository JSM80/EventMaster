import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {LoginPageComponent} from "./login-page/login-page.component";
import {HttpClientModule} from "@angular/common/http";
import {SignupPageComponent} from "./signup-page/signup-page.component";
import {HomePageModule} from "./home/home.module";
import {HomePageRoutingModule} from "./home/home-routing.module";
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {EventCardComponent} from "./event-card/event-card.component";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {CarouselComponent} from "./carousel/carousel.component";

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [AppComponent, LoginPageComponent, SignupPageComponent, CarouselComponent],
  imports: [BrowserModule, IonicModule.forRoot({mode: "ios"}), AppRoutingModule, HttpClientModule, NgbModule],
  providers: [{provide: RouteReuseStrategy, useClass: IonicRouteStrategy}],
  bootstrap: [AppComponent],
  exports: [
    CarouselComponent
  ]
})
export class AppModule {}
