import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BiodataService } from '../_services/biodata.service';

@Component({
  selector: 'app-profilepage',
  templateUrl: './profilepage.component.html',
  styleUrls: ['./profilepage.component.css']
})
export class ProfilepageComponent implements OnInit {

  isFilterOpen = false;
  profiles: any[] = [];

  filters: any = {
    biodataType: null,
    country: '',
    maritalStatus: null
  };

  constructor(
    private route: ActivatedRoute,
    private biodataService: BiodataService
  ) {}

  ngOnInit(): void {
    debugger;
    // ✅ Read filters from Home page
    this.route.queryParams.subscribe(params => {
      this.filters = {
        biodataType: params['biodataType'] || null,
        country: params['country'] || '',
        maritalStatus: params['maritalStatus'] || null
      };

      this.loadProfiles(this.filters);
    });
  }

  toggleFilter() {
    this.isFilterOpen = !this.isFilterOpen;
  }

  loadProfiles(filters: any) {
    this.biodataService.getProfilesByUserId(filters)
      .subscribe(res => {
        this.profiles = res.data;
      });
  }
}
