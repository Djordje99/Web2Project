import { Component, OnInit } from '@angular/core';
import { OrderDto } from 'src/app/models/order.model';
import { ProductDto, UserProductDto } from 'src/app/models/product.model';
import { OrderDetailsService } from 'src/app/order-details/order-details.service';
import { SecurityService } from 'src/app/security/security.service';
import { DelivererService } from '../deliverer.service';

@Component({
  selector: 'app-actual-order',
  templateUrl: './actual-order.component.html',
  styleUrls: ['./actual-order.component.css']
})
export class ActualOrderComponent implements OnInit {

  orders:OrderDto[] = [];

  orderToDisplay:OrderDto = new OrderDto();
  productsToDisplay:ProductDto[] = [];
  showDetails = false;

  constructor(private delivererService: DelivererService, private security:SecurityService, private orderDetailsService: OrderDetailsService) { }

  ngOnInit(): void {
    this.delivererService.actualOrders(this.security.getLoggedUser()).subscribe(data =>{
      this.orders = data;
    })
  }

  getDetails(index:number){
    this.orderToDisplay = this.orders[index];

    let userProduct = new UserProductDto();
    userProduct.email = this.orderToDisplay.creatorEmail;
    userProduct.orderId = this.orderToDisplay.id;

    this.orderDetailsService.getOrderProducts(userProduct).subscribe( data => {
      this.productsToDisplay = data;
    });

    this.showDetails = true;
  }
}
