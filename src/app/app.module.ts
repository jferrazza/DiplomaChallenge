import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { MainComponent } from './main/main.component';
import { SigninComponent } from './signin/signin.component';
import {SharedService} from './shared.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import {HttpClientModule} from '@angular/common/http';
import { AddComponent } from './add/add.component';
import { PaymentComponent } from './payment/payment.component';
import { SpendingComponent } from './spending/spending.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    MainComponent,
    SigninComponent,
    AddComponent,
    PaymentComponent,
    SpendingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: SigninComponent},
      {path: 'home', component: MainComponent},
      {path: 'signup', component: SignupComponent},
      {path: 'add',component: AddComponent},
      {path: 'pay',component: PaymentComponent},
      {path: 'spending',component: SpendingComponent}
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
