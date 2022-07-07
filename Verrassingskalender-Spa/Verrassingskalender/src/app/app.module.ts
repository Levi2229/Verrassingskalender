import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/material.module';
import { HeaderComponent } from './components/header/header.component';
import { SiteContainerComponent } from './components/site-container/site-container.component';
import { SocialsComponent } from './components/socials/socials.component';
import { GridContainerComponent } from './components/grid/grid-container/grid-container.component';

@NgModule({
  declarations: [AppComponent, LandingPageComponent, HeaderComponent, SiteContainerComponent, SocialsComponent, GridContainerComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
