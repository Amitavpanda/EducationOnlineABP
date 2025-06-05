import { Component } from '@angular/core';
import { CategoryService } from './category.service';
import { CategoryDto } from './category.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastService } from '../shared/toast.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './categories-page.component.html',
  styleUrls: ['./categories-page.component.scss']
})
export class CategoriesPageComponent {
  categories: CategoryDto[] = [];
  loading = true;

  // Modal state
  showModal = false;
  modalMode: 'add' | 'edit' = 'add';
  modalCategory: Partial<CategoryDto> = { categoryName: '', description: '' };
  modalCategoryId: string | null = null;
  modalError: string | null = null;
  deletingId: string | null = null;

  constructor(private categoryService: CategoryService, private toast: ToastService, private router: Router) {
    this.loadCategories();
  }

  loadCategories() {
    this.loading = true;
    this.categoryService.getList().subscribe({
      next: (data) => {
        this.categories = data;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  openAddModal() {
    this.modalMode = 'add';
    this.modalCategory = { categoryName: '', description: '' };
    this.modalCategoryId = null;
    this.modalError = null;
    this.showModal = true;
  }

  openEditModal(category: CategoryDto) {
    this.modalMode = 'edit';
    this.modalCategory = { categoryName: category.categoryName, description: category.description };
    this.modalCategoryId = category.id;
    this.modalError = null;
    this.showModal = true;
  }

  saveCategory() {
    if (!this.modalCategory.categoryName || !this.modalCategory.description) {
      this.modalError = 'Both fields are required.';
      return;
    }
    this.modalError = null;
    if (this.modalMode === 'add') {
      this.categoryService.create(this.modalCategory).subscribe({
        next: () => {
          this.showModal = false;
          this.toast.show('success', 'Category added successfully.');
          this.loadCategories();
        },
        error: () => {
          this.modalError = 'Failed to add category.';
          this.toast.show('error', 'Failed to add category.');
        }
      });
    } else if (this.modalMode === 'edit' && this.modalCategoryId) {
      this.categoryService.update(this.modalCategoryId, this.modalCategory).subscribe({
        next: () => {
          this.showModal = false;
          this.toast.show('success', 'Category updated successfully.');
          this.loadCategories();
        },
        error: () => {
          this.modalError = 'Failed to update category.';
          this.toast.show('error', 'Failed to update category.');
        }
      });
    }
  }

  deleteCategory(category: CategoryDto) {
    if (!confirm('Are you sure you want to delete this category?')) return;
    this.deletingId = category.id;
    this.categoryService.delete(category.id).subscribe({
      next: () => {
        this.deletingId = null;
        this.toast.show('success', 'Category deleted successfully.');
        this.loadCategories();
      },
      error: () => {
        this.deletingId = null;
        this.toast.show('error', 'Failed to delete category.');
        alert('Failed to delete category.');
      }
    });
  }

  viewCourses(categoryId: string) {
    this.router.navigate(['/courses', categoryId]);
  }

  closeModal() {
    this.showModal = false;
    this.modalError = null;
  }
}
