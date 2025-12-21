import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiodataSidebarComponent } from './biodata-sidebar.component';

describe('BiodataSidebarComponent', () => {
  let component: BiodataSidebarComponent;
  let fixture: ComponentFixture<BiodataSidebarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BiodataSidebarComponent]
    });
    fixture = TestBed.createComponent(BiodataSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
