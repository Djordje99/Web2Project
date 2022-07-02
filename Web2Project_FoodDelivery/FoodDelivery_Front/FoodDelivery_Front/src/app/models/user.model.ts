export class Token{
    token: string = '';
}

export class EmailDto{
    email: string = '';
}

export class LogInClass{
    email:string = "";
    password:string = "";
}

export interface UserCreationDto{
    username: string;
    email: string;
    password: string;
    passwordVerify: string;
    firstName: string;
    lastName: string;
    birthday: Date;
    address: string;
    userType: number;
    photo: string;
}

export class UserDto{
    username: string = '';
    email: string = '';
    password: string = '';
    firstName: string = '';
    lastName: string = '';
    birthday: Date = new Date();
    address: string = '';
    userType: number = 0;
    photo: string = '';
    verified: number = 0;
    accepredRegistration: boolean = false;
}
export class VerifyDto{
    email:string = '';
    verifyType:number = 0;
}