import { Component } from '@angular/core';
import { DataLookup } from '../model/lookup.model';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';
import { Education } from '../model/Education.model';

@Component({
  selector: 'app-step3-education',
  templateUrl: './step3-education.component.html',
  styleUrls: ['./step3-education.component.css']
})
export class Step3EducationComponent {
constructor(private biodataService: BiodataService,private authService: AuthService) {}
eduData: any  = {
    
    method:'General',
    highestDegree: 'SSC',
    sscPY: '2025',
    sscgroup: 'fdg',
    sscResult: '',
    sscInsName:'',
    hscPY: '2025',
    hscgroup: 'fdg',
    hscResult: '',
    hscInsName:'',
   
    ugPY: '2025',
    gSubject: 'fdg',
    ugInsName:'',
    otherDetails: ''
  };

highestDegreeList: DataLookup[] = [];
ResultList: DataLookup[] = [];
groupList: DataLookup[] = [];

ngOnInit() {
    this.loadhighestDegree();
    this.loadResult();
    this.loadGroup();
    this.loadEducation();
}

loadhighestDegree() {
  this.biodataService.getLookup('EduDegree')
    .subscribe(res => {
      this.highestDegreeList = res;
    });
}

loadResult() {
  this.biodataService.getLookup('EduResult')
    .subscribe(res => {
      this.ResultList = res;
    });
}

loadGroup() {
  this.biodataService.getLookup('EduGroup')
    .subscribe(res => {
      this.groupList = res;
    });
}
  onSave() {
  const payload: Education = {
    ...this.eduData,
    userId: this.authService.getUser().id
  };

  this.biodataService.saveEducation(payload)
    .subscribe(() => {
      alert('শিক্ষাগত তথ্য সংরক্ষিত হয়েছে ✅');
    });
}

loadEducation() {
  const userId = this.authService.getUser().id;
  debugger;
  this.biodataService.getEducationByUserId(userId)
    .subscribe(res => {
      if (res) {
        this.eduData = res;
      }
    });
}

}
