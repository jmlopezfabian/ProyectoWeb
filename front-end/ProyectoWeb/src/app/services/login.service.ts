import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente_Model } from '../registro/registro-cliente/registro-cliente.component';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  
  constructor(private http: HttpClient) { }

  loginCliente(Correo: String, Contrasena: String): Observable<any> {
    return this.http.post("https://localhost:7140/LoginCliente", {Correo,Contrasena});
  }

  loginProductor(Correo: String, Contrasena: String): Observable<any> {
    return this.http.post("https://localhost:7140/LoginProductor", {Correo,Contrasena});
  }
}
