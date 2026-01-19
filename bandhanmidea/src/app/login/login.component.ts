import { Component } from '@angular/core';
import { AuthService } from '../_services/authService.service';
import { GoogleLoginProvider, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { Router } from '@angular/router';
declare const google: any;
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {
     google: any;
  constructor(private authService: AuthService,  private socialAuthService: SocialAuthService,private router: Router) {}
  ngAfterViewInit(): void {
    google.accounts.id.initialize({
      client_id: '521492801604-ht2gj9q5k6ed5609p069a6bdl7vhvngn.apps.googleusercontent.com',
      callback: (response: any) => {
        // This is the JWT token
        const idToken = response.credential;

        this.authService.sendTokenToBackend(idToken)
          .subscribe(res => {
            localStorage.setItem('token', res.token);
            localStorage.setItem('user', JSON.stringify(res.user)); // ✅ store user
             this.router.navigate(['']); // ✅ redirect
          });
      }
    });

    google.accounts.id.renderButton(
      document.getElementById('googleBtn'),
      {
        theme: 'outline',
        size: 'large',
        width: 280
      }
    );
  }

}
