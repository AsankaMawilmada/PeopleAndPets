import { HttpClient, HttpParams,  HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  API_BASE_URL = '';
  constructor(private http: HttpClient,
    private notificationService: NotificationService
  ) {
    this.API_BASE_URL = `api/`;
  }

  private formatErrors(error: HttpErrorResponse) {
    switch (error.status) {
      case 0:
        this.notificationService.error('There was an error encountered while establishing the connection to server, please check if server is running or application pointing to correct server.');
        break;
      case 500:
        this.notificationService.error('There was an error processing your request please try again later or contact support.');
        break;
      case 400:
        this.notificationService.error('Validation errors occurred please confirm the fields and submit it again.');
        break;
      case 422:
        this.notificationService.error('Validation errors occurred please confirm the fields and submit it again.');
        break;
      case 401:
        this.notificationService.error('Your session expired, please login again.');
        break;
      default:
        break;
    }

    return throwError(error.error);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http
      .get(`${this.API_BASE_URL}${path}`, { params })
      .pipe(catchError(this.formatErrors));
  }
}
