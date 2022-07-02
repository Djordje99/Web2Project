import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
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

  constructor(private userService: UserService, private router: Router, private toastr: ToastrService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  form = this.formBuilder.group({
    username: ['', {
      validators: [Validators.required]
    }],
    email: ['', {
      validators: [Validators.required, Validators.email]
    }],
    password: ['', {
      validators: [Validators.required]
    }],
    passwordVerify: ['', {
      validators: [Validators.required]
    }],
    firstName: ['', {
      validators: [Validators.required]
    }],
    lastName: ['', {
      validators: [Validators.required]
    }],
    birthday: ['', {
      validators: [Validators.required]
    }],
    address: ['', {
      validators: [Validators.required]
    }],
    userType: ['', {
      validators: [Validators.required]
    }],
    photo: ['']
  });

  getError(fieldName:string){
    const field = this.form.get(fieldName);

    if(field?.hasError('required')){
      return 'The field is required';
    }

    if(field?.hasError('email')){
      return 'The field must be in email format';
    }

    return '';
  }

  register(){
    this.userService.register(this.form.value).subscribe(
      (data : UserCreationDto) => {
        this.router.navigateByUrl('/user/login');
      },
      error => {
          this.toastr.error('User already exists.', 'Authentication failed.');
      }
    );
  }
}
