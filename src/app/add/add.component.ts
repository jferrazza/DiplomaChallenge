import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  addForm;

  constructor(private router:Router,private formBuilder: FormBuilder, private service:SharedService) {
    this.addForm = this.formBuilder.group({
      detail: '',
      venue: '',
      date: '',
      time: ''
    })
  }

  ngOnInit(): void {
  }
  onSubmit(data) {
    data.time = ""+data.time+":00";

    console.log(data);
    this.service.addGame(data).subscribe(d =>
      {
        console.log(d);
        this.router.navigate(['/home']);
      }
    );

  }

}
