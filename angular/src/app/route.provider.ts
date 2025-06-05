import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
    {
      path: '/',
      name: '::Menu:Home',
      iconClass: 'fas fa-home',
      order: 1,
      layout: eLayoutType.application,
    },
    {
      name: '::Menu:Courses',
      iconClass: 'fas fa-book-open',
      order: 2,
      layout: eLayoutType.application,
    },
    {
      path: '/categories',
      name: '::Menu:AllCategories',
      iconClass: 'fas fa-th-list',
      order: 1,
      parentName: '::Menu:Courses',
      layout: eLayoutType.application,
    },
    {
      path: '/enrollments',
      name: '::Menu:Enrollments',
      iconClass: 'fas fa-user-graduate',
      order: 2,
      parentName: '::Menu:Courses',
      layout: eLayoutType.application,
    },
    {
      path: '/all-courses',
      name: '::Menu:AllCourses',
      iconClass: 'fas fa-list-alt',
      order: 3,
      parentName: '::Menu:Courses',
      layout: eLayoutType.application,
    },
    {
      path: '/plan-and-pricing',
      name: '::Menu:PlanAndPricing',
      iconClass: 'fas fa-tags',
      order: 3,
      layout: eLayoutType.application,
    },
    {
      path: '/contact-us',
      name: '::Menu:ContactUs',
      iconClass: 'fas fa-envelope',
      order: 4,
      layout: eLayoutType.application,
    },
    {
      path: '/about-us',
      name: '::Menu:AboutUs',
      iconClass: 'fas fa-info-circle',
      order: 5,
      layout: eLayoutType.application,
    }
  ]);
}
