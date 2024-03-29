import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {ToastrModule} from 'ngx-toastr'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent, FormatTimePipe } from './app.component';
import { LogInComponent } from './user/log-in/log-in.component';
import { RegisterComponent } from './user/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './menu/menu.component';
import {ReactiveFormsModule} from '@angular/forms'
import { MaterialModule } from './material/material.module';
import { HomeComponent } from './home/home.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { PreviousOrdersComponent } from './consumer/previous-orders/previous-orders.component';
import { VerificationComponent } from './admin/verification/verification.component';
import { AvailableOrdersComponent } from './deliverer/available-orders/available-orders.component';
import { DeliveredOrdersComponent } from './deliverer/delivered-orders/delivered-orders.component';
import { ActualOrderComponent } from './deliverer/actual-order/actual-order.component';
import { AllOrdersComponent } from './admin/all-orders/all-orders.component';
import { CreateProductComponent } from './admin/create-product/create-product.component';
import { OrderProductsComponent } from './consumer/order-products/order-products.component';
import { ProfileComponent } from './user/profile/profile.component';
import { PickProductsComponent } from './consumer/pick-products/pick-products.component';
import { CurrentOrderComponent } from './consumer/current-order/current-order.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { ActivationComponent } from './admin/activation/activation.component';
import { OAuthModule } from 'angular-oauth2-oidc';

import {GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule} from '@abacritt/angularx-social-login'
import { AuthInterceptor } from 'src/app/auth/auth-interceptor';


@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    RegisterComponent,
    MenuComponent,
    HomeComponent,
    EditUserComponent,
    PreviousOrdersComponent,
    VerificationComponent,
    AvailableOrdersComponent,
    DeliveredOrdersComponent,
    ActualOrderComponent,
    AllOrdersComponent,
    CreateProductComponent,
    OrderProductsComponent,
    ProfileComponent,
    PickProductsComponent,
    CurrentOrderComponent,
    OrderDetailsComponent,
    ActivationComponent,
    FormatTimePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    OAuthModule.forRoot(),
    SocialLoginModule,
  ],
  exports: [
    FormatTimePipe
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: true,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider('395905983761-v6hsgsuu4khnbcp6aapqnmtq0sa2a5a5.apps.googleusercontent.com')
          }
        ]
      } as SocialAuthServiceConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
