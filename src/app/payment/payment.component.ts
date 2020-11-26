import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {


  constructor(private router:Router,private formBuilder: FormBuilder, private service:SharedService) {
    this.payForm = this.formBuilder.group({
      amount: 0,
      userid: this.service.ident,
      gameid: this.service.payingfor,
    })
  }
  payForm;
  getUsers: any[];

  ngOnInit(): void {
    this.service.getUserList().subscribe(a=>{
      this.getUsers = a;
    });
  }
  onSubmit(data) {

    if (data.amount == 0){
      alert("Please enter an amount.");
      return;
    }
    if (this.person == -1){
      alert("Please select a person.");
      return;
    }
    data.userid = this.person;

    this.service.addPay(data).subscribe(a => {
      console.log(data);
      alert(a);
      this.router.navigate(['/home']);
    })  
  }
  person = -1;
  personname = "";
  getUser(id,name){
    this.person = id;
    this.personname = name;
  }
}
