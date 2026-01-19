import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Step6JobinfoComponent } from './step6-jobinfo.component';

describe('Step6JobinfoComponent', () => {
  let component: Step6JobinfoComponent;
  let fixture: ComponentFixture<Step6JobinfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [Step6JobinfoComponent]
    });
    fixture = TestBed.createComponent(Step6JobinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
