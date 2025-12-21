import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileListComponent } from './profilelist/profilelist.component';
import { HomeComponent } from './home/home.component';
import { ProfilepageComponent } from './profilepage/profilepage.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BiodataLayoutComponent } from './biodata-layout/biodata-layout.component';
import { Step2AddressComponent } from './step2-address/step2-address.component';
import { BiodataGeneralInfoComponent } from './biodata-general-info/biodata-general-info.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  { path: 'profile', component: ProfilepageComponent },
   { path: 'dashboard', component: DashboardComponent ,children: [
      { path: 'editbio', 
        component: BiodataLayoutComponent,   // left menu + right form layout
        children: [
            { path: '1', component: BiodataGeneralInfoComponent },
            { path: '2', component: Step2AddressComponent },
            // { path: '3', component: Step3EducationComponent },  // create this component
            // { path: '4', component: Step4FamilyComponent },
            // { path: '5', component: Step5PersonalComponent },
            // { path: '6', component: Step6ProfessionalComponent },
            // { path: '7', component: Step7MarriageComponent },
            // { path: '8', component: Step8LifestyleComponent },
            // { path: '9', component: Step9ExtraComponent },
            // { path: '10', component: Step10ContactComponent },

            { path: '', redirectTo: '1', pathMatch: 'full' }
        ] },
    
    ]},
     // --------------------------
  //  NEW → BIODATA ROUTES
  // --------------------------
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
