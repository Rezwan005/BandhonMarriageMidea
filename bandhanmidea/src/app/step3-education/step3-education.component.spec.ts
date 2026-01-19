import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step3EducationComponent } from './step3-education.component';

describe('Step3EducationComponent', () => {
  let component: Step3EducationComponent;
  let fixture: ComponentFixture<Step3EducationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step3EducationComponent]
    });
    fixture = TestBed.createComponent(Step3EducationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
