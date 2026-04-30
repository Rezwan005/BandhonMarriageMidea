import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileListComponent } from './profilelist/profilelist.component';
import { HomeComponent } from './home/home.component';
import { ProfilepageComponent } from './profilepage/profilepage.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BiodataLayoutComponent } from './biodata-layout/biodata-layout.component';
import { Step2AddressComponent } from './step2-address/step2-address.component';
import { BiodataGeneralInfoComponent } from './biodata-general-info/biodata-general-info.component';
import { Step3EducationComponent } from './step3-education/step3-education.component';
import { Step4FamilyinfoComponent } from './step4-familyinfo/step4-familyinfo.component';
import { Step5PersonalinfoComponent } from './step5-personalinfo/step5-personalinfo.component';
import { Step6JobinfoComponent } from './step6-jobinfo/step6-jobinfo.component';
import { Step7MarriageComponent } from './step7-marriage/step7-marriage.component';
import { Step8PartnerComponent } from './step8-partner/step8-partner.component';
import { Step9ResolutionComponent } from './step9-resolution/step9-resolution.component';
import { Step10ContactComponent } from './step10-contact/step10-contact.component';
import { LoginComponent } from './login/login.component';
import { PreviewBiodataComponent } from './preview-biodata/preview-biodata.component';
import { PreviewlayoutComponent } from './previewlayout/previewlayout.component';
import { BiodataDetailsComponent } from './biodata-details/biodata-details.component';
import { GoogleLoginCallbackComponent } from './google-login-callback/google-login-callback.component';
import { MyacountComponent } from './myacount/myacount.component';



const routes: Routes = [
  {path: '', component: HomeComponent},
  { path: 'profile', component: ProfilepageComponent },
   { path: 'login', component: LoginComponent },
   { path: 'google-login-callback', component: GoogleLoginCallbackComponent },
{ path: 'biodata/:biodataNo', component: BiodataDetailsComponent },
   { path: 'dashboard', component: DashboardComponent ,children: [
      { path: 'editbio', 
        component: BiodataLayoutComponent,   // left menu + right form layout
        children: [
            { path: '1', component: BiodataGeneralInfoComponent },
            { path: '2', component: Step2AddressComponent },
            { path: '3', component: Step3EducationComponent },  // create this component
            { path: '4', component: Step4FamilyinfoComponent },
            { path: '5', component: Step5PersonalinfoComponent },
             { path: '6', component: Step6JobinfoComponent },
            { path: '7', component: Step7MarriageComponent },
            { path: '8', component: Step8PartnerComponent },
            { path: '9', component: Step9ResolutionComponent },
            { path: '10', component: Step10ContactComponent },
       
            { path: '', redirectTo: '1', pathMatch: 'full' }
        ] },
    
    ]},
  { 
    path: 'dashboard', 
    component: DashboardComponent,
    children: [
      { 
        path: 'user', 
        component: PreviewlayoutComponent,
        children: [
          { path: 'preview-biodata', component: PreviewBiodataComponent },
          { path: '', redirectTo: 'preview-biodata', pathMatch: 'full' }
        ] 
      },
      { 
        path: 'accinfo', 
        component: MyacountComponent,
       
      }
    ]
  }

     // --------------------------
  //  NEW → BIODATA ROUTES
  // --------------------------
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
