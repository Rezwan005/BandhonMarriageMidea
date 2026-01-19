import { Component } from '@angular/core';

@Component({
  selector: 'app-step9-resolution',
  templateUrl: './step9-resolution.component.html',
  styleUrls: ['./step9-resolution.component.css']
})
export class Step9ResolutionComponent {
currentStep: string = 'partner'; 

  formData = {
    // Expected Life Partner Fields
    partnerAge: 18,
    partnerComplexion: '',
    partnerHeight: '',
    partnerEducation: '',
    partnerDistrict: '',
    partnerMaritalStatus: '',
    partnerProfession: '',
    partnerFinancialStatus: '',
    partnerQualities: '',

    // Pledge/Declaration Fields
    guardianAware: '',
    informationTruth: '',
    authorityLiabilityAgreement: ''
  };

  onSave() {
    console.log('Final Form Data:', this.formData);
    if(this.currentStep === 'partner') {
      this.currentStep = 'pledge';
    } else {
      alert('Biodata Submitted Successfully!');
    }
  }
}
