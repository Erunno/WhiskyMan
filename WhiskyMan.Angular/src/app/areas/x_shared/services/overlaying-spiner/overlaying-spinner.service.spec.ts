import { TestBed } from '@angular/core/testing';

import { OverlayingSpinnerService } from './overlaying-spinner.service';

describe('OverlayingSpinnerService', () => {
  let service: OverlayingSpinnerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OverlayingSpinnerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
