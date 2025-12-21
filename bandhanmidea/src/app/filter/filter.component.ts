import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-filters',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FiltersComponent {

  @Output() filterChanged = new EventEmitter<any>();

  filters = {
    searchFor: '',
    maritalStatus: '',
    ageMin: 18,
    ageMax: 60
  };

  emitChanges() {
    this.filterChanged.emit(this.filters);
  }
}
