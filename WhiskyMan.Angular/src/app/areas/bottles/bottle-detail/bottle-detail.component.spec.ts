import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottleDetailComponent } from './bottle-detail.component';

describe('BottleDetailComponent', () => {
  let component: BottleDetailComponent;
  let fixture: ComponentFixture<BottleDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottleDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottleDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
