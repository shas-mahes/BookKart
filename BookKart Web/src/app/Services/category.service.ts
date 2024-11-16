import { Injectable } from '@angular/core';
import { environment } from '../enviroment/enviroment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Category } from '../Models/category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
      //Variables
      baseURL: string= environment.apiConfigUrl;
      baseURLV2:string = environment.apiConfigV2;
      httpHeader = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
  constructor(private httpClient: HttpClient) { }

  getCategories(): Observable<Category[]> {
    const url = this.baseURL + 'Category';
    return this.httpClient.get<Category[]>(url);
  }
}
