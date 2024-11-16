import { Component, Inject, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogModule,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { BooksService } from '../../Services/books.service';
import { Books } from '../../Models/boots';
import { Cart } from '../../Models/cart';
import { CartService } from '../../Services/cart.service';

@Component({
  selector: 'app-book-summary',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatCardModule, MatIconModule],
  templateUrl: './book-summary.component.html',
  styleUrl: './book-summary.component.scss',
})
export class BookSummaryComponent implements OnInit {
  book: Books;
  suggestedBooks: Books[];

  constructor(
    @Inject(MAT_DIALOG_DATA)
    private bookId: any,
    private bookService: BooksService,
    public dialog: MatDialog,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.bookService.getBooks().subscribe((response) => {
      if (response) {
        this.suggestedBooks = response;
      }
    });
    this.bookService.getBookById(this.bookId).subscribe((res) => {
      this.book = res;
    });
  }

  openBookDetails(book: Books) {
    this.dialog.closeAll();
    const dialogRef = this.dialog.open(BookSummaryComponent, {
      data: book.Id,
    });
  }

  addToCart(book: Books) {
    this.cartService.getCartForUser(1).subscribe((response) => {
      if (response.ResponseCode == 'Success') {
        var bookExistInCart = response.Data.find(
          (x: Cart) => x.BookId == book.Id
        );
        if (bookExistInCart != undefined) {
          let data = bookExistInCart;
          const cart = this.createCartForUser(bookExistInCart.Books, data);
          this.cartService.addOrUpdateCart(cart).subscribe((response) => {
            if (response.ResponseCode == 'Success') {
              console.log('Book Quantity Updated');
            }
          });
        } else {
          let data = undefined;
          const cart = this.createCartForUser(book, data);
          this.cartService.addOrUpdateCart(cart).subscribe((response) => {
            if (response.ResponseCode == 'Success') {
              console.log('New Book added to cart');
            }
          });
        }
      } else if (
        response.ResponseCode == 'Error' &&
        response.Message == 'Cart is empty'
      ) {
        let data = undefined;
        const cart = this.createCartForUser(book, data);
        this.cartService.addOrUpdateCart(cart).subscribe((response) => {
          if (response.ResponseCode == 'Success') {
            console.log('New Book added to cart');
          }
        });
      }
    });
  }

  createCartForUser(book: Books, data: any) {
    const cartObj = {} as Cart;
    cartObj.BookId = book.Id;
    cartObj.UserId = 1;
    cartObj.Id = data ? data.Id : 0;
    cartObj.CreatedBy = data ? data.CreatedBy : 'System';
    cartObj.CreatedDate = data ? data.CreatedDate : new Date();
    cartObj.Quantity = data ? data.Quantity + 1 : 1;
    return cartObj;
  }
}
