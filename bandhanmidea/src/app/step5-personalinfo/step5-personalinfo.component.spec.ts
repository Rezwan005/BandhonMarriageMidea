import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step5PersonalinfoComponent } from './step5-personalinfo.component';

describe('Step5PersonalinfoComponent', () => {
  let component: Step5PersonalinfoComponent;
  let fixture: ComponentFixture<Step5PersonalinfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step5PersonalinfoComponent]
    });
    fixture = TestBed.createComponent(Step5PersonalinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
