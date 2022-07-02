import { Injectable } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';

const oAuthConfig: AuthConfig = {
  issuer: 'https://accounts.google.com',
  strictDiscoveryDocumentValidation: false,
  redirectUri: window.location.origin,
  clientId: '395905983761-v6hsgsuu4khnbcp6aapqnmtq0sa2a5a5.apps.googleusercontent.com',
  scope: 'openid profile email'
}

@Injectable({
  providedIn: 'root'
})
export class GoogleApiService {

  constructor(private readonly oAuthService: OAuthService) {
  }

  auth(){
    this.oAuthService.configure(oAuthConfig)
    this.oAuthService.loadDiscoveryDocument().then( () => {
      this.oAuthService.tryLoginImplicitFlow().then( () => {
        if(!this.oAuthService.hasValidAccessToken()){
          this.oAuthService.initLoginFlow()
        }else{
          this.oAuthService.loadUserProfile().then( (userProfile) => {
            console.log(JSON.stringify(userProfile));
            console.log("ovde");
          })
        }
      })
    })
  }
}
