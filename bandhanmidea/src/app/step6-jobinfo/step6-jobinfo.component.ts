import { Component } from '@angular/core';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';
import { DataLookup } from '../model/lookup.model';

@Component({
  selector: 'app-step6-jobinfo',
  templateUrl: './step6-jobinfo.component.html',
  styleUrls: ['./step6-jobinfo.component.css']
})
export class Step6JobinfoComponent {

  constructor(
    private biodataService: BiodataService,
    private authService: AuthService
  ) {}

  formData = {
    userId:0,
    profession: '',
    professionDetails: '',
    monthlyIncome: ''
  };

  OccupationList: DataLookup[] = [];

  ngOnInit() {
   
    this.loadOccupationList();
    this.loadExistingData();
  }

  loadOccupationList() {
    this.biodataService.getLookup('Occupation')
      .subscribe(res => this.OccupationList = res);
  }

  loadExistingData() {
      const userId = this.authService.getUser().id;
    this.biodataService.getOccupationByUserId(userId)
      .subscribe(res => {
        if (res) {
          this.formData = { ...this.formData, ...res };
        }
      });
  }

  onSave() {
      const userId = this.authService.getUser().id;
    this.formData.userId = userId;
    this.biodataService.saveOrUpdateOccupation(this.formData)
      .subscribe(() => {
        alert('Information Saved Successfully!');
      });
  }
}
