import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseDto } from './course.model';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class CourseService {
  private apiUrl = environment.apis.default.url + '/api/app/course';
  private apiUrlByCategory = environment.apis.default.url + '/api/app/course/courses';

  constructor(private http: HttpClient) {}

  getByCategory(categoryId: string): Observable<CourseDto[]> {
    const params = new HttpParams().set('categoryId', categoryId);
    return this.http.get<CourseDto[]>(this.apiUrlByCategory, { params });
  }

  getAll(): Observable<CourseDto[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map(res => res.items)
    );
  }

  create(course: any) {
    return this.http.post<CourseDto>(this.apiUrl, course);
  }

  update(id: string, course: any) {
    return this.http.put<CourseDto>(`${this.apiUrl}/${id}`, course);
  }

  delete(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
