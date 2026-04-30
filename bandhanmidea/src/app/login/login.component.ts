import { Component, NgZone } from '@angular/core';
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
  constructor(private authService: AuthService,  private socialAuthService: SocialAuthService,private router: Router,private ngZone: NgZone) {}
  ngAfterViewInit(): void {
    google.accounts.id.initialize({
   // client_id: '521492801604-hj8uabij1uhn1mqrgha7beglcvsjv5or.apps.googleusercontent.com',
   //Local ------->
   client_id: '521492801604-hj8uabij1uhn1mqrgha7beglcvsjv5or.apps.googleusercontent.com',
    itp_support: true,
    
    callback: (response: any) => {
      // 3. Wrap everything in ngZone
      this.ngZone.run(() => {
        this.authService.sendTokenToBackend(response.credential).subscribe({

          
          next: (res) => {
                      console.log(res);
            localStorage.setItem('token', res.token);
            localStorage.setItem('user', JSON.stringify(res.user));
            this.router.navigate(['/']); 
          },
          error: (err) => console.error("Backend Error:", err)
        });
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
