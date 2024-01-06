import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/comun/header/header/header.component';
import { FooterComponent } from './components/comun/footer/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductoService } from './services/producto.service';
import { FormsModule } from '@angular/forms';
import { registroClienteService } from './services/registro-cliente.service';
import { registroProductorService } from './services/registro-productor.service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent,HttpClientModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [ProductoService,
  registroClienteService,
  registroProductorService]
})
export class AppComponent {
  title = 'RescueMarket';
}
