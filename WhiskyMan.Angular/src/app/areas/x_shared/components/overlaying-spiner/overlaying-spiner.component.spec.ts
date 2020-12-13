import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OverlayingSpinerComponent } from './overlaying-spiner.component';

describe('OverlayingSpinerComponent', () => {
  let component: OverlayingSpinerComponent;
  let fixture: ComponentFixture<OverlayingSpinerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OverlayingSpinerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OverlayingSpinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
