import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-order-products',
  templateUrl: './order-products.component.html',
  styleUrls: ['./order-products.component.css']
})
export class OrderProductsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  form = this.formBuilder.group({
    address: ['', {
      validators: [Validators.required]
    }],
    comment: ['', {
      validators: [Validators.required]
    }],
    price: [123, {
      validators: [Validators.required]
    }]
  });

  products = [{name: 'Pizza', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 10}, {name: 'Burger', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 4}]
  ngOnInit(): void {
  }

  order(){
    console.log("some")
  }

  removeFromCart(index:number){
    console.log(index)
  }
}
