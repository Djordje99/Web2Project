import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OrderDto } from '../models/order.model';
import { OrderProductDto, ProductDto } from '../models/product.model';
import { EmailDto } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class ConsumerService {

  public pickedProducts:ProductDto[] = [];

  constructor(private http: HttpClient){}

  getProductsAll(): Observable<ProductDto[]>{
    return this.http.get<ProductDto[]>(environment.api + '/api/product/retrieve');
  }

  addProduct(product:ProductDto){
    this.pickedProducts.push(product);
  }

  removeProduct(productId:number): Observable<boolean>{
    return this.http.post<boolean>(environment.api + '/api/consumer/remove-product', productId);
  }

  createOrder(order:OrderDto): Observable<OrderDto>{
    return this.http.post<OrderDto>(environment.api + '/api/consumer/create-order', order);
  }

  orderProduct(orderProduct:OrderProductDto): Observable<OrderProductDto>{
    return this.http.post<OrderProductDto>(environment.api + '/api/consumer/add-product-details', orderProduct)
  }

  previousOrders(email:EmailDto): Observable<OrderDto[]>{
    return this.http.post<OrderDto[]>(environment.api + '/api/consumer/get-orders', email);
  }

  currentOrders(email:EmailDto): Observable<OrderDto>{
    return this.http.post<OrderDto>(environment.api + '/api/consumer/get-current-orders', email);
  }

  removePickedProducts(){
    this.pickedProducts = [];
  }
}
