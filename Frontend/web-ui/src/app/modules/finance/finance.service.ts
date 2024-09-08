import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AddIncome, FilterVm, Income, ListIncome } from './finance.model';
import { catchError, Observable, throwError } from 'rxjs';
import { Helpers } from 'src/app/helpers/Helpers';

@Injectable({
  providedIn: 'root'
})
export class FinanceService {

  private baseUrl = `${environment.ApiUrl}/income`; // replace with your API base URL

  constructor(private http: HttpClient) { }

  // Create
  createIncome(model: any): Observable<AddIncome> {
    return this.http.post<AddIncome>(this.baseUrl, model).pipe(
      catchError(this.handleError)
    );
  }

  // Read
  listIncome(filter: FilterVm): Observable<ListIncome[]> {
    let searchQuery = Helpers.ParseFilterVmToUrl(filter);
    const url = `${this.baseUrl}/list/${searchQuery}`;
    return this.http.get<ListIncome[]>(url).pipe(
      catchError(this.handleError)
    );
  }

  getIncome(id: any): Observable<AddIncome> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<AddIncome>(url).pipe(
      catchError(this.handleError)
    );
  }

  // Update
  updateIncome(model: any): Observable<Income[]> {
    const url = `${this.baseUrl}`;
    return this.http.put<Income[]>(url, model).pipe(
      catchError(this.handleError)
    );
  }

  // Delete
  deleteIncome(id: number): Observable<void> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<void>(url).pipe(
      catchError(this.handleError)
    );
  }
  // Error Handling
  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Client-side or network error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Backend error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
