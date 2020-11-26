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
  gameListF: any = [];
  gameListP: any = [];
  refreshList() {
    this.service.getGameListFuture().subscribe(data => {
      this.gameListF = data;
    })
    this.service.getGameListPast().subscribe(data => {
      this.gameListP = data;
    })
  }
  delete(data){
    if (confirm("Are you sure you want to forfeit the game?")==true){
      this.service.deleteGame(data).subscribe(data => {
        this.refreshList();
      });
    }
  }
  
  pay(venue){
    var paylist = [];
    this.service.getPay(venue).subscribe(d=>{
      if (d.length > 0){
        alert("Oops, this has been paid for.");
      }
      else{
        this.service.payingfor = venue;
        this.router.navigate(['/pay']);
      }
    });


  }
}
