import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ProductDto } from 'src/app/models/product.model';
import { ConsumerService } from '../consumer.service';
import { OrderProductsComponent } from '../order-products/order-products.component';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  products:ProductDto[];
  columnToDisplay = ['name', 'price', 'ingredients', 'amount', 'action']

  constructor(private formBuilder: FormBuilder, private consumerService: ConsumerService)
  {
    let productsData;
    this.consumerService.getProductsAll().subscribe(data =>{
      this.products = data;
    });
  }

  form = this.formBuilder.group({
    amount: ['', {
      validators: [Validators.required, Validators.min(0), Validators.max(999)]
    }]
  });

  ngOnInit(): void {
  }





}
