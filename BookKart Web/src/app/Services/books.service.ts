import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../enviroment/enviroment';
import { Books } from '../Models/boots';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
      //Variables
      baseURL: string= environment.apiConfigUrl;
      baseURLV2:string = environment.apiConfigV2;
      httpHeader = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
  constructor(private httpClient: HttpClient) { }

  getBooks(): Observable<Books[]> {
    const url = this.baseURL + 'Book';
    return this.httpClient.get<Books[]>(url);
  }

  getBookById(bookId: number): Observable<Books> {
    const url = this.baseURL + 'Book/' + bookId;
    return this.httpClient.get<Books>(url);
  }
}
