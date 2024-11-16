import { Injectable } from '@angular/core';
import { environment } from '../enviroment/enviroment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  //Variables
  baseURL: string = environment.apiConfigUrl;
  baseURLV2: string = environment.apiConfigV2;
  httpHeader = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private httpClient: HttpClient) {}

  authenticateUser(emailId: string, password: string): Observable<any> {
    const url = this.baseURL + `User/AuthenticateUser`;
    return this.httpClient.post<User>(url, { emailId, password });
  }
}
