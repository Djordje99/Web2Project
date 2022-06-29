export class Token{
    token: string = '';
}

export class LogInClass{
    email:string = '';
    password:string = '';
}

export interface userCreationDto{
    username: string;
    email: string;
    password: string;
    passwordRepeat: string;
    firstName: string;
    lastName: string;
    birthday: Date;
    address: string;
    userType: string;
    photo: string;
}