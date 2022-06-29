import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { userCreationDto } from 'src/app/models/user.model';
import { toBase64 } from 'src/app/utilities/image';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  @Input()
  model?: userCreationDto;

  @Output()
  onSaveChanges: EventEmitter<userCreationDto> = new EventEmitter<userCreationDto>();

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
    passwordRepeat: ['', {
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
    photo: ['', {
      validators: [Validators.required]
    }]
  });

  imageBase64: string = '';

  ngOnInit(): void {
    if(this.model !== undefined){
      this.form.patchValue(this.model)
    }
  }

  register(){
    this.onSaveChanges.emit(this.form.value);
  }
}
