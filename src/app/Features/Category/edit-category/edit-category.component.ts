import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../Services/category.service';
import { Category } from '../Models/Category.model';
import { UpdateCategoryRequest } from '../Models/Update-category-request.model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  EditCategorySubscription?: Subscription;
  category?: Category

  constructor(private route: ActivatedRoute,
    private categoryservice: CategoryService,
    private router: Router) {
  }
  
  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          //get the data from the Api for this category id
          this.categoryservice.getCategoryById(this.id)
          .subscribe({
            next: (response) => {
              this.category = response;
            }
          });
        }
      }
    });
  }

  OnFormsubmit(): void {
    const updateCategoryRequest: UpdateCategoryRequest = {
      name: this.category?.name?? '',
      urlHandle: this.category?.urlHandle?? ''
    };

    // pass this object to service
    if (this.id) {
      this.EditCategorySubscription = this.categoryservice.updateCategory(this.id, updateCategoryRequest)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories');
        }
      });
    }
  }

  OnDelete(): void {
    if (this.id) {
      this.categoryservice.deleteCategory(this.id)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories');
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.EditCategorySubscription?.unsubscribe();
  }
}
