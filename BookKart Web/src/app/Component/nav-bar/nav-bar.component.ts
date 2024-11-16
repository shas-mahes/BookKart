import { Component, OnInit } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatMenuModule } from '@angular/material/menu';
import { Router } from '@angular/router';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { BooksService } from '../../Services/books.service';
import { Books } from '../../Models/boots';
import { map, Observable, startWith } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    MatFormFieldModule,
    MatMenuModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
  ],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
})
export class NavBarComponent implements OnInit {
  searchForm = new FormControl();
  filteredBooks: Books[];

  constructor(
    private route: Router,
    private bookService: BooksService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getBooks().subscribe((response) => {
      if (response) {
        this.filteredBooks = response;
      }
    });
  }

  openCart() {
    this.route.navigate(['cart']);
  }

  goToHome() {
    this.route.navigate(['home']);
  }

  searchStore() {
    const searchValue = this.searchForm.value;
    this.route.navigate(['home'], {
      queryParams: {
        item: searchValue.toLowerCase(),
      },
    });
  }

  clearSearch() {
    this.searchForm.reset();
    this.route.navigate(['/']);
  }

  onLogin() {
    this.dialog.open(LoginComponent);
  }
}
