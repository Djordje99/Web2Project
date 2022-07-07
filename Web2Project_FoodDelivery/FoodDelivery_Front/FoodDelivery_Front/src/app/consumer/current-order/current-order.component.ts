import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, timer } from 'rxjs';
import { OrderDto } from 'src/app/models/order.model';
import { ProductDto, UserProductDto } from 'src/app/models/product.model';
import { OrderDetailsService } from 'src/app/order-details/order-details.service';
import { SecurityService } from 'src/app/security/security.service';
import { ConsumerService } from '../consumer.service';

@Component({
  selector: 'app-current-order',
  templateUrl: './current-order.component.html',
  styleUrls: ['./current-order.component.css']
})
export class CurrentOrderComponent implements OnInit {

  order:OrderDto;

  orderToDisplay:OrderDto = new OrderDto();
  productsToDisplay:ProductDto[] = [];
  showDetails = false;

  isDelivered = false;

  countDown: Subscription;
  counter = 1000;
  tick = 1000;

  show = false;

  constructor(private consumerService: ConsumerService,
              private security:SecurityService,
              private orderDetailsService: OrderDetailsService,
              private router: Router) { }

  ngOnInit(): void {
    this.consumerService.currentOrders(this.security.getLoggedUser()).subscribe( data =>{
      this.order = data;

      if(this.order != null){
        if(this.order.status == 1){
          let time = new Date();
          this.counter = this.order.takenTime - (time.getTime() / 1000 + 7150);

          if(this.counter > 0){
            this.countDown = timer(0, this.tick).subscribe(() => --this.counter);
          }
        }

        this.show = true;
      }
    })
  }

  getDetails(){
    this.orderToDisplay = this.order;

    let userProduct = new UserProductDto();
    userProduct.email = this.security.getLoggedUser().email;
    userProduct.orderId = this.orderToDisplay.id;

    this.orderDetailsService.getOrderProducts(userProduct).subscribe( data => {
      this.productsToDisplay = data;
    });

    this.showDetails = true;
  }

  removeDetails(){
    this.showDetails = false;
  }

  orderDelivered(){
    this.isDelivered = true;
    this.router.navigateByUrl('consumer/previous-order');
  }

}
