import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiodataGeneralInfoComponent } from './biodata-general-info.component';

describe('BiodataGeneralInfoComponent', () => {
  let component: BiodataGeneralInfoComponent;
  let fixture: ComponentFixture<BiodataGeneralInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BiodataGeneralInfoComponent]
    });
    fixture = TestBed.createComponent(BiodataGeneralInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
