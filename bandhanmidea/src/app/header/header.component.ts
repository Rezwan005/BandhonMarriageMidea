import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/authService.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  isMenuOpen = false;
  userName: string | null = null;

  constructor(
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    const user = this.authService.getUser();
    this.userName = user ? user.name : null;
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  logout() {
    this.authService.logout();
      window.location.href = '/';
  }
 
}
