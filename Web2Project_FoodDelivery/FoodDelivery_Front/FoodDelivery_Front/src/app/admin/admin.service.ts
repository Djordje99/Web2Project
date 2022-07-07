import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OrderDto } from '../models/order.model';
import { ProductDto } from '../models/product.model';
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

  createProduct(newProduct:ProductDto): Observable<ProductDto>{
    return this.http.post<ProductDto>(environment.api + '/api/admin/create-product', newProduct);
  }

  getOrders():Observable<OrderDto[]>{
    return this.http.get<OrderDto[]>(environment.api + '/api/admin/get-orders')
  }

  sendEmail(){
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.http.post('https://formspree.io/f/xjvlqkay',
      { name: 'FoodDelivery Verification', replyto: 'bozovicdjordje4@gmail.com', message: 'Admin accepted verification' },
      { 'headers': headers }).subscribe(
        response => {
          console.log(response);
        }
      );
  }
}
