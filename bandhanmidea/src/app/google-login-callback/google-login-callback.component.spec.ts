import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoogleLoginCallbackComponent } from './google-login-callback.component';

describe('GoogleLoginCallbackComponent', () => {
  let component: GoogleLoginCallbackComponent;
  let fixture: ComponentFixture<GoogleLoginCallbackComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GoogleLoginCallbackComponent]
    });
    fixture = TestBed.createComponent(GoogleLoginCallbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
