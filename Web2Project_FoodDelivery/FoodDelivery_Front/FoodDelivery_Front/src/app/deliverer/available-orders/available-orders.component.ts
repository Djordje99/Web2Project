import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DeliveryDto } from 'src/app/models/delivery.model';
import { OrderDto } from 'src/app/models/order.model';
import { ProductDto, UserProductDto } from 'src/app/models/product.model';
import { OrderDetailsService } from 'src/app/order-details/order-details.service';
import { SecurityService } from 'src/app/security/security.service';
import { DelivererService } from '../deliverer.service';

@Component({
  selector: 'app-available-orders',
  templateUrl: './available-orders.component.html',
  styleUrls: ['./available-orders.component.css']
})
export class AvailableOrdersComponent implements OnInit {

  availableOrders: OrderDto[] = []

  orderToDisplay:OrderDto = new OrderDto();
  productsToDisplay:ProductDto[] = [];
  showDetails = false;

  constructor(private delivererService: DelivererService,
              private security:SecurityService,
              private orderDetailsService: OrderDetailsService,
              private router: Router) { }

  ngOnInit(): void {
    this.delivererService.availableOrders().subscribe(data =>{
      this.availableOrders = data;
    })
  }

  takeOrder(index:number){
    console.log(index)
    let delivery = new DeliveryDto();
    delivery.orderId = this.availableOrders[index].id;
    delivery.delivererEmail = this.security.getLoggedUser().email;

    this.delivererService.takeDelivery(delivery).subscribe(data =>{
      console.log(data);

      this.router.navigateByUrl('deliverer/actual-order');
    })
  }

  getDetails(index:number){
    this.orderToDisplay = this.availableOrders[index];

    let userProduct = new UserProductDto();
    userProduct.email = this.orderToDisplay.creatorEmail;
    userProduct.orderId = this.orderToDisplay.id;

    this.orderDetailsService.getOrderProducts(userProduct).subscribe( data => {
      this.productsToDisplay = data;
    });

    this.showDetails = true;
  }

}
