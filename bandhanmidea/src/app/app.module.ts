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
import { Step3EducationComponent } from './step3-education/step3-education.component';
import { Step4FamilyinfoComponent } from './step4-familyinfo/step4-familyinfo.component';
import { Step5PersonalinfoComponent } from './step5-personalinfo/step5-personalinfo.component';
import { Step6JobinfoComponent } from './step6-jobinfo/step6-jobinfo.component';
import { Step7MarriageComponent } from './step7-marriage/step7-marriage.component';
import { Step8PartnerComponent } from './step8-partner/step8-partner.component';

import { Step9ResolutionComponent } from './step9-resolution/step9-resolution.component';
import { Step10ContactComponent } from './step10-contact/step10-contact.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { PreviewBiodataComponent } from './preview-biodata/preview-biodata.component';
import { PreviewlayoutComponent } from './previewlayout/previewlayout.component';
import { BiodataDetailsComponent } from './biodata-details/biodata-details.component';
import { GoogleLoginCallbackComponent } from './google-login-callback/google-login-callback.component';



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
    Step2AddressComponent,
    Step3EducationComponent,
    Step4FamilyinfoComponent,
    Step5PersonalinfoComponent,
    Step6JobinfoComponent,
    Step7MarriageComponent,
    Step8PartnerComponent,

    Step9ResolutionComponent,
      Step10ContactComponent,
      LoginComponent,
      PreviewBiodataComponent,
      PreviewlayoutComponent,
      BiodataDetailsComponent,
      GoogleLoginCallbackComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CommonModule ,
    SocialLoginModule,
        HttpClientModule   // ✅ ADD THIS  
  ],
  providers: [{
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false, // set true if you want auto login
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '521492801604-ht2gj9q5k6ed5609p069a6bdl7vhvngn.apps.googleusercontent.com' // replace with your client ID
            )
          }
        ]
      } as SocialAuthServiceConfig,
    },
    
     { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
