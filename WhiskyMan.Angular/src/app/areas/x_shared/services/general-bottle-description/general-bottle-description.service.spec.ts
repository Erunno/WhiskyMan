import { TestBed } from '@angular/core/testing';

import { GeneralBottleDescriptionService } from './general-bottle-description.service';

describe('GeneralBottleDescriptionService', () => {
  let service: GeneralBottleDescriptionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneralBottleDescriptionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
