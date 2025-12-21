import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({

  selector: 'app-step2-address',
 templateUrl: './step2-address.component.html',
  styleUrls: ['./step2-address.component.css']
})
export class Step2AddressComponent {

 formData = {
    permanentAddress: '',
    currentAddress: '',
    hometown: '',
    isSameAddress: false
  };

  toggleSameAddress() {
    if (this.formData.isSameAddress) {
      this.formData.currentAddress = this.formData.permanentAddress;
    } else {
      this.formData.currentAddress = '';
    }
  }

  onSave() {
    console.log('Form Submitted:', this.formData);
    // Add your navigation or API logic here
  }
}
