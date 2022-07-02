import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserDto } from 'src/app/models/user.model';
import { SecurityService } from 'src/app/security/security.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private userService:UserService, private security : SecurityService, private toastr: ToastrService) { }

  user:UserDto[] = [];

  ngOnInit(): void {
    this.userService.getUser(this.security.getLoggedUser()).subscribe(data => {
      if(data != null){
        this.user[0] = data;
      }
    },
    error => {
      this.toastr.error('Error while getting logged user.', 'Authentication failed.');
    });
    console.log(this.user)
  }
}
