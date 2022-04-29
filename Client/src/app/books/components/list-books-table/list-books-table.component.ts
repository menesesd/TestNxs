import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../../interfaces/book.interface';

@Component({
  selector: 'app-book-list-books-table',
  templateUrl: './list-books-table.html',
  styles: [
  ]
})
export class ListBooksTableComponent implements OnInit {
  @Input('listOfBooks') booksFound: Book[] = [];
  constructor() { }

  ngOnInit(): void {
  }

}
