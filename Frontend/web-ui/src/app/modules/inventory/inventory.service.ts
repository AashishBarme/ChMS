import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Inventory } from './inventory.model';
@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  private baseUrl = `http://localhost:5000/inventory`; // replace with your API base URL

  constructor(private http: HttpClient) { }

  // Create
  create(model: Inventory): Observable<Inventory> {
    return this.http.post<Inventory>(this.baseUrl, model).pipe(
      catchError(this.handleError)
    );
  }

  // Read
  list(): Observable<Inventory[]> {
    const url = `${this.baseUrl}/list`;
    return this.http.get<Inventory[]>(url).pipe(
      catchError(this.handleError)
    );
  }

  get(id: number): Observable<Inventory> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Inventory>(url).pipe(
      catchError(this.handleError)
    );
  }

  // Update
  update(model: Inventory): Observable<Inventory> {
    const url = `${this.baseUrl}`;
    return this.http.put<Inventory>(url, model).pipe(
      catchError(this.handleError)
    );
  }

  // Delete
  delete(id: number): Observable<void> {
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
