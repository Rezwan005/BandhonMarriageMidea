import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step2AddressComponent } from './step2-address.component';

describe('Step2AddressComponent', () => {
  let component: Step2AddressComponent;
  let fixture: ComponentFixture<Step2AddressComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step2AddressComponent]
    });
    fixture = TestBed.createComponent(Step2AddressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
