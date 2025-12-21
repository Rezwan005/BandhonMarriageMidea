import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tutorial',
  templateUrl: './tutorial.component.html',
  styleUrls: ['./tutorial.component.css']
})
export class TutorialComponent {
      constructor(private router: Router) {}
   goToDashboard() {
    debugger
    this.router.navigate(['/dashboard/editbio']);
  }
}
