import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:55368/api";
  ident: number;
  username: string;
  isAdmin: boolean = false;
  payingfor: number;
  

  getUserList():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/User");
  }
  getUser(val,val2):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+"/User?name="+val+"&password="+val2);
  }

  addUser(val:any){
    return this.http.post(this.APIUrl+"/User",val);
  }

  updateUser(val:any){
    return this.http.put(this.APIUrl+"/User",val);
  }

  deleteUser(val:any){
    return this.http.delete(this.APIUrl+"/User/"+val);
  }
  
  getGameList():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Game");
  }
  getGameListFuture():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Future");
  }
  getGameListPast():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Past");
  } 
  getGameListPaid():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Payee");
  }
  getUserListPaid():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Payee?byusers=true");
  }

  addGame(val:any){
    return this.http.post(this.APIUrl+"/Game",val);
  }

  updateGame(val:any){
    return this.http.put(this.APIUrl+"/Game",val);
  }

  deleteGame(val:any){
    return this.http.delete(this.APIUrl+"/Game/"+val);
  }
  getPayList():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Pay");
  }
  getPay(val:any):Observable<any[]> {
    return this.http.get<any>(this.APIUrl+"/Pay?venue="+val);
  }
  addPay(val:any){
    return this.http.post(this.APIUrl+"/Pay",val);
  }

  updatePay(val:any){
    return this.http.put(this.APIUrl+"/Pay",val);
  }

  deletePay(val:any){
    return this.http.delete(this.APIUrl+"/Pay",val);
  }
  
  

  constructor(private http:HttpClient) { }
}
