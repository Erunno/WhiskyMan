import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottleDescriptionDetailComponent } from './bottle-description-detail.component';

describe('BottleDescriptionDetailComponent', () => {
  let component: BottleDescriptionDetailComponent;
  let fixture: ComponentFixture<BottleDescriptionDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottleDescriptionDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottleDescriptionDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
