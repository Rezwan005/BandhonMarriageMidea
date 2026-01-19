import { Component, EventEmitter, Output } from '@angular/core';
import { DataLookup } from '../model/lookup.model';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FiltersComponent {

  @Output() filterChanged = new EventEmitter<any>();

  filters = {
    biodataNo: '',
    biodataType: '',
    maritalStatus: '',
    ageMin: 18,
    ageMax: 60
  };
  BiodataTypeList: DataLookup[] = [];
  MeritalStatusList: DataLookup[] = [];
    constructor(
      private biodataService: BiodataService,
      private authService: AuthService
    ) {}
  
    ngOnInit(): void {
 
      this.loadbiodatatype();
      this.loadmeritalstatus();
    
    }
  emitChanges() {
    this.filterChanged.emit(this.filters);
  }
   loadbiodatatype() {
    this.biodataService.getLookup('BioDataType')
      .subscribe(res => this.BiodataTypeList = res);
  }

  loadmeritalstatus() {
    this.biodataService.getLookup('MaritalStatus')
      .subscribe(res => this.MeritalStatusList = res);
  }
  onSearch() {
  this.filterChanged.emit(this.filters);
}
}
