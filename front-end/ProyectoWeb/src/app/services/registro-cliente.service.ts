import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { core } from '@angular/compiler';

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

  public createClienteDTO(ClienteData:any): Observable<any>{
    return this.http.post("https://localhost:7140/DTOClientes",ClienteData);
  }
  public obtenerClienteDTO_user(Nombre: string): Observable<any>{
    return this.http.get(`https://localhost:7140/DTOClientes/GetClienteDTO_USER?user_name=${Nombre}`)
  }

  public obtenerClienteDTO(Correo: String): Observable<any>{
    return this.http.get(`https://localhost:7140/DTOClientes?correo=${Correo}`)
  }
}

