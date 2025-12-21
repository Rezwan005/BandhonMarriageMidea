import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HowItworkComponent } from './how-itwork/how-itwork.component';
import { HeaderComponent } from './header/header.component';
import { ViewprofileComponent } from './viewprofile/viewprofile.component';

import { StatsCounterComponent } from './stats-counter/stats-counter.component';

import { FooterComponent } from './footer/footer.component';
import { TutorialComponent } from './tutorial/tutorial.component';
import { ProfileListComponent } from './profilelist/profilelist.component';
import { FiltersComponent } from './filter/filter.component';
import { ProfilepageComponent } from './profilepage/profilepage.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BiodataSidebarComponent } from './biodata-sidebar/biodata-sidebar.component';
import { BiodataGeneralInfoComponent } from './biodata-general-info/biodata-general-info.component';
import { BiodataLayoutComponent } from './biodata-layout/biodata-layout.component';
import { StepMenuComponent } from './step-menu/step-menu.component';
import { Step2AddressComponent } from './step2-address/step2-address.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HowItworkComponent,
    HeaderComponent,
    ViewprofileComponent,
    ProfileListComponent,
    StatsCounterComponent,
    FiltersComponent,
    FooterComponent,
    TutorialComponent,
    ProfilepageComponent,
    DashboardComponent,
    BiodataSidebarComponent,
    BiodataGeneralInfoComponent,
    BiodataLayoutComponent,
    StepMenuComponent,
    Step2AddressComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CommonModule   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
