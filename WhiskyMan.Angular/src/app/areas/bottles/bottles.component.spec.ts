import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottlesComponent } from './bottles.component';

describe('BottlesComponent', () => {
  let component: BottlesComponent;
  let fixture: ComponentFixture<BottlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottlesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
