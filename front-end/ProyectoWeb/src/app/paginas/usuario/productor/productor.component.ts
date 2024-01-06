import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { registroProductorService } from '../../../services/registro-productor.service';


@Component({
  selector: 'app-productor',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './productor.component.html',
  styleUrl: './productor.component.css'
})
export class ProductorComponent {
  constructor(private pService: registroProductorService){
    this.pService.
  }
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