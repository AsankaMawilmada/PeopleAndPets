/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CatService } from './cat.service';

describe('Service: Cat', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        CatService,
        { provide: 'BASE_URL ', useValue: "http://example.com/api" }
      ]
    });
  });

  it('should ...', inject([CatService], (service: CatService) => {
    expect(service).toBeTruthy();
  }));
});
