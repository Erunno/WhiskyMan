import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllListComponent } from './all-list.component';

describe('AllListComponent', () => {
  let component: AllListComponent;
  let fixture: ComponentFixture<AllListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
