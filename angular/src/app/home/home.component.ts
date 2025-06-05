import { AuthService, LocalizationModule } from '@abp/ng.core';
import { Component } from '@angular/core';
import { CategoryService } from '../categories/category.service';
import { CategoryDto } from '../categories/category.model';
import { CategoryListComponent } from '../categories/category-list.component';

@Component({
  standalone: true,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  imports: [CategoryListComponent, LocalizationModule]
})
export class HomeComponent {
  categories: CategoryDto[] = [];
  loadingCategories = true;

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(private authService: AuthService, private categoryService: CategoryService) {
    this.loadCategories();
  }

  loadCategories() {
    this.loadingCategories = true;
    this.categoryService.getList().subscribe({
      next: (data) => {
        this.categories = data;
        this.loadingCategories = false;
      },
      error: () => {
        this.loadingCategories = false;
      }
    });
  }

  login() {
    this.authService.navigateToLogin();
  }
}
