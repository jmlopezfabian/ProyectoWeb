import { Component } from '@angular/core';
import { Cliente_Model,DTOCliente} from '../registro/registro-cliente/registro-cliente.component';
import { Productor_Model } from '../registro/registro-productor/registro-productor.component';
import { LoginService } from '../services/login.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { registroClienteService } from '../services/registro-cliente.service';
import { registroProductorService } from '../services/registro-productor.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,RouterLinkActive,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  cliente_login: Cliente_Model = {
    correo: '',
    contrasena: '',
  };

  clienteDTO: DTOCliente = {
    nombre_Usuario: '',
    nombre: '',
    correo: ''
  }

  proveedor_login: Productor_Model= {
    correo: '',
    contrasena: ''
  };

  mostrarError_cliente: boolean = false;
  mostrarError_productor: boolean = false;
  constructor(private login: LoginService,private router: Router, private pService: registroProductorService,private cService: registroClienteService){}

  loginCliente(){
    console.log(this.proveedor_login);
    this.login.loginCliente(this.cliente_login.correo,this.cliente_login.contrasena).subscribe(response =>{
      console.log(response);
      if(response == false){
        this.mostrarError_cliente = true;
        console.log("Usuario o contraseña incorrectos");
      }else{
        this.cService.obtenerClienteDTO(this.cliente_login.correo).subscribe(response2 =>{
          console.log(response2);
          this.router.navigate(['/cliente',response2.nombre_Usuario]);
        })
      }

    });
  }

  loginProductor() {
    this.login.loginProductor(this.proveedor_login.correo, this.proveedor_login.contrasena).subscribe(response => {
      console.log(response);
      if (response == false) {
        this.mostrarError_productor = true;
        console.log("Usuario o contraseña incorrectos");
      } else {
        this.pService.obtenerProductorDTO(this.proveedor_login.correo).subscribe(response2 => {
          console.log(response2);
          this.router.navigate(['/productor', response2.nombre_Usuario]);
        });
      }
    });
  }
}