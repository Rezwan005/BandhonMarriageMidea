import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Biodata } from '../model/biodata.model';
import { GoogleLoginProvider, SocialAuthService } from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

   apiUrl = environment.apiUrl;
  constructor(
    private http: HttpClient,
    private socialAuth: SocialAuthService
  ) {}

  googleSignIn() {
    return this.socialAuth.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  sendTokenToBackend(idToken: string) {
    return this.http.post<any>(`${this.apiUrl}/auth/google`, {
      idToken
    });
  }

   getUser() {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  }
}
