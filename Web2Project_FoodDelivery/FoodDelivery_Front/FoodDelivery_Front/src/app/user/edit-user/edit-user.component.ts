import { Component, Input, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  form:UntypedFormGroup;

  constructor(private activatedRoute: ActivatedRoute,
              private userService: UserService,
              private security: SecurityService,
              private toastr: ToastrService,
              private formBuilder: UntypedFormBuilder,
              private router: Router)
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
      photo: ['']
    });
  }

  edit(){
    this.model.firstName = this.form.controls['firstName'].value;
    this.model.lastName = this.form.controls['lastName'].value;
    this.model.username = this.form.controls['username'].value;
    this.model.birthday = this.form.controls['birthday'].value;
    this.model.address = this.form.controls['address'].value;
    this.userService.update(this.model).subscribe( data => {
      console.log(data)

      this.router.navigateByUrl('user/profile');
    });
  }
}
