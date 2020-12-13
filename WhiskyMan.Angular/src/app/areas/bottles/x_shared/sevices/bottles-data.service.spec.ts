import { TestBed } from '@angular/core/testing';

import { BottlesDataService } from './bottles-data.service';

describe('BottlesDataService', () => {
  let service: BottlesDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BottlesDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
