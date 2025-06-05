import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryDto } from './category.model';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent {
  @Input() categories: CategoryDto[] = [];
  @Input() loading = false;

  constructor(private router: Router) {}

  viewCourses(categoryId: string) {
    this.router.navigate(['/courses', categoryId]);
  }
}
