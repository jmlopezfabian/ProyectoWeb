import { Component } from '@angular/core';
import { Cliente_Model } from '../registro/registro-cliente/registro-cliente.component';
import { Productor_Model } from '../registro/registro-productor/registro-productor.component';
import { LoginService } from '../services/login.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,RouterLinkActive,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  cliente: Cliente_Model = {
    Correo: '',
    Contrasena: ''
  };

  proveedor: Productor_Model= {
    Correo: '',
    Contrasena: ''
  };

  mostrarError_cliente: boolean = false;
  mostrarError_productor: boolean = false;
  constructor(private login: LoginService){}

  loginCliente(){
    this.login.loginCliente(this.cliente.Correo,this.cliente.Contrasena).subscribe(response =>{
      console.log(response);
      if(response == false){
        this.mostrarError_cliente = true;
        console.log("Usuario o contraseña incorrectos");
      }
    });
  }

  loginProductor(){
    this.login.loginProductor(this.cliente.Correo,this.cliente.Contrasena).subscribe(response =>{
      console.log(response);
      if(response == false){
        this.mostrarError_productor = true;
        console.log("Usuario o contraseña incorrectos");
      }
    })
  }
  
}
