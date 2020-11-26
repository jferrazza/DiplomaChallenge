import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  share;

  constructor(private router:Router,private service:SharedService) {
    this.share = this.service;
    this.refreshList();
  }
  ngOnInit(): void {
    if (this.service.ident == null)
      {this.router.navigate(['/']);
    console.warn("No login specified. Quitting...")}
  }
  gameList: any = [];
  refreshList() {
    this.service.getGameList().subscribe(data => {
      this.gameList = data;
    })
  }

}
