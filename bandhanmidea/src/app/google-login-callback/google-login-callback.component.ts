import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-google-login-callback',
  template: `<p>Logging in...</p>`
})
export class GoogleLoginCallbackComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit() {
    const temp = sessionStorage.getItem('tempGoogleLogin');
    if (temp) {
      const res = JSON.parse(temp);

      // Now it's safe to set localStorage
      localStorage.setItem('token', res.token);
      localStorage.setItem('user', JSON.stringify(res.user));

      // Clean up
      sessionStorage.removeItem('tempGoogleLogin');

      // Redirect to home
      this.router.navigate(['']);
    } else {
      // If no temp data, redirect to login
      this.router.navigate(['/login']);
    }
  }
}