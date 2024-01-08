import { Component } from '@angular/core';
import { response } from 'express';
import { registroClienteService} from '../../services/registro-cliente.service';
import { interval } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registro-cliente',
  standalone: true,
  imports: [FormsModule,RouterLink,RouterLinkActive],
  templateUrl: './registro-cliente.component.html',
  styleUrl: './registro-cliente.component.css'
})

export class RegistroClienteComponent {
  correoRegistrado_cliente: boolean = false;

  lista: DTOCliente[] = [];

  clienteDTO: DTOCliente = {
    nombre_Usuario: '',
    nombre: '',
    correo: ''
  }

  nuevoCliente: Cliente_Model = {
    nombre_Usuario: '',
    correo: '',
    contrasena: '',
    nombre: '',
    apellido_Materno: '',
    apellido_Paterno: '',
    fecha_nacimiento: ''
  };

  constructor(private pService: registroClienteService,private router: Router){
    this.pService.obtenerClientes().subscribe(result => {
      this.lista = result.cliente;
    })
  }

  enviarFormulario(){
    this.clienteDTO.nombre = this.nuevoCliente.nombre;
    this.clienteDTO.nombre_Usuario = this.nuevoCliente.nombre_Usuario;
    this.clienteDTO.correo = this.nuevoCliente.correo;



    this.pService.createCliente(this.nuevoCliente).subscribe(response  => {
      console.log(response);
      if(response == false){
        this.correoRegistrado_cliente = true;
        console.log("Este correo ya esta registrado");
      }else{
        this.pService.createClienteDTO(this.clienteDTO).subscribe(responseDTO => {
          console.log(responseDTO);
          this.router.navigate(['/cliente', this.clienteDTO.nombre_Usuario]);
        })
      }
    });
  }

}

export interface Cliente_Model{
  nombre_Usuario?: string,
  correo: String,
  contrasena: String,
  nombre?: String,
  apellido_Paterno?: String,
  apellido_Materno?: String,
  fecha_nacimiento?: String
}

export interface DTOCliente{
  nombre_Usuario?: String,
  correo?: String,
  nombre?: String,
}