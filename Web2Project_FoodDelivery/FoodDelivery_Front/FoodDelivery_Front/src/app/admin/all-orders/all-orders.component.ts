import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-orders',
  templateUrl: './all-orders.component.html',
  styleUrls: ['./all-orders.component.css']
})
export class AllOrdersComponent implements OnInit {

  constructor() { }

  orders = [{address: 'address', comment: 'some comment', price: 422, products: [{name: 'Pizza', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 10}, {name: 'Burger', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 4}]}]

  ngOnInit(): void {
  }

}
