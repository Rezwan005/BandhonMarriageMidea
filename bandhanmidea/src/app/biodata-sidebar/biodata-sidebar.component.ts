import { Component } from '@angular/core';

@Component({
  selector: 'app-biodata-sidebar',
  templateUrl: './biodata-sidebar.component.html',
  styleUrls: ['./biodata-sidebar.component.css']
})
export class BiodataSidebarComponent {
  isSidebarOpen = false;

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }
}
