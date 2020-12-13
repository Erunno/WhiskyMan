import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottleViewCardComponent } from './bottle-view-card.component';

describe('BottleViewCardComponent', () => {
  let component: BottleViewCardComponent;
  let fixture: ComponentFixture<BottleViewCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottleViewCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottleViewCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
