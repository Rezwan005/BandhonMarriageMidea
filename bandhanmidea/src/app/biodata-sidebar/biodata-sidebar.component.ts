import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BiodataService } from '../_services/biodata.service';
import { AuthService } from '../_services/authService.service';

@Component({
  selector: 'app-biodata-sidebar',
  templateUrl: './biodata-sidebar.component.html',
  styleUrls: ['./biodata-sidebar.component.css']
})
export class BiodataSidebarComponent {
  isSidebarOpen = false;
  constructor(
    private router: Router, private route: ActivatedRoute,
    private biodataService: BiodataService,
    private authService: AuthService
  ) {}
  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }
  goToAcc() {
    this.router.navigate(['/dashboard/accinfo']);
  }
   goToBio() {
    this.router.navigate(['/dashboard/editbio/1']);
  }
}
