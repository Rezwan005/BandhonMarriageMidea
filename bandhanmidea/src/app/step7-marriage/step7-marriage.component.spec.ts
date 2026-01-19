import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step7MarriageComponent } from './step7-marriage.component';

describe('Step7MarriageComponent', () => {
  let component: Step7MarriageComponent;
  let fixture: ComponentFixture<Step7MarriageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step7MarriageComponent]
    });
    fixture = TestBed.createComponent(Step7MarriageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
