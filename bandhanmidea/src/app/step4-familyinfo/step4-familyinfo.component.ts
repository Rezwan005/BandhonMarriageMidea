import { Component } from '@angular/core';

@Component({
  selector: 'app-step4-familyinfo',
  templateUrl: './step4-familyinfo.component.html',
  styleUrls: ['./step4-familyinfo.component.css']
})
export class Step4FamilyinfoComponent {
familyData = {
    fatherName: '',
    fatherStatus: '',
    fatherOccupation: '',
    motherName: '',
    motherStatus: '',
    motherOccupation: '',
    brotherCount: '',
    sisterCount: '',
    brothersOccupation: '',
    maritalStatus: '',
    familyDescription: '',
    financialStatus: ''
  };

  onSave() {
    console.log('Family Data Submitted:', this.familyData);
  }
}
