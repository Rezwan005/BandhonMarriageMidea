import { Component } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent {
    constructor(private router: Router) {}
    filters = {
    gender: 'female',
    country: '',
    age: ''
  };
  goToProfile() {
    this.router.navigate(['/profile']);
  }
 
  onSearch() {
    const g = this.filters.gender;
   
  }
}
