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
import {UserInfoComponent} from "./user-info/user-info.component"
import {HomePageRoutingModule} from "./home/home-routing.module";

@NgModule({
  declarations: [AppComponent, LoginPageComponent, SignupPageComponent, UserInfoComponent],
  imports: [BrowserModule, IonicModule.forRoot({mode: "ios"}), AppRoutingModule, HttpClientModule],
  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule {}
