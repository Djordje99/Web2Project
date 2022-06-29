import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  form = this.formBuilder.group({
    amount: ['', {
      validators: [Validators.required, Validators.min(0), Validators.max(999)]
    }]
  });

  products = [{name: 'Pizza', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil'}, {name: 'Burger', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil'}]
  ngOnInit(): void {
  }

  addToCart(index:number){
    console.log(index + "-" + this.form.controls["amount"].value);
  }

}
