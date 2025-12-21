import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-profile-list',
  templateUrl: './profilelist.component.html',
  styleUrls: ['./profilelist.component.css']
})
export class ProfileListComponent implements OnChanges {

  @Input() filters: any = {};

  profiles = [
    { code: 'ODM-20182', age: 26, height: "5'4\"", job: 'শিক্ষক', gender: 'male', marital: 'single', avatar: 'assets/Img/male.jpg' },
    { code: 'ODF-21087', age: 28, height: "5'", job: 'গৃহিণী', gender: 'female', marital: 'single', avatar: 'assets/Img/female.png' },
      { code: 'ODM-20182', age: 26, height: "5'4\"", job: 'শিক্ষক', gender: 'male', marital: 'single', avatar: 'assets/Img/male.jpg' },
    { code: 'ODF-21087', age: 28, height: "5'", job: 'গৃহিণী', gender: 'female', marital: 'single', avatar: 'assets/Img/female.png' },
      { code: 'ODM-20182', age: 26, height: "5'4\"", job: 'শিক্ষক', gender: 'male', marital: 'single', avatar: 'assets/Img/male.jpg' },
    { code: 'ODF-21087', age: 28, height: "5'", job: 'গৃহিণী', gender: 'female', marital: 'single', avatar: 'assets/Img/female.png' },
      { code: 'ODM-20182', age: 26, height: "5'4\"", job: 'শিক্ষক', gender: 'male', marital: 'single', avatar: 'assets/Img/male.jpg' },
    { code: 'ODF-21087', age: 28, height: "5'", job: 'গৃহিণী', gender: 'female', marital: 'single', avatar: 'assets/Img/female.png' },
  ];

  filteredProfiles = [...this.profiles];

  ngOnChanges() {
    this.applyFilter();
  }

  applyFilter() {
    this.filteredProfiles = this.profiles.filter(p => {
      this.filters.ageMin =18;
      this.filters.ageMax = 40
      return (!this.filters.searchFor || p.gender === this.filters.searchFor)
        && (!this.filters.maritalStatus || p.marital === this.filters.maritalStatus)
        && (p.age >= this.filters.ageMin && p.age <= this.filters.ageMax);
    });
  }
}
