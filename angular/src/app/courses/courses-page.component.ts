import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from './course.service';
import { CourseDto } from './course.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastService } from '../shared/toast.service';

@Component({
  selector: 'app-courses-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './courses-page.component.html',
})
export class CoursesPageComponent {
  courses: CourseDto[] = [];
  loading = true;
  categoryId: string | null = null;

  // Modal state
  showModal = false;
  modalMode: 'add' | 'edit' = 'add';
  modalCourse: any = {};
  modalCourseId: string | null = null;
  modalError: string | null = null;
  deletingId: string | null = null;

  // Delete confirmation modal state
  showDeleteModal = false;
  courseToDelete: CourseDto | null = null;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService,
    private toast: ToastService
  ) {
    this.route.paramMap.subscribe(params => {
      this.categoryId = params.get('id');
      if (this.categoryId) {
        this.loadCourses();
      }
    });
  }

  loadCourses() {
    if (!this.categoryId) return;
    this.loading = true;
    this.courseService.getByCategory(this.categoryId).subscribe({
      next: data => {
        this.courses = data;
        this.loading = false;
      },
      error: () => this.loading = false
    });
  }

  openAddModal() {
    this.modalMode = 'add';
    this.modalCourse = {
      title: '', description: '', price: 0, courseType: '', seatsAvailable: 0, duration: 0,
      categoryId: this.categoryId, instructorId: '', startDate: '', endDate: '', thumbnail: ''
    };
    this.modalCourseId = null;
    this.modalError = null;
    this.showModal = true;
  }

  openEditModal(course: CourseDto) {
    this.modalMode = 'edit';
    this.modalCourse = { ...course };
    this.modalCourseId = course.id;
    this.modalError = null;
    this.showModal = true;
  }

  openDeleteModal(course: CourseDto) {
    this.showDeleteModal = true;
    this.courseToDelete = course;
  }

  confirmDeleteCourse() {
    if (!this.courseToDelete) return;
    this.deletingId = this.courseToDelete.id;
    this.courseService.delete(this.courseToDelete.id).subscribe({
      next: () => {
        this.deletingId = null;
        this.showDeleteModal = false;
        this.courseToDelete = null;
        this.toast.show('success', 'Course deleted successfully.');
        this.loadCourses();
      },
      error: () => {
        this.deletingId = null;
        this.toast.show('error', 'Failed to delete course.');
        alert('Failed to delete course.');
      }
    });
  }

  saveCourse() {
    if (!this.modalCourse.title || !this.modalCourse.description) {
      this.modalError = 'Title and description are required.';
      return;
    }
    this.modalError = null;
    if (this.modalMode === 'add') {
      this.courseService.create(this.modalCourse).subscribe({
        next: () => {
          this.showModal = false;
          this.toast.show('success', 'Course added successfully.');
          this.loadCourses();
        },
        error: () => {
          this.modalError = 'Failed to add course.';
          this.toast.show('error', 'Failed to add course.');
        }
      });
    } else if (this.modalMode === 'edit' && this.modalCourseId) {
      this.courseService.update(this.modalCourseId, this.modalCourse).subscribe({
        next: () => {
          this.showModal = false;
          this.toast.show('success', 'Course updated successfully.');
          this.loadCourses();
        },
        error: () => {
          this.modalError = 'Failed to update course.';
          this.toast.show('error', 'Failed to update course.');
        }
      });
    }
  }

  closeModal() {
    this.showModal = false;
    this.modalError = null;
  }

  closeDeleteModal() {
    this.showDeleteModal = false;
    this.courseToDelete = null;
  }
}
