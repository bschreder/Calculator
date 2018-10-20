import { BadRequestError } from 'src/common/error-handler/bad-request-error';
import { NotFoundError } from 'src/common/error-handler/not-found-error';
import { AppError } from 'src/common/error-handler/app-error';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ApiResponse } from 'src/common/model/apiResponse';


@Injectable()
export class DataService {
  headers: HttpHeaders;


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getAll(url) {
    return this.http.get<ApiResponse>(url).pipe(
      catchError(this.handleError));
  }

  create(url, resource) {
    return this.http.post<ApiResponse>(url, resource, {headers: this.headers}).pipe(
      catchError(this.handleError));
  }

  update(url, resource) {
    // this.http.put(this.url, JSON.stringify(put));
    return this.http.patch<ApiResponse>(url + '/' + resource.id, { isRead: true }).pipe(
      catchError(this.handleError));
  }

  delete(url, id) {
    return this.http.delete<ApiResponse>(url + '/' + id).pipe(
      catchError(this.handleError));
  }


  private handleError(error: HttpErrorResponse) {
    if (error.status === 400) {
      return Observable.throw(new BadRequestError(error));
    }

    if (error.status === 404) {
      return Observable.throw(new NotFoundError());
    }

    return Observable.throw(new AppError(error));
  }
}
