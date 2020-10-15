import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';

import {ApproutingModule} from './app-routing.module';
import {MenuComponent} from './Components/Blocks/Menu/menu.component';
import {SliderComponent} from './Components/Blocks/Slider/Slider.component';
import {UsersComponent} from './Components/Blocks/Users/Users.component';
import {CategoriesComponent} from './Components/Blocks/Categories/Categories.component';
import {footerComponent} from './Components/Blocks/Footer/Footer.component';





@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SliderComponent,
    UsersComponent,
    CategoriesComponent,
    footerComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    ApproutingModule,
    
    BsDropdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
