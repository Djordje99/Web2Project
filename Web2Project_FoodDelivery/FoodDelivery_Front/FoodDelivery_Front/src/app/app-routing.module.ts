import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsumerReviewComponent } from './admin/consumer-review/consumer-review.component';
import { DelivererReviewComponent } from './admin/deliverer-review/deliverer-review.component';
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

  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
