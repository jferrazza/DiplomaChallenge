import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signInForm;

  constructor(private router:Router,private formBuilder: FormBuilder, private service:SharedService) {
    this.signInForm = this.formBuilder.group({
      name: '',
      password: ''
    })
  }
  getData: any[];

  ngOnInit(): void {
  }
  onSubmit(data) {
    this.service.getUser(data.name,data.password).subscribe(data => {
      this.getData = data;
      if (this.getData.length == 0){
        alert("Your user or password is incorrect. Try again");
      }
      else if (this.service.isAdmin = this.getData[0]["role"] == "PENDING")
      {
        alert("You're account is pending. Please contact an administrator or try again later or when instructed.");

      }
      else{
        this.service.ident = this.getData[0]["id"];
        this.service.username = this.getData[0]["name"];
        this.service.isAdmin = this.getData[0]["role"] != "PENDING";
        this.router.navigate(['/home']);
      }
    })  
  }
}
