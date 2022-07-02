import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { EmailDto, UserCreationDto, UserDto } from 'src/app/models/user.model';
import { SecurityService } from 'src/app/security/security.service';
import { UserService } from '../user.service';
@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  model:UserDto = new UserDto;
  form:FormGroup;

  constructor(private activatedRoute: ActivatedRoute, private userService: UserService, private security: SecurityService, private toastr: ToastrService, private formBuilder: FormBuilder)
  {
  }

  ngOnInit(): void {
    // this.activatedRoute.params.subscribe(params => {
    //   alert(params['id']);
    // })
    this.userService.getUser(this.security.getLoggedUser()).subscribe((data) => {
      this.model = data;
      this.form = this.formBuilder.group({
        username: [this.model?.username, {
          validators: [Validators.required]
        }],
        email: [this.model?.email, {
          validators: [Validators.required, Validators.email]
        }],
        firstName: [this.model?.firstName, {
          validators: [Validators.required]
        }],
        lastName: [this.model?.lastName, {
          validators: [Validators.required]
        }],
        birthday: [this.model?.birthday, {
          validators: [Validators.required]
        }],
        address: [this.model?.address, {
          validators: [Validators.required]
        }],
        userType: [this.model?.userType, {
          validators: [Validators.required]
        }],
        photo: ['']
      });
    });

    this.form = this.formBuilder.group({
      username: [this.model?.username, {
        validators: [Validators.required]
      }],
      email: [this.model?.email, {
        validators: [Validators.required, Validators.email]
      }],
      firstName: [this.model?.firstName, {
        validators: [Validators.required]
      }],
      lastName: [this.model?.lastName, {
        validators: [Validators.required]
      }],
      birthday: [this.model?.birthday, {
        validators: [Validators.required]
      }],
      address: [this.model?.address, {
        validators: [Validators.required]
      }],
      userType: [this.model?.userType, {
        validators: [Validators.required]
      }],
      photo: ['']
    });
  }

  edit(){
    console.log('data');
  }
}
