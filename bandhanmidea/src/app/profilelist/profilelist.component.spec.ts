import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilelistComponent } from './profilelist.component';

describe('ProfilelistComponent', () => {
  let component: ProfilelistComponent;
  let fixture: ComponentFixture<ProfilelistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProfilelistComponent]
    });
    fixture = TestBed.createComponent(ProfilelistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
