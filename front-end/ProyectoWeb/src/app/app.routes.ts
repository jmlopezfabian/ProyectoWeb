import { Routes } from '@angular/router';
import { IncioComponent } from './paginas/inicio/inicio.component';
import { ConocenosComponent } from './paginas/conocenos/conocenos.component';
import { ProductosComponent } from './paginas/productos/productos.component';
import { UbicacionComponent } from './paginas/ubicacion/ubicacion.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
    {path:"", component:IncioComponent},
    {path:"inicio", component:IncioComponent},
    {path:"conocenos", component:ConocenosComponent},
    {path:"ubicacion", component:UbicacionComponent},
    {path:"productos", component:ProductosComponent },
    {path:"login", component:LoginComponent}
];
