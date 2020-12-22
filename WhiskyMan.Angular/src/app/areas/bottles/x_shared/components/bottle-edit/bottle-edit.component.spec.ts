import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottleEditComponent } from './bottle-edit.component';

describe('BottleEditComponent', () => {
  let component: BottleEditComponent;
  let fixture: ComponentFixture<BottleEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottleEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottleEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
