import { Component } from '@angular/core';
import { BiodataService } from '../_services/biodata.service';

@Component({
  selector: 'app-home',
  templateUrl: './profilepage.component.html',
  styleUrls: ['./profilepage.component.css']
})
export class ProfilepageComponent {
  isFilterOpen = false;
  profiles: any[] = [];

  constructor(private biodataService: BiodataService) {}

  toggleFilter() {
    this.isFilterOpen = !this.isFilterOpen;
  }

  loadProfiles(filters: any) {
    this.biodataService.getProfilesByUserId(filters).subscribe(res => {
      this.profiles = res.data;   // ✅ update list
    });
  }
}


