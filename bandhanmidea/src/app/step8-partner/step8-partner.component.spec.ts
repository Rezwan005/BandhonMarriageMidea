import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step8PartnerComponent } from './step8-partner.component';

describe('Step8PartnerComponent', () => {
  let component: Step8PartnerComponent;
  let fixture: ComponentFixture<Step8PartnerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step8PartnerComponent]
    });
    fixture = TestBed.createComponent(Step8PartnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
