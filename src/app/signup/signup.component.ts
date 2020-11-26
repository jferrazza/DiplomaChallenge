import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private router:Router,private formBuilder: FormBuilder, private service:SharedService) {
    this.signInForm = this.formBuilder.group({
      name: '',
      password: '',
      password2: '',
      // role: 'PENDING'
      role: 'Member'
    })
  }
  signInForm;
  getData: any[];

  ngOnInit(): void {
  }
  onSubmit(data) {
    console.log(data.password);
    console.log(data.password2);
    if (data.password == "" || data.name == ""){
      alert("Please enter a name and password.");
      return;
    }    if (data.password != data.password2){
      alert("Please make sure the passwords match and try again.");
      return;
    }

    this.service.addUser(data).subscribe(a => {
      alert(a);
      this.router.navigate(['/']);
    })  
  }
}
