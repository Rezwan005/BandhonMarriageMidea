import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step9ResolutionComponent } from './step9-resolution.component';

describe('Step9ResolutionComponent', () => {
  let component: Step9ResolutionComponent;
  let fixture: ComponentFixture<Step9ResolutionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step9ResolutionComponent]
    });
    fixture = TestBed.createComponent(Step9ResolutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
