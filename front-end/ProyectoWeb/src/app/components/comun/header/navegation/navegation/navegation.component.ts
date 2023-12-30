import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navegation',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navegation.component.html',
  styleUrl: './navegation.component.css'
})
export class NavegationComponent {

}
