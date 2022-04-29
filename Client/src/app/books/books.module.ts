import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { BooksRoutingModule } from './books-routing.module';


import { IndexComponent } from './pages/index/index.component';
import { SearchBookInputComponent } from './components/search-book-input/search-book-input.component';
import { ListBooksTableComponent } from './components/list-books-table/list-books-table.component';



@NgModule({
  declarations: [
    SearchBookInputComponent,
    ListBooksTableComponent,
    IndexComponent
  ],
  imports: [
    CommonModule,
    BooksRoutingModule,
    FormsModule 
  ]
})
export class BooksModule { }
