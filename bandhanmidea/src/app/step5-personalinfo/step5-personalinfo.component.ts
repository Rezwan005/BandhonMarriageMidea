import { Component } from '@angular/core';

import { AuthService } from '../_services/authService.service';
import { BiodataService } from '../_services/biodata.service';

@Component({
  selector: 'app-step5-personalinfo',
  templateUrl: './step5-personalinfo.component.html',
  styleUrls: ['./step5-personalinfo.component.css']
})
export class Step5PersonalinfoComponent {

  previewUrl: string | ArrayBuffer | null = null;
  selectedFile: File | null = null;

  data :any= {
    dressOutside: '',
    diseaseInfo: '',
    specialWork: '',
    aboutYourself: '',
    mobileNo: ''
  };

  constructor(
    private biodataService: BiodataService,
    private authService: AuthService
  ) {}
    ngOnInit() {
        this.loadPersonalInfo();
  
    }
  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (!file) return;

    this.selectedFile = file;

    const reader = new FileReader();
    reader.onload = () => this.previewUrl = reader.result;
    reader.readAsDataURL(file);
  }

  removePhoto() {
    this.previewUrl = null;
    this.selectedFile = null;
  }
loadPersonalInfo() {
  const userId = this.authService.getUser().id;
  this.biodataService.getPersonalInfoByUserId(userId)
    .subscribe(res => {
      if (res) {
        this.data = res;

        // If there's an existing selfie, show it in preview
        if (res.selfieUrl) {
          this.previewUrl = res.selfieUrl;
        }
      }
    });
}

  onSave() {
    debugger;
    const formData = new FormData();
    formData.append('userId', this.authService.getUser().id);
    formData.append('dressOutside', this.data.dressOutside);
    formData.append('diseaseInfo', this.data.diseaseInfo);
    formData.append('specialWork', this.data.specialWork);
    formData.append('aboutYourself', this.data.aboutYourself);
    formData.append('mobileNo', this.data.mobileNo);
    formData.append('selfie', this.selectedFile!);

    this.biodataService.saveOrUpdatePersonalInfo(formData)
      .subscribe(() => {
        alert('Personal information saved successfully ✅');
      });
  }
}
