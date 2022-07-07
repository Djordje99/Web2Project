import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { EmailDto, LogInClass, Token, UserCreationDto, UserDto } from '../models/user.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  login(user: LogInClass) :Observable<Token>{
    return this.http.post<Token>(environment.api + '/api/users/login', user);
  }

  register(user: LogInClass) :Observable<UserCreationDto>{
    return this.http.post<UserCreationDto>(environment.api + '/api/users/register', user);
  }

  getUser(email: EmailDto): Observable<UserDto>{
    return this.http.post<UserDto>(environment.api + '/api/users/find', email);
  }

  upload(formData: FormData){
    return this.http.post<FormData>(environment.api + '/api/users/upload', formData);
  }

  download(email:EmailDto) : Observable<Blob>{
    return this.http.post(environment.api + '/api/users/download ', email, { responseType: 'blob' });
  }

  update(user: UserDto) : Observable<boolean>{
    return this.http.put<boolean>(environment.api + '/api/users/update', user);
  }
}
