import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BiodataDetailsComponent } from './biodata-details.component';

describe('BiodataDetailsComponent', () => {
  let component: BiodataDetailsComponent;
  let fixture: ComponentFixture<BiodataDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BiodataDetailsComponent]
    });
    fixture = TestBed.createComponent(BiodataDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
