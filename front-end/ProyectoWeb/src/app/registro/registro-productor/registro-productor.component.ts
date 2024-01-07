import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { registroProductorService } from '../../services/registro-productor.service';
import { interval } from 'rxjs';
import { resourceUsage } from 'process';
import { resourceLimits } from 'worker_threads';
import { RouterLink, RouterLinkActive} from '@angular/router';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registro-productor',
  standalone: true,
  imports: [FormsModule, RouterLink,RouterLinkActive],
  templateUrl: './registro-productor.component.html',
  styleUrl: './registro-productor.component.css'
})
export class RegistroProductorComponent {
  correoRegistrado_productor: boolean = false;

  nuevoProductorDTO: DTOProductor={
    Correo: ''
  }

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


  constructor(private pService: registroProductorService, private router: Router){
    this.pService.obtenerProductores().subscribe(resoult => {
      this.lista = resoult.productor;
    })
  }

  

  enviarFormularioProductor(){
    this.nuevoProductorDTO.Nombre_Usuario = this.nuevoProductor.Nombre_Usuario;
    this.nuevoProductorDTO.Correo = this.nuevoProductor.Correo;
    this.nuevoProductorDTO.Nombre = this.nuevoProductor.Nombre;
    this.nuevoProductorDTO.Telefono = this.nuevoProductor.Telefono;
    this.nuevoProductorDTO.Calle = this.nuevoProductor.Calle;
    this.nuevoProductorDTO.Num_ext = this.nuevoProductor.Num_ext;
    this.nuevoProductorDTO.Ciudad = this.nuevoProductor.Ciudad;
    this.nuevoProductorDTO.Codigo_Postal = this.nuevoProductor.Codigo_Postal;

    this.pService.createProductor(this.nuevoProductor).subscribe(response  => {
      console.log(response);
      if(response == false){
        this.correoRegistrado_productor = true;
        console.log("Este correo ya esta registrado");
      }else{
        this.pService.createProductorDTO(this.nuevoProductorDTO).subscribe(responseDTO => {
          console.log(responseDTO);
        })
      }
    });

    this.router.navigate(['/productor',this.nuevoProductorDTO.Nombre_Usuario]);
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
  Nombre?: String,
  Telefono?: String,
  Calle?: String,
  Num_ext?: number,
  Ciudad?: String,
  Codigo_Postal?: String
}