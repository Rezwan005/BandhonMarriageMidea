import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { BiodataProfile } from '../model/biodataprofile.model';
import { BiodataService } from '../_services/biodata.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile-list',
  templateUrl: './profilelist.component.html',
  styleUrls: ['./profilelist.component.css']
})
export class ProfileListComponent implements OnChanges {

  @Input() profiles: BiodataProfile[] = [];

  loading = false;
  errorMessage = '';

  constructor(  private router: Router,private biodataService: BiodataService) {}

  ngOnChanges(changes: SimpleChanges): void {
   
  }
goToBioDetails(bioNo: any) {

  if (!bioNo) {
    console.error('Biodata number is missing');
    return;
  }

  this.biodataService.StartBiodata().subscribe({
    next: res => {
      console.log('API response', res);

      // Navigate AFTER API success
      this.router.navigate(['/biodata', bioNo]);
    },
    error: err => {
      console.error('API error', err);
    }
  });
}


}
