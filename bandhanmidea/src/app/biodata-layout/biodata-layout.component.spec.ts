import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiodataLayoutComponent } from './biodata-layout.component';

describe('BiodataLayoutComponent', () => {
  let component: BiodataLayoutComponent;
  let fixture: ComponentFixture<BiodataLayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BiodataLayoutComponent]
    });
    fixture = TestBed.createComponent(BiodataLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
