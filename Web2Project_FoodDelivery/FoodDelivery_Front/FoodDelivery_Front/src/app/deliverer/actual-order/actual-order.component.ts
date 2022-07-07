import { Component, Input, OnChanges, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, timer } from 'rxjs';
import { DeliveryDto } from 'src/app/models/delivery.model';
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

  isDelivered = false;

  countDown: Subscription;
  counter = 1000;
  tick = 1000;

  constructor(private delivererService: DelivererService,
              private security:SecurityService,
              private orderDetailsService: OrderDetailsService,
              private router: Router) { }

  ngOnInit(): void {
    this.delivererService.actualOrders(this.security.getLoggedUser()).subscribe(data =>{
      this.orders = data;

      let order = this.orders[0];

      if(order != null){
        if(order.status == 1){
          let time = new Date();
          this.counter = order.takenTime - (time.getTime() / 1000 + 7150);

          if(this.counter <= 0){

          }
          else{
            this.countDown = timer(0, this.tick).subscribe(() => --this.counter);
          }
        }
      }
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

  orderDelivered(){
    console.log("delivered");
    this.isDelivered = true;
    let delivery = new DeliveryDto();
    delivery.delivererEmail = this.security.getLoggedUser().email;
    delivery.orderId = this.orders[0].id;

    this.delivererService.deliver(delivery).subscribe( data => {
      console.log(data);
    })

    this.router.navigateByUrl('deliverer/delivered-order');
  }
}
