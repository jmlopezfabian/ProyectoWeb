import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/comun/header/header/header.component';
import { FooterComponent } from './components/comun/footer/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductoService } from './services/producto.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [ProductoService]
})
export class AppComponent {
  title = 'practica2';
}
