import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { registroProductorService } from '../../../services/registro-productor.service';
import { resourceLimits } from 'worker_threads';


@Component({
  selector: 'app-productor',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './productor.component.html',
  styleUrl: './productor.component.css'
})

export class ProductorComponent {

  productor: DTOProductor = {
    nombre_Usuario: '',
    correo: '',
    nombre: '',
    telefono: '',
    calle: '',
    num_ext: 0,
    ciudad: '',
    codigo_Postal: ''
  }
  

  constructor(private pService: registroProductorService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const user_name = params["id"];

      this.pService.obtenerProductorDTO_user(user_name).subscribe(result=> {
        console.log(result);
        this.productor = result;
      });
    });
  }
}

export interface DTOProductor {
  correo: string;
  nombre_Usuario: string;
  nombre: string;
  telefono: string;
  num_ext: number;
  calle: string;
  ciudad: string;
  codigo_Postal: string;
}
