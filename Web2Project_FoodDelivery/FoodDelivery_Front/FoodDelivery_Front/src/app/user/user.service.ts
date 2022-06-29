import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Token } from '../models/user.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  logIn(email:string, password:string): Observable<Token>{
    const param = new HttpParams().set('email', email).set('password', password)
    return this.http.post<Token>(environment.api + '/api/users/login', param);
  }
}
