import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActivationComponent } from './admin/activation/activation.component';
import { AllOrdersComponent } from './admin/all-orders/all-orders.component';
import { CreateProductComponent } from './admin/create-product/create-product.component';
import { VerificationComponent } from './admin/verification/verification.component';
import { AuthGuard } from './auth/auth-guard';
import { CurrentOrderComponent } from './consumer/current-order/current-order.component';
import { OrderProductsComponent } from './consumer/order-products/order-products.component';
import { PickProductsComponent } from './consumer/pick-products/pick-products.component';
import { PreviousOrdersComponent } from './consumer/previous-orders/previous-orders.component';
import { ActualOrderComponent } from './deliverer/actual-order/actual-order.component';
import { AvailableOrdersComponent } from './deliverer/available-orders/available-orders.component';
import { DeliveredOrdersComponent } from './deliverer/delivered-orders/delivered-orders.component';
import { HomeComponent } from './home/home.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { LogInComponent } from './user/log-in/log-in.component';
import { ProfileComponent } from './user/profile/profile.component';
import { RegisterComponent } from './user/register/register.component';

const routes: Routes = [
  {path: '', component: HomeComponent},

  {path: 'user/register', component: RegisterComponent},
  {path: 'user/login', component: LogInComponent},
  {path: 'user/profile', component: ProfileComponent, canActivate:[AuthGuard]},
  {path: 'user/edit/:id', component: EditUserComponent, canActivate:[AuthGuard]},

  {path: 'admin/verification', component: VerificationComponent, canActivate:[AuthGuard]},
  {path: 'admin/all-orders', component: AllOrdersComponent, canActivate:[AuthGuard]},
  {path: 'admin/create-product', component: CreateProductComponent, canActivate:[AuthGuard]},
  {path: 'admin/activation', component: ActivationComponent, canActivate:[AuthGuard]},

  {path: 'consumer/order-products', component: OrderProductsComponent, canActivate:[AuthGuard]},
  {path: 'consumer/previous-order', component: PreviousOrdersComponent, canActivate:[AuthGuard]},
  {path: 'consumer/pick-products', component: PickProductsComponent, canActivate:[AuthGuard]},
  {path: 'consumer/current-order', component: CurrentOrderComponent, canActivate:[AuthGuard]},


  {path: 'deliverer/available-order', component: AvailableOrdersComponent, canActivate:[AuthGuard]},
  {path: 'deliverer/delivered-order', component: DeliveredOrdersComponent, canActivate:[AuthGuard]},
  {path: 'deliverer/actual-order', component: ActualOrderComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
