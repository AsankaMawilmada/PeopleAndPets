import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CatService {
  path = 'cats';
  constructor(private apiService: ApiService) {}

  getCatsGrouped(): Observable<any[]> {
    return this.apiService.get(`${this.path}/grouped`)
      .pipe(map((data) => data));
  }
}
