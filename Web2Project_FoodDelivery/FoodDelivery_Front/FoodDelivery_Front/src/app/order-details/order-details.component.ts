import { Component, Input, OnInit } from '@angular/core';
import { OrderDto } from '../models/order.model';
import { ProductDto, UserProductDto } from '../models/product.model';
import { SecurityService } from '../security/security.service';
import { OrderDetailsService } from './order-details.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  @Input()
  order:OrderDto = new OrderDto();
  @Input()
  products:ProductDto[] = []

  constructor() { }

  ngOnInit(): void {
    console.log(this.order);
    console.log(this.products);
  }
}
