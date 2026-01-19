import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step10ContactComponent } from './step10-contact.component';

describe('Step10ContactComponent', () => {
  let component: Step10ContactComponent;
  let fixture: ComponentFixture<Step10ContactComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step10ContactComponent]
    });
    fixture = TestBed.createComponent(Step10ContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
