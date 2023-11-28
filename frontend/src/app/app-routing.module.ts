import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import {LoginPageComponent} from "./login-page/login-page.component";
import {SignupPageComponent} from "./signup-page/signup-page.component";
import {HomePage} from "./home/home.page";
import {CarouselComponent} from "./carousel/carousel.component";

const routes: Routes = [
  { path: 'eve', component: CarouselComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'signup', component: SignupPageComponent },
  { path: 'home', component: HomePage},
  { path: 'tabs', loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule) }

];

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}

