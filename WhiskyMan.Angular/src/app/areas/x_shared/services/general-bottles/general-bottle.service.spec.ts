import { TestBed } from '@angular/core/testing';

import { GeneralBottleService } from './general-bottle.service';

describe('GeneralBottleService', () => {
  let service: GeneralBottleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneralBottleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
