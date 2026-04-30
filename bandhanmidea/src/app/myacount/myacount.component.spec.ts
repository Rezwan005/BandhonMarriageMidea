import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyacountComponent } from './myacount.component';

describe('MyacountComponent', () => {
  let component: MyacountComponent;
  let fixture: ComponentFixture<MyacountComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyacountComponent]
    });
    fixture = TestBed.createComponent(MyacountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
