import { Component } from '@angular/core';

@Component({
  selector: 'app-step7-marriage',
  templateUrl: './step7-marriage.component.html',
  styleUrls: ['./step7-marriage.component.css']
})
export class Step7MarriageComponent {
  marriageData = {
      guardianAgreed: '',
      wifeInParda: '',
      wifeStudy: '',
      wifeJob: '',
      livingLocation: '',
      giftExpectation: '',
      marriageReason: ''
    };

    onSave() {
      console.log('Marriage Data Submitted:', this.marriageData);
    }
}
