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
    correo: ''
  }

  lista: DTOProductor[] = [];

  
  nuevoProductor: Productor_Model = {
    nombre_Usuario: '',
    correo: '',
    contrasena: '',
    nombre: '',
    apellido_Materno: '',
    apellido_Paterno: '',
    fecha_nacimiento: '',
    telefono: '',
    calle: '',
    num_ext: 0,
    ciudad: '',
    codigo_Postal: ''
  }


  constructor(private pService: registroProductorService, private router: Router){
    this.pService.obtenerProductores().subscribe(resoult => {
      this.lista = resoult.productor;
    })
  }

  

  enviarFormularioProductor(){
    this.nuevoProductorDTO.nombre_Usuario = this.nuevoProductor.nombre_Usuario;
    this.nuevoProductorDTO.correo = this.nuevoProductor.correo;
    this.nuevoProductorDTO.nombre = this.nuevoProductor.nombre;
    this.nuevoProductorDTO.telefono = this.nuevoProductor.telefono;
    this.nuevoProductorDTO.calle = this.nuevoProductor.calle;
    this.nuevoProductorDTO.num_ext = this.nuevoProductor.num_ext;
    this.nuevoProductorDTO.ciudad = this.nuevoProductor.ciudad;
    this.nuevoProductorDTO.codigo_Postal = this.nuevoProductor.codigo_Postal;

    this.pService.createProductor(this.nuevoProductor).subscribe(response  => {
      console.log(response);
      if(response == false){
        this.correoRegistrado_productor = true;
        console.log("Este correo ya esta registrado");
      }else{
        this.pService.createProductorDTO(this.nuevoProductorDTO).subscribe(responseDTO => {
          console.log(responseDTO);

          this.router.navigate(['/productor',this.nuevoProductorDTO.nombre_Usuario]);
        })
      }
    });

    
  }
}


export interface Productor_Model{
  nombre_Usuario?: string,
  correo: String,
  contrasena: String,
  nombre?: String,
  apellido_Paterno?: String,
  apellido_Materno?: String,
  fecha_nacimiento?: String,
  telefono?: String,
  calle?: String,
  num_ext?: number,
  ciudad?: String,
  codigo_Postal?: String
}

export interface DTOProductor{
  nombre_Usuario?: String,
  correo: String,
  nombre?: String,
  telefono?: String,
  calle?: String,
  num_ext?: number,
  ciudad?: String,
  codigo_Postal?: String
}