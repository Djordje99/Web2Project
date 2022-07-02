import { Component, OnInit } from '@angular/core';
import { SecurityService } from '../security/security.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(public security: SecurityService) { }

  ngOnInit(): void {
  }

}
