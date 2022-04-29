import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import Swal from 'sweetalert2';
import { Book } from '../../interfaces/book.interface';
import { BooksService } from '../../services/books.service';




@Component({
  selector: 'app-books-search-book-input',
  templateUrl: './search-book-input.html',
  styles: [
  ]
})
export class SearchBookInputComponent implements OnInit {
  title = 'Nexos Text';
  filter = '';
  booksFound: Book[] = [];
  constructor(private _booksService: BooksService ) { }

  ngOnInit(): void {
  } 

  @Output() resultSearch:EventEmitter<Book[]> = new EventEmitter();

  searchBookByFilter() {
  if(!this.filter || this.filter.trim() == ''){
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: 'Debe ingresar el año, el título o el autor del libro para realizar la busqueda'
    })
    return;
  }

    this._booksService.getBookByFilter(this.filter).subscribe(
      (data) => {      
        this.booksFound = data;
        this.resultSearch.emit(this.booksFound);
        if(data.length === 0){
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'No se encontraron resultado'
          })
          return;
        }
      },
      ()=>{
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Error al procesar la solitud, Por favor contacte al administrador'
        })
      }
    )
  }

}
