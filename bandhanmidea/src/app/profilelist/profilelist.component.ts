import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { BiodataProfile } from '../model/biodataprofile.model';
import { BiodataService } from '../_services/biodata.service';

@Component({
  selector: 'app-profile-list',
  templateUrl: './profilelist.component.html',
  styleUrls: ['./profilelist.component.css']
})
export class ProfileListComponent implements OnChanges {

  @Input() profiles: BiodataProfile[] = [];

  loading = false;
  errorMessage = '';

  constructor(private biodataService: BiodataService) {}

  ngOnChanges(changes: SimpleChanges): void {
   
  }


}
