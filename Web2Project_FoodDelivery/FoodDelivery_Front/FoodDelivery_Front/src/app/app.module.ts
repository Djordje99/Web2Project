import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './user/log-in/log-in.component';
import { RegisterComponent } from './user/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuComponent } from './menu/menu.component';
import {ReactiveFormsModule} from '@angular/forms'
import { MaterialModule } from './material/material.module';
import { HomeComponent } from './home/home.component';
import { RegisterFormComponent } from './user/register-form/register-form.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { ProfileComponent } from './user/profile/profile.component';
import { DelivererReviewComponent } from './admin/deliverer-review/deliverer-review.component';
import { ConsumerReviewComponent } from './admin/consumer-review/consumer-review.component';
import { CreateOrderComponent } from './consumer/create-order/create-order.component';
import { PreviousOrdersComponent } from './consumer/previous-orders/previous-orders.component';
import { VerificationComponent } from './admin/verification/verification.component';
import { AvailableOrdersComponent } from './deliverer/available-orders/available-orders.component';
import { DeliveredOrdersComponent } from './deliverer/delivered-orders/delivered-orders.component';
import { ActualOrderComponent } from './deliverer/actual-order/actual-order.component';
import { AllOrdersComponent } from './admin/all-orders/all-orders.component';
import { CreateProductComponent } from './admin/create-product/create-product.component';

@NgModule({
  declarations: [
    AppComponent,
    LogInComponent,
    RegisterComponent,
    MenuComponent,
    HomeComponent,
    RegisterFormComponent,
    EditUserComponent,
    ProfileComponent,
    DelivererReviewComponent,
    ConsumerReviewComponent,
    CreateOrderComponent,
    PreviousOrdersComponent,
    VerificationComponent,
    AvailableOrdersComponent,
    DeliveredOrdersComponent,
    ActualOrderComponent,
    AllOrdersComponent,
    CreateProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
