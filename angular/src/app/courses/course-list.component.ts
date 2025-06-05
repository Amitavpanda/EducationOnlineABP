import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseDto } from './course.model';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent {
  @Input() courses: CourseDto[] = [];
  @Input() loading = false;
}
