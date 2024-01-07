import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class registroClienteService {

  constructor(private http: HttpClient){ }


  public obtenerClientes() : Observable<any>{
    return this.http.get("https://localhost:7158/Clientes")
  }

  public createCliente(ClienteData: any): Observable<any> {
    return this.http.post('https://localhost:7158/Clientes', ClienteData);
  }

}
