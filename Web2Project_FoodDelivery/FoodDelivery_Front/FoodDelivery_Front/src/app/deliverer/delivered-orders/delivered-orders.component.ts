import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delivered-orders',
  templateUrl: './delivered-orders.component.html',
  styleUrls: ['./delivered-orders.component.css']
})
export class DeliveredOrdersComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  orders = [{address: 'address', comment: 'some comment', price: 422, products: [{name: 'Pizza', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 10}, {name: 'Burger', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 4}]}]

}
