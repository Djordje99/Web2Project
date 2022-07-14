import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { UserService } from "src/app/user/user.service";
import { SecurityService } from "../security/security.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router, private service:UserService, private security: SecurityService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        let token = localStorage.getItem('token');

        if(!token)
            return next.handle(req.clone());

        const tokenData = JSON.parse(atob(token.split('.')[1]));
        let tokenTime = tokenData['exp'];
        let currentTime = new Date().getTime() / 1000;
        if(tokenTime < currentTime){
            localStorage.removeItem('token');
            this.router.navigateByUrl('');
        }

        if (localStorage.getItem('token') != null) {
            const clonedReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
            });
            return next.handle(clonedReq).pipe(
                tap(
                    succ => { },
                    err => {
                        if (err.status == 401){
                            localStorage.removeItem('token');
                            this.router.navigateByUrl('');
                        }
                    }
                )
            )
        }
        else
            return next.handle(req.clone());
    }
}