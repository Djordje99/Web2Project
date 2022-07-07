import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DeliveryDto } from '../models/delivery.model';
import { OrderDto } from '../models/order.model';
import { EmailDto } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class DelivererService {

  constructor(private http: HttpClient) { }

  availableOrders(): Observable<OrderDto[]>{
    return this.http.get<OrderDto[]>(environment.api + '/api/deliverer/available-orders');
  }

  deliveredOrders(email:EmailDto): Observable<OrderDto[]>{
    return this.http.post<OrderDto[]>(environment.api + '/api/deliverer/delivered-orders', email);
  }

  actualOrders(email:EmailDto): Observable<OrderDto[]>{
    return this.http.post<OrderDto[]>(environment.api + '/api/deliverer/actual-orders', email);
  }

  takeDelivery(delivery:DeliveryDto): Observable<number>{
    return this.http.post<number>(environment.api + '/api/deliverer/take-order', delivery);
  }

  deliver(delivery:DeliveryDto):Observable<boolean>{
    return this.http.post<boolean>(environment.api + '/api/deliverer/deliver', delivery);
  }
}
