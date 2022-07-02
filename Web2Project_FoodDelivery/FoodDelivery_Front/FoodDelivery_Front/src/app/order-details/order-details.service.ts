import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductDto, UserProductDto } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class OrderDetailsService {

  constructor(private http: HttpClient) { }

  getOrderProducts(userProduct:UserProductDto): Observable<ProductDto[]>{
    return this.http.post<ProductDto[]>(environment.api + '/api/consumer/get-orders-details', userProduct);
  }
}
