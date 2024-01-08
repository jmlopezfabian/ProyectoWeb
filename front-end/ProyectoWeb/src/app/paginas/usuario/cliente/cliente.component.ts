import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { registroClienteService } from '../../../services/registro-cliente.service';

@Component({
  selector: 'app-cliente',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.css'
})
export class ClienteComponent {

  cliente: DTOCliente = {
    correo: '',
    nombre: '',
    nombre_Usuario: ''
  }

  constructor(private pService: registroClienteService, private route: ActivatedRoute) {}
  
  ngOnInit(): void{
    this.route.params.subscribe(params => {
      const user_name = params['id'];
      
      this.pService.obtenerClienteDTO_user(user_name).subscribe(result => {
        console.log(result);
        this.cliente = result;
      })
    })
  }
  
}


export interface DTOCliente{
  correo: string,
  nombre_Usuario: string,
  nombre: String
}