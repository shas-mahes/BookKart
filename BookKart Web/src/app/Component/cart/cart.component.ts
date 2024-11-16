import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { CartService } from '../../Services/cart.service';
import { Cart } from '../../Models/cart';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CartComponent implements OnInit {
  booksInCart: Cart[];
  havePromo: boolean = false;
  promoCodevalid: boolean = false;
  promoCodeForm = new FormControl();

  constructor(
    private cartService: CartService,
    private changeDetection: ChangeDetectorRef
  ) {
    this.booksInCart = [];
    this.promoCodeForm = new FormControl('');
  }

  ngOnInit(): void {
    this.cartService.getCartForUser(1).subscribe((response) => {
      if (response.ResponseCode == 'Success') {
        this.booksInCart = response.Data;
        this.changeDetection.detectChanges();
      }
    });
  }

  emptyCart() {
    this.cartService.emptyCart(1).subscribe((res) => {
      console.log(res);
      location.reload();
    });
  }

  isExpanded() {
    return (this.havePromo = !this.havePromo);
  }

  removeBookQuantity(cart: Cart) {
    var cartObj = this.createCartForUser(cart);
    cartObj.Quantity--;
    this.cartService.addOrUpdateCart(cartObj).subscribe((response) => {
      if (response.ResponseCode == 'Success') {
        console.log('Cart Updated');
        location.reload();
      } else {
        console.log('Unable to update cart');
      }
    });
  }

  addBookQuantity(cart: Cart) {
    var cartObj = this.createCartForUser(cart);
    cartObj.Quantity++;
    this.cartService.addOrUpdateCart(cartObj).subscribe((response) => {
      if (response.ResponseCode == 'Success') {
        console.log('Cart Updated');
        location.reload();
      } else {
        console.log('Unable to update cart');
      }
    });
  }

  get totalCartValue() {
    var total = 0;
    this.booksInCart.forEach((val) => {
      total += val.Books.Price * val.Quantity;
    });
    return total;
  }

  removeBook(cart: Cart) {
    this.cartService.deleteCart(cart.Id).subscribe((response) => {
      console.log(response);
      location.reload();
    });
  }

  createCartForUser(data: any) {
    const cartObj = {} as Cart;
    cartObj.BookId = data.BookId;
    cartObj.UserId = data.UserId;
    cartObj.Id = data.Id;
    cartObj.CreatedBy = data.CreatedBy;
    cartObj.CreatedDate = data.CreatedDate;
    cartObj.Quantity = data.Quantity;
    cartObj.ModifiedBy = data.CreatedBy;
    cartObj.ModifiedDate = new Date();
    return cartObj;
  }
}
