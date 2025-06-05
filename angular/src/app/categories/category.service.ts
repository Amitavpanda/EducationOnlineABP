import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CategoryDto } from './category.model';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private apiUrl = environment.apis.default.url + '/api/app/course-category';

  constructor(private http: HttpClient) {}

  getList(): Observable<CategoryDto[]> {
    return this.http.get<{ items: CategoryDto[] }>(this.apiUrl).pipe(
      map(response => response.items)
    );
  }

  create(body: Partial<CategoryDto>): Observable<any> {
    return this.http.post(this.apiUrl, body);
  }

  update(id: string, body: Partial<CategoryDto>): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, body);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
