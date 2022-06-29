import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-actual-order',
  templateUrl: './actual-order.component.html',
  styleUrls: ['./actual-order.component.css']
})
export class ActualOrderComponent implements OnInit {

  constructor() { }

  order = {address: 'address', comment: 'some comment', price: 422, products: [{name: 'Pizza', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 10}, {name: 'Burger', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 4}]}

  ngOnInit(): void {
  }
}
