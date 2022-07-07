import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EmailDto, UserDto } from 'src/app/models/user.model';
import { SecurityService } from 'src/app/security/security.service';
import { UserService } from '../user.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  picture;
  show = false;
  verify = 'In Progress';
  userType = 'Deliverer';
  user:UserDto;

  constructor(
    private userService:UserService,
    private security : SecurityService,
    private toastr: ToastrService,
    private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.userService.getUser(this.security.getLoggedUser()).subscribe(data => {
      if(data != null){
        this.user = data;
        if(this.user.veryfied == 0)
          this.verify = "Approved";
        else if(this.user.veryfied == 1)
          this.verify = "Denied";

        if(this.user.type == 0)
          this.userType = 'Admin';
        else if (this.user.type == 1)
          this.userType = 'Consumer';

        this.show = true;
      }
    },
    error => {
      this.toastr.error('Error while getting logged user.', 'Authentication failed.');
    });

    this.getImage(this.security.getLoggedUser())
    console.log(this.user)
  }

  getImage(email:EmailDto){
    this.userService.download(email).subscribe({
      next: (data) =>{
        if(data !== null){
          let objectURL = URL.createObjectURL(data);
          this.picture = this.sanitizer.bypassSecurityTrustUrl(objectURL);
          console.log(objectURL)
        }
      }
    });
  }
}
