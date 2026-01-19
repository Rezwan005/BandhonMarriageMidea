import { Component } from '@angular/core';

@Component({
  selector: 'app-step8-partner',
  templateUrl: './step8-partner.component.html',
  styleUrls: ['./step8-partner.component.css']
})
export class Step8PartnerComponent {
partnerData = {
    ageRange: 18,
    complexion: '',
    height: '',
    educationalQualification: '',
    district: '',
    maritalStatus: '',
    profession: '',
    financialStatus: '',
    expectedQualities: ''
  };

  onSave() {
    console.log('Partner Expectations Submitted:', this.partnerData);
  }
}
