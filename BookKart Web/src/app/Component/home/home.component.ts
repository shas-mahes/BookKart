import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Books } from '../../Models/boots';
import { BooksService } from '../../Services/books.service';
import { MatListModule } from '@angular/material/list';
import { CategoryService } from '../../Services/category.service';
import { Category } from '../../Models/category';
import { MatDialog } from '@angular/material/dialog';
import { BookSummaryComponent } from '../book-summary/book-summary.component';
import { CartService } from '../../Services/cart.service';
import { Cart } from '../../Models/cart';
import { ActivatedRoute } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  books: Books[];
  bookData: Books[];
  categories: Category[];
  category: string;

  constructor(
    private bookService: BooksService,
    private categoryService: CategoryService,
    private cartService: CartService,
    public dialog: MatDialog,
    private route: ActivatedRoute
  ) {
    this.books = [];
    this.bookData = [];
    this.categories = [];
  }

  ngOnInit(): void {
    this.loadBooks();
    this.categoryService.getCategories().subscribe((response) => {
      if (response) {
        this.categories = response;
      }
    });
  }

  loadBooks() {
    this.bookService.getBooks().subscribe((response) => {
      if (response) {
        this.books = response;
        this.bookData = response;
      }
    });
    this.route.queryParams.subscribe((res) => {
      if (res['item']) {
        this.books = this.bookData.filter(
          (x) =>
            x.Title.toLowerCase().includes(res['item']) ||
            x.Author.toLowerCase().includes(res['item'])
        );
        this.category = '';
      } else {
        this.books = this.bookData;
        this.category = '';
      }
    });
  }

  openBookDetails(book: Books) {
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

  categoryFilter(value: string) {
    this.category = value;
    if (value != '') {
      this.books = this.bookData.filter((x) => x.Category.Categories == value);
    } else {
      this.books = this.bookData;
    }
  }
}
