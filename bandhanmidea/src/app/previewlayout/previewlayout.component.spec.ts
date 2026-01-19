import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewlayoutComponent } from './previewlayout.component';

describe('PreviewlayoutComponent', () => {
  let component: PreviewlayoutComponent;
  let fixture: ComponentFixture<PreviewlayoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PreviewlayoutComponent]
    });
    fixture = TestBed.createComponent(PreviewlayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
