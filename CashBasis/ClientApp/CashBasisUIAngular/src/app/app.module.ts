import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './components/layout/layout.component';
import { RecurrencesComponent } from './components/recurrences/recurrences.component';
import { ExpenceCategoriesComponent } from './components/expence-categories/expence-categories.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    RecurrencesComponent,
    ExpenceCategoriesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
