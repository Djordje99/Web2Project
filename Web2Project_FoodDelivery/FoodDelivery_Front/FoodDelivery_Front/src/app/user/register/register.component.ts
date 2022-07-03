import { SocialAuthService } from '@abacritt/angularx-social-login';
import { Component, OnInit } from '@angular/core';
import { FormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
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

  socialUser;
  file:File;

  constructor(private socialAuthService: SocialAuthService, private userService: UserService, private router: Router, private toastr: ToastrService, private formBuilder: UntypedFormBuilder) { }

  ngOnInit(): void {
    console.log("ovde")
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user;
      if (this.socialUser != null){
        this.form.patchValue({
          firstName: this.socialUser.firstName,
          lastName: this.socialUser.lastName,
          email: this.socialUser.email
        })
      }
    });
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
    }]
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
        if (this.file != null) {
          this.uploadFile(data.email);
        }
        this.router.navigateByUrl('/user/login');
      },
      error => {
          this.toastr.error('User already exists.', 'Authentication failed.');
      }
    );
  }

  pickImage(event){
    this.file = event.target.files[0];
    console.log(this.file.name)
  }

  uploadFile(email:string){
    const formData = new FormData();
    formData.append(email, this.file, this.file.name);

    this.userService.upload(formData).subscribe(data => {
        console.log("Image uploaded");
    });
  }
}
