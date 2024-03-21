import { TestBed } from '@angular/core/testing';

import { WordToNumberService } from './word-to-number.service';

describe('WordToNumberService', () => {
  let service: WordToNumberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WordToNumberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
