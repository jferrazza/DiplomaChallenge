import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-spending',
  templateUrl: './spending.component.html',
  styleUrls: ['./spending.component.css']
})
export class SpendingComponent implements OnInit {

  constructor(private router: Router, private service: SharedService) {
      }
  gameList: any[];
  userList: any[];
  getAllUsers: any[];

  ngOnInit(): void {
    this.refreshList();
  }
  refreshList() {

    this.service.getGameListPaid().subscribe(a=>{
      this.gameList = a;
    });
    this.service.getUserListPaid().subscribe(a=>{
      this.userList = a;
    });
    this.service.getUserList().subscribe(a=>{
      this.getAllUsers = a;
    });
  }
}
