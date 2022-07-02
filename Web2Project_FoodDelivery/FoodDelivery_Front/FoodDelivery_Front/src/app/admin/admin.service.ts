import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmailDto, UserDto, VerifyDto } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  getVerification(): Observable<UserDto[]>{
    return this.http.get<UserDto[]>(environment.api + '/api/admin/deliverers-status');
  }

  verifyApprove(verifyDto:VerifyDto): Observable<boolean>{
    return this.http.post<boolean>(environment.api + '/api/admin/verify', verifyDto);
  }

  verifyDecline(verifyDto:VerifyDto): Observable<boolean>{
    return this.http.post<boolean>(environment.api + '/api/admin/verify', verifyDto);
  }

  getUnActive(): Observable<UserDto[]>{
    return this.http.get<UserDto[]>(environment.api + '/api/admin/activation-request');
  }

  activateUser(email:EmailDto):Observable<boolean>{
    return this.http.post<boolean>(environment.api + '/api/admin/activate', email)
  }
}
