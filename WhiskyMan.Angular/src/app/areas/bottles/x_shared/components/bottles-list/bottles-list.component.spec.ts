import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottlesListComponent } from './bottles-list.component';

describe('BottlesListComponent', () => {
  let component: BottlesListComponent;
  let fixture: ComponentFixture<BottlesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottlesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BottlesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
