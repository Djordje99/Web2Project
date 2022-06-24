import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) {}

  form = this.formBuilder.group({
    email: ['', {
      validators: [Validators.required, Validators.email]
    }],
    password: ['', {
      validators: [Validators.required]
    }]
  });

  ngOnInit(): void {}

  logIn(){
    alert("some")
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
