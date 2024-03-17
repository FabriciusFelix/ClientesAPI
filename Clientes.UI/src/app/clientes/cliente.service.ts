import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private HttpClient:HttpClient) { }

  getClientesService(){
    const url = "TEste da Service"
    alert(url);
  }

  
}
