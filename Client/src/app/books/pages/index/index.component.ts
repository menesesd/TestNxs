import { Component, OnInit } from '@angular/core';
import { Book } from '../../interfaces/book.interface';

@Component({
  selector: 'app-book-index',
  templateUrl: './index.component.html',
  styles: [
  ]
})
export class IndexComponent implements OnInit {
  booksFound: Book[] = [];
  constructor() { }

  ngOnInit(): void {
  }

  resultSearch(listOfBooks : Book[]){
    this.booksFound = listOfBooks;
  }

}
