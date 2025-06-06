import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class InstructorService {
  private apiUrl = 'https://localhost:44382/api/app/instructor';

  constructor(private http: HttpClient) {}

  getInstructors(): Observable<any[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map(res => res.items)
    );
  }
}
