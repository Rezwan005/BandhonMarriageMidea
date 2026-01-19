import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewBiodataComponent } from './preview-biodata.component';

describe('PreviewBiodataComponent', () => {
  let component: PreviewBiodataComponent;
  let fixture: ComponentFixture<PreviewBiodataComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PreviewBiodataComponent]
    });
    fixture = TestBed.createComponent(PreviewBiodataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
