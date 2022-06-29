import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllOrdersComponent } from './admin/all-orders/all-orders.component';
import { ConsumerReviewComponent } from './admin/consumer-review/consumer-review.component';
import { CreateProductComponent } from './admin/create-product/create-product.component';
import { DelivererReviewComponent } from './admin/deliverer-review/deliverer-review.component';
import { VerificationComponent } from './admin/verification/verification.component';
import { CreateOrderComponent } from './consumer/create-order/create-order.component';
import { OrderProductsComponent } from './consumer/order-products/order-products.component';
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
  {path: 'user/edit/:id', component: EditUserComponent},
  {path: 'user/profile/:id', component: ProfileComponent},

  {path: 'admin/deliverer/review', component: DelivererReviewComponent},
  {path: 'admin/consumer/review', component: ConsumerReviewComponent},
  {path: 'admin/verification', component: VerificationComponent},
  {path: 'admin/all-orders', component: AllOrdersComponent},
  {path: 'admin/create-product', component: CreateProductComponent},

  {path: 'consumer/create-order', component: CreateOrderComponent},
  {path: 'consumer/order-products', component: OrderProductsComponent},
  {path: 'consumer/previous-order', component: PreviousOrdersComponent},

  {path: 'deliverer/available-order', component: AvailableOrdersComponent},
  {path: 'deliverer/delivered-order', component: DeliveredOrdersComponent},
  {path: 'deliverer/actual-order', component: ActualOrderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
