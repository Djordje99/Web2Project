import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent implements OnInit {

  index: number = 10;

  constructor() { }

  users = [{username: "pera", verified: false}, {username: "laza", verified: false}]

  ngOnInit(): void {
  }

  accept(index: number){
    console.log(index)
  }

  decline(index: number){
    console.log(index)
  }

}
