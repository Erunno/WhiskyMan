import { TestBed } from '@angular/core/testing';

import { OverlyingAlertService } from './overlying-alert.service';

describe('OverlyingAlertService', () => {
  let service: OverlyingAlertService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OverlyingAlertService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
