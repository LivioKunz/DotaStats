import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { HeroDisplayComponent } from './hero-display/hero-display.component';
import { HttpClientModule } from '@angular/common/http';
import { HeroSearchService} from './hero-search.service';

const appRoutes: Routes = [
  { path: '', component: HomeComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeroDisplayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,    
    FormsModule
  ],
  providers: [
    HeroSearchService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
