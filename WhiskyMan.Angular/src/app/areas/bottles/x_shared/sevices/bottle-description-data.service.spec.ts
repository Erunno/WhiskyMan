import { TestBed } from '@angular/core/testing';

import { BottleDescriptionDataService } from './bottle-description-data.service';

describe('BottleDescriptionService', () => {
  let service: BottleDescriptionDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BottleDescriptionDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
