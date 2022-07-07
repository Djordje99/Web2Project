import { Component, OnInit } from '@angular/core';
import { OrderDto } from 'src/app/models/order.model';
import { ProductDto, UserProductDto } from 'src/app/models/product.model';
import { OrderDetailsService } from 'src/app/order-details/order-details.service';
import { SecurityService } from 'src/app/security/security.service';
import { ConsumerService } from '../consumer.service';

@Component({
  selector: 'app-previous-orders',
  templateUrl: './previous-orders.component.html',
  styleUrls: ['./previous-orders.component.css']
})
export class PreviousOrdersComponent implements OnInit {

  constructor(private consumerService: ConsumerService, private security: SecurityService, private orderDetailsService: OrderDetailsService) { }

  orders:OrderDto[] = []

  orderToDisplay:OrderDto = new OrderDto();
  productsToDisplay:ProductDto[] = [];

  ngOnInit(): void {
    this.consumerService.previousOrders(this.security.getLoggedUser()).subscribe(data =>{
      this.orders = data;
    })
  }

  getDetails(index:number){
    this.orderToDisplay = this.orders[index];

    let userProduct = new UserProductDto();
    userProduct.email = this.security.getLoggedUser().email;
    userProduct.orderId = this.orderToDisplay.id;

    this.orderDetailsService.getOrderProducts(userProduct).subscribe( data => {
      this.productsToDisplay = data;
    });
  }
}
