import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottleDescriptionEditComponent } from './bottle-description-edit.component';

describe('BottleDescriptionEditComponent', () => {
  let component: BottleDescriptionEditComponent;
  let fixture: ComponentFixture<BottleDescriptionEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottleDescriptionEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottleDescriptionEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
