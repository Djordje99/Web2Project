import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { OrderDto } from 'src/app/models/order.model';
import { OrderProductDto, ProductDto } from 'src/app/models/product.model';
import { SecurityService } from 'src/app/security/security.service';
import { ConsumerService } from '../consumer.service';

@Component({
  selector: 'app-order-products',
  templateUrl: './order-products.component.html',
  styleUrls: ['./order-products.component.css']
})
export class OrderProductsComponent implements OnInit {

  productToOrder:ProductDto[];
  price:number;
  formOrder:UntypedFormGroup;

  constructor(private formBuilder: UntypedFormBuilder, public consumerService: ConsumerService, private security:SecurityService) { }

  ngOnInit(): void {
    this.productToOrder = this.consumerService.pickedProducts;
    console.log(this.consumerService.pickedProducts);

    this.price = 0;
    this.productToOrder.forEach(product => {
      this.price += (product.amount * product.price);
    });

    this.formOrder = this.formBuilder.group({
      address: ['', {
        validators: [Validators.required]
      }],
      comment: ['', {
        validators: [Validators.required]
      }],
      price: [this.price, {
        validators: [Validators.required]
      }]
    });
  }

  order(){
    let order = new OrderDto;
    order.address = this.formOrder.controls['address'].value;
    order.comment = this.formOrder.controls['comment'].value;
    order.creatorEmail = this.security.getLoggedUser().email;

    this.consumerService.createOrder(order).subscribe( data => {
      if(data != null){
        this.consumerService.pickedProducts.forEach(product => {
          let productDto = new OrderProductDto();
          productDto.amount = product.amount;
          productDto.orderId = data.id;
          productDto.productId = product.id;
          productDto.currentPrice = product.price;

          this.consumerService.orderProduct(productDto).subscribe(productData => {
            console.log(productData);
          });
        });
      }
    });

    this.formOrder.reset();
    this.productToOrder = [];
  }

  remove(index:number){
    console.log(index)
    console.log(this.price)
    this.consumerService.pickedProducts.splice(index, 1);
    this.ngOnInit();
  }
}
