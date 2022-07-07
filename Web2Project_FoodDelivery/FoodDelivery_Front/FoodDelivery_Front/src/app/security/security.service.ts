import { Injectable } from '@angular/core';
import { EmailDto } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor() { }

  isAuthenticated(): boolean{
    const token = localStorage.getItem('token');

    if(!token){
      return false;
    }

    return true;
  }

  logout(){
    localStorage.removeItem('token');
  }

  getLoggedUser():EmailDto{
    let email : EmailDto = {email: ''};
    const token = localStorage.getItem('token');
    if(!token){
      return email;
    }

    const tokenData = JSON.parse(atob(token.split('.')[1]));

    email.email = tokenData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
    console.log(email.email);
    return email;
  }

  getLoggedRole():string{
    const token = localStorage.getItem('token');
    if(!token){
      return '';
    }

    const tokenData = JSON.parse(atob(token.split('.')[1]));
    return tokenData['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }

}
