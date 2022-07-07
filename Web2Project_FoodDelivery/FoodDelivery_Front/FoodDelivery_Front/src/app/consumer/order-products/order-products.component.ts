import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
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

  constructor(private formBuilder: UntypedFormBuilder,
              public consumerService: ConsumerService,
              private security:SecurityService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.productToOrder = this.consumerService.pickedProducts;

    this.price = 125;
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
    order.price = this.formOrder.controls['price'].value;
    order.creatorEmail = this.security.getLoggedUser().email;

    this.consumerService.createOrder(order).subscribe( data => {
      console.log(data)
      console.log(this.consumerService.pickedProducts)
      if(data != null){
        this.consumerService.pickedProducts.forEach(product => {
          let productDto = new OrderProductDto();
          productDto.amount = product.amount;
          productDto.orderId = data.id;
          productDto.productId = product.id;
          productDto.currentPrice = product.price;

          console.log(productDto)

          this.consumerService.orderProduct(productDto).subscribe(productData => {
            console.log(productData);
          });
        });

        this.toastr.info("You created order.")
        this.consumerService.removePickedProducts();
        this.productToOrder = []
      }
    },
    error => {
      this.toastr.error(error.error);
    });

    this.formOrder.reset();

  }

  remove(index:number){
    console.log(index)
    console.log(this.price)

    this.toastr.info('You removed ' + this.consumerService.pickedProducts[index].name + 'from cart.')

    this.consumerService.pickedProducts.splice(index, 1);
    this.ngOnInit();
  }
}
