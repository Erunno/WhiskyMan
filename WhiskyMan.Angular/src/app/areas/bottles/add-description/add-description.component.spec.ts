import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDescriptionComponent } from './add-description.component';

describe('AddDescriptionComponent', () => {
  let component: AddDescriptionComponent;
  let fixture: ComponentFixture<AddDescriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDescriptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
