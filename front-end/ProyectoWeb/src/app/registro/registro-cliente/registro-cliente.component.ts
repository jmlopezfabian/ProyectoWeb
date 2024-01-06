import { Component } from '@angular/core';
import { response } from 'express';
import { registroClienteService} from '../../services/registro-cliente.service';
import { interval } from 'rxjs';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-registro-cliente',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './registro-cliente.component.html',
  styleUrl: './registro-cliente.component.css'
})

export class RegistroClienteComponent {
  lista: DTOCliente[] = [];

  nuevoCliente: Cliente_Model = {
    Nombre_Usuario: '',
    Correo: '',
    Contrasena: '',
    Nombre: '',
    Apellido_Materno: '',
    Apellido_Paterno: '',
    Fecha_nacimiento: ''
  };

  constructor(private pService: registroClienteService){
    this.pService.obtenerClientes().subscribe(result => {
      this.lista = result.cliente;
    })
  }

  enviarFormulario(){
    this.pService.createCliente(this.nuevoCliente).subscribe(response  => {
      console.log(response);
    });
  }
}

export interface Cliente_Model{
  Nombre_Usuario?: string,
  Correo: String,
  Contrasena?: String,
  Nombre?: String,
  Apellido_Paterno?: String,
  Apellido_Materno?: String,
  Fecha_nacimiento?: String
}

export interface DTOCliente{
  Nombre_Usuario?: string,
  Correo: String,
  Contrasena?: String,
  Nombre?: String,
  Apellido_Paterno?: String,
  Apellido_Materno?: String,
  Fecha_nacimiento?: String
}