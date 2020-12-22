import { TestBed } from '@angular/core/testing';

import { GeneralUserService } from './general-user.service';

describe('GeneralUserService', () => {
  let service: GeneralUserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneralUserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
