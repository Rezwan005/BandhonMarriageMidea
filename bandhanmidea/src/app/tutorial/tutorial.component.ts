import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';

@Component({
  selector: 'app-tutorial',
  templateUrl: './tutorial.component.html',
  styleUrls: ['./tutorial.component.css']
})
export class TutorialComponent {

  constructor(
        private router: Router,
        private biodataService: BiodataService,
        private authService: AuthService
  ) {}

   goToDashboard() {
    this.biodataService.StartBiodata().subscribe({
        next: res => {
          console.log('API response', res);
        },
        error: err => {
          console.error('API error', err);
        }
      });
    debugger
    this.router.navigate(['/dashboard/editbio']);
  }
}
