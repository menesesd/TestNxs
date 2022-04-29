import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Book } from '../interfaces/book.interface';


@Injectable({
  providedIn: 'root'
})
export class BooksService {
  url = environment.api + 'books/';

  constructor(private httpClient: HttpClient) { }
  
  getAllBooks() {
    return this.httpClient.get<Book[]>(this.url);
  }

  getBookByFilter(filter:string) {
    return this.httpClient.get<Book[]>(this.url+'filter/',{params:{filter}});
  }
}
