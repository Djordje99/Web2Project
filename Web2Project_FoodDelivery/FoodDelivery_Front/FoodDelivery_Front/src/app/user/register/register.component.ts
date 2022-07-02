import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserCreationDto } from 'src/app/models/user.model';
import { UserService } from '../user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register(userCreationDto: UserCreationDto){
    this.userService.register(userCreationDto).subscribe(
      (data : UserCreationDto) => {
        this.router.navigateByUrl('/user/login');
      },
      error => {
          this.toastr.error('User already exists.', 'Authentication failed.');
      }
    );
  }
}
