import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../Services/category.service';
import { Observable } from 'rxjs';
import { Category } from '../Models/Category.model';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories$?: Observable<Category[]>;

  constructor(private categoryservice: CategoryService) {
  }
  ngOnInit(): void {
    this.categories$ = this.categoryservice.getAllCategories();
   
  }

}
