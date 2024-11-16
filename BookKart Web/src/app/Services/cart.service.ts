import { Injectable } from '@angular/core';
import { environment } from '../enviroment/enviroment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../Models/cart';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  //Variables
  baseURL: string = environment.apiConfigUrl;
  baseURLV2: string = environment.apiConfigV2;
  httpHeader = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private httpClient: HttpClient) {}

  getCartForUser(userId: number): Observable<any> {
    const url = this.baseURL + `Cart/GetCartForUser/` + userId;
    return this.httpClient.get<Cart[]>(url);
  }

  addOrUpdateCart(cart: Cart): Observable<any> {
    const url = this.baseURL + `Cart`;
    if (cart.Id == 0) {
      return this.httpClient.post<Cart>(url, cart);
    } else {
      return this.httpClient.put<Cart>(url, cart);
    }
  }

  emptyCart(userId: number): Observable<any> {
    const url = this.baseURL + `Cart/EmptyCart/` + userId;
    return this.httpClient.get<any>(url);
  }

  deleteCart(cartId: number): Observable<any> {
    const url = this.baseURL + `Cart/` + cartId;
    return this.httpClient.delete<Cart>(url);
  }
}
