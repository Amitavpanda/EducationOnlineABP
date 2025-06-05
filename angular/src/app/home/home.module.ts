import { NgModule } from '@angular/core';
import { PageModule } from '@abp/ng.components/page';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { CategoryListComponent } from '../categories/category-list.component';

@NgModule({
  imports: [SharedModule, HomeRoutingModule, PageModule, CategoryListComponent, HomeComponent],
})
export class HomeModule {}
