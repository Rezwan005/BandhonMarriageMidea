import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';
import { DataLookup } from '../model/lookup.model';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent {
  
  constructor(
    private router: Router,
      private biodataService: BiodataService,
      private authService: AuthService
    ) {}
    filters = {
    biodataType: '',
    country: '',
    age: ''
  };
 BiodataTypeList: DataLookup[] = [];
  MeritalStatusList: DataLookup[] = [];
  ngOnInit(): void {
      this.loadmeritalstatus();
      this.loadbiodatatype();
    }

    loadbiodatatype() {
     this.biodataService.getLookup('BioDataType')
       .subscribe(res => this.BiodataTypeList = res);
   }

  loadmeritalstatus() {
    this.biodataService.getLookup('MaritalStatus')
      .subscribe(res => this.MeritalStatusList = res);
  }
  goToProfile() {
    this.router.navigate(['/profile']);
  }
 
  onSearch() {
    const g = this.filters.biodataType;
   
  }
}
