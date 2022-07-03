import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ToastrService } from 'ngx-toastr';
import { EmailDto, UserDto, VerifyDto } from 'src/app/models/user.model';
import { SecurityService } from 'src/app/security/security.service';
import { UserService } from 'src/app/user/user.service';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent implements OnInit {

  users:UserDto[] = [];

  constructor(private adminService: AdminService,
              private userService:UserService,
              private security : SecurityService,
              private toastr: ToastrService,
              private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.adminService.getVerification().subscribe(data =>{
      this.users = data;
    })
  }

  accept(index: number){
    console.log(index)
    let user = this.users[index];
    let verify:VerifyDto = new VerifyDto();
    verify.email = user.email;
    verify.verifyType = 0;

    this.adminService.verifyApprove(verify).subscribe(data => {
      console.log(data);
    })

    this.ngOnInit();
  }

  decline(index: number){
    console.log(index)
    let user = this.users[index];
    let verify:VerifyDto = new VerifyDto();
    verify.email = user.email;
    verify.verifyType = 1;

    this.adminService.verifyApprove(verify).subscribe(data => {
      console.log(data);
    })

    this.ngOnInit();
  }
}
