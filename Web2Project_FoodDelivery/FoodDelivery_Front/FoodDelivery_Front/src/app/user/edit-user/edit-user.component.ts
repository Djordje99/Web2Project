import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { userCreationDto } from '../users.model';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute) { }

  model: userCreationDto = {username: 'pera', email: 'pera@gmail.com', password: '', passwordRepeat: '',
                            address: 'address 1', firstName: 'Pera', lastName: 'Peric', birthday: new Date(),
                            userType: 'DELIVERER', photo: 'none'}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      alert(params['id']);
    })
  }

  edit(userCreationDto: userCreationDto){
    console.log(userCreationDto);
  }

}
