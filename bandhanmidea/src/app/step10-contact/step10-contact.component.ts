import { Component } from '@angular/core';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';

@Component({
  selector: 'app-step10-contact',
  templateUrl: './step10-contact.component.html',
  styleUrls: ['./step10-contact.component.css']
})

export class Step10ContactComponent {
  isSaving:any;
  constructor(
      private biodataService: BiodataService,
      private authService: AuthService
    ) {}
ngOnInit() {
    this.loadContactInfo();

}

contactData:any = {
    groomName: '',
    guardianMobile: '',
    guardianRelation: '',
    biodataEmail: ''
  };
loadContactInfo() {
  const userId = this.authService.getUser().id;
  this.biodataService.getContactByUserId(userId)
    .subscribe(res => {
      if (res) {
        this.contactData = res;

      }
    });
}
  onFinalSubmit(): void {
    this.isSaving = true;
this.contactData.userId = this.authService.getUser().id;
    this.biodataService
      .saveOrUpdateContact(this.contactData)
      .subscribe({
        next: () => {
          alert('Contact information saved successfully ✅');
          this.isSaving = false;
        },
        error: err => {
          console.error(err);
          alert('Failed to save contact information ❌');
          this.isSaving = false;
        }
      });
  }
}
