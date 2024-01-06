import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
  })
  export class registroProductorService {
  
    constructor(private http: HttpClient){}
  
    public obtenerProductores() : Observable<any>{
      return this.http.get("https://localhost:7158/Productores")
    }
  
    public createProductor(ProductorData: any): Observable<any> {
      return this.http.post('https://localhost:7158/Productores', ProductorData);
    }
}