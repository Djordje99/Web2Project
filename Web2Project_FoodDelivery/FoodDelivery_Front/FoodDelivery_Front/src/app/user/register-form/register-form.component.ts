import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { UserCreationDto } from 'src/app/models/user.model';
import { toBase64 } from 'src/app/utilities/image';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  @Input()
  model?: UserCreationDto;

  @Output()
  onSaveChanges: EventEmitter<UserCreationDto> = new EventEmitter<UserCreationDto>();

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

  imageBase64: string = '';

  ngOnInit(): void {
    if(this.model !== undefined){
      this.form.patchValue(this.model)
      console.log("razlicit");
    }
    else{
      console.log("nema modela")
    }
  }

  register(){
    this.onSaveChanges.emit(this.form.value);
  }
}
