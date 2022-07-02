import { Component, OnInit } from '@angular/core';
import { EmailDto, UserDto } from 'src/app/models/user.model';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-activation',
  templateUrl: './activation.component.html',
  styleUrls: ['./activation.component.css']
})
export class ActivationComponent implements OnInit {

  users:UserDto[] = []

  constructor( private adminService: AdminService) { }

  ngOnInit(): void {
    this.adminService.getUnActive().subscribe( data => {
      this.users = data;
    })
  }

  activate(index:number){
    console.log(index)
    let user = this.users[index];
    let email = new EmailDto()
    email.email = user.email;
    this.adminService.activateUser(email).subscribe( data => {
      console.log(data)
    })
  }

}
