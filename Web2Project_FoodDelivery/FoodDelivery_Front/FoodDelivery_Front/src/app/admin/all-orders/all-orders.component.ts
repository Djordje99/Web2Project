import { Component, OnInit } from '@angular/core';
import { OrderDto } from 'src/app/models/order.model';
import { ProductDto, UserProductDto } from 'src/app/models/product.model';
import { OrderDetailsService } from 'src/app/order-details/order-details.service';
import { SecurityService } from 'src/app/security/security.service';

@Component({
  selector: 'app-all-orders',
  templateUrl: './all-orders.component.html',
  styleUrls: ['./all-orders.component.css']
})
export class AllOrdersComponent implements OnInit {

  orders:OrderDto[] = []

  orderToDisplay:OrderDto = new OrderDto();
  productsToDisplay:ProductDto[] = [];

  showDetails = false

  constructor(private orderDetailsService: OrderDetailsService, private security: SecurityService) { }

  ngOnInit(): void {
  }

  getDetails(index:number){
    this.orderToDisplay = this.orders[index];

    let userProduct = new UserProductDto();
    userProduct.email = this.security.getLoggedUser().email;
    userProduct.orderId = this.orderToDisplay.id;

    this.orderDetailsService.getOrderProducts(userProduct).subscribe( data => {
      this.productsToDisplay = data;
    });

    this.showDetails = true;
  }

}
