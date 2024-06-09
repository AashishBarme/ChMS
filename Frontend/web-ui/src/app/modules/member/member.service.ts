import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ListMember, Member } from './member.model';
@Injectable({
  providedIn: 'root'
})
export class MemberService {

  private baseUrl = `http://localhost:5000/member`; // replace with your API base URL

  constructor(private http: HttpClient) { }

  // Create
  create(member: Member): Observable<Member> {
    return this.http.post<Member>(this.baseUrl, member).pipe(
      catchError(this.handleError)
    );
  }

  // Read
  list(): Observable<ListMember[]> {
    const url = `${this.baseUrl}/list`;
    return this.http.get<ListMember[]>(url).pipe(
      catchError(this.handleError)
    );
  }

  get(id: string): Observable<Member> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Member>(url).pipe(
      catchError(this.handleError)
    );
  }

  // Update
  update(id: string, member: Member): Observable<Member> {
    const url = `${this.baseUrl}`;
    return this.http.put<Member>(url, member).pipe(
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
