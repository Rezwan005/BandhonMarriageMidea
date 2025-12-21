import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './profilepage.component.html',
  styleUrls: ['./profilepage.component.css']
})
export class ProfilepageComponent {

  isFilterOpen = false;
  activeFilters: any = {};

  toggleFilter() {
    this.isFilterOpen = !this.isFilterOpen;
  }

  applyFilters(filters: any) {
    this.activeFilters = filters;
  }
}
