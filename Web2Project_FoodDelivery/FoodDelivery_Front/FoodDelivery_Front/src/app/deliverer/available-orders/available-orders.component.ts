import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-available-orders',
  templateUrl: './available-orders.component.html',
  styleUrls: ['./available-orders.component.css']
})
export class AvailableOrdersComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  orders = [{address: 'address', comment: 'some comment', price: 422, products: [{name: 'Pizza', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 10}, {name: 'Burger', price: 99, ingredients: 'tomato, mozzarella, olive oil, basil', amount: 4}]}]

  takeOrder(index:number){
    console.log(index)
  }

}
