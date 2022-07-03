import { Component, NgZone, OnInit } from '@angular/core';
import { UntypedFormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LogInClass, Token } from 'src/app/models/user.model';
import { UserService } from '../user.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  socialUser;

  constructor(private formBuilder: UntypedFormBuilder, private userService: UserService, private router: Router, private toastr: ToastrService) {
  }

  form = this.formBuilder.group({
    email: ['', {
      validators: [Validators.required, Validators.email]
    }],
    password: ['', {
      validators: [Validators.required]
    }]
  });

  ngOnInit(){
  }

  logIn(){
    let user:LogInClass = new LogInClass();
    user.email =  this.form.controls['email'].value;
    user.password = this.form.controls['password'].value;

    this.userService.login(user).subscribe(
      (data : Token) => {
        localStorage.setItem('token', data.token);
        this.router.navigateByUrl('');
      },
      error => {
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
      }
    );
  }

  getErrorForEmail(){
    const field = this.form.get('email');

    if(field?.hasError('required')){
      return 'The field is required';
    }

    if(field?.hasError('email')){
      return 'The field must be in email format';
    }

    return '';
  }

  getErrorForPassword(){
    const field = this.form.get('password');

    if(field?.hasError('required')){
      return 'The field is required';
    }

    return '';
  }
}
