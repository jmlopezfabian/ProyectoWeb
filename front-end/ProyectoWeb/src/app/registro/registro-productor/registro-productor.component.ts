import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { registroProductorService } from '../../services/registro-productor.service';
import { interval } from 'rxjs';
import { resourceUsage } from 'process';
import { resourceLimits } from 'worker_threads';

@Component({
  selector: 'app-registro-productor',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './registro-productor.component.html',
  styleUrl: './registro-productor.component.css'
})
export class RegistroProductorComponent {
  lista: DTOProductor[] = [];

  nuevoProductor: Productor_Model = {
    Nombre_Usuario: '',
    Correo: '',
    Contrasena: '',
    Nombre: '',
    Apellido_Materno: '',
    Apellido_Paterno: '',
    Fecha_nacimiento: '',
    Telefono: '',
    Calle: '',
    Num_ext: 0,
    Ciudad: '',
    Codigo_Postal: ''
  }

  constructor(private pService: registroProductorService){
    this.pService.obtenerProductores().subscribe(resoult => {
      this.lista = resoult.productor;
    })
  }

  enviarFormularioProductor(){
    this.pService.createProductor(this.nuevoProductor).subscribe(response  => {
      console.log(response);
    });
  }
}


export interface Productor_Model{
  Nombre_Usuario?: string,
  Correo: String,
  Contrasena: String,
  Nombre?: String,
  Apellido_Paterno?: String,
  Apellido_Materno?: String,
  Fecha_nacimiento?: String,
  Telefono?: String,
  Calle?: String,
  Num_ext?: number,
  Ciudad?: String,
  Codigo_Postal?: String
}

export interface DTOProductor{
  Nombre_Usuario?: string,
  Correo: String,
  Contrasena: String,
  Nombre?: String,
  Apellido_Paterno?: String,
  Apellido_Materno?: String,
  Fecha_nacimiento?: String,
  Telefono?: String,
  Calle?: String,
  Num_ext?: number,
  Ciudad?: String,
  Codigo_Postal?: String
}