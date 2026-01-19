import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step4FamilyinfoComponent } from './step4-familyinfo.component';

describe('Step4FamilyinfoComponent', () => {
  let component: Step4FamilyinfoComponent;
  let fixture: ComponentFixture<Step4FamilyinfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step4FamilyinfoComponent]
    });
    fixture = TestBed.createComponent(Step4FamilyinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
