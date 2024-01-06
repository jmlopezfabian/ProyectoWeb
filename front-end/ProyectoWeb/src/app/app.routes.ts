import { Routes } from '@angular/router';
import { IncioComponent } from './paginas/inicio/inicio.component';
import { ConocenosComponent } from './paginas/conocenos/conocenos.component';
import { ProductosComponent } from './paginas/productos/productos.component';
import { UbicacionComponent } from './paginas/ubicacion/ubicacion.component';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { RegistroClienteComponent } from './registro/registro-cliente/registro-cliente.component';
import { RegistroProductorComponent } from './registro/registro-productor/registro-productor.component';
import { ClienteComponent } from './paginas/usuario/cliente/cliente.component';
import { ProductorComponent } from './paginas/usuario/productor/productor.component';


export const routes: Routes = [
    {path:"", component:IncioComponent},
    {path:"inicio", component:IncioComponent},
    {path:"conocenos", component:ConocenosComponent},
    {path:"ubicacion", component:UbicacionComponent},
    {path:"productos", component:ProductosComponent },
    {path:"login", component:LoginComponent},
    {path:"registro", component:RegistroComponent},
    {path:'registroCliente',component:RegistroClienteComponent},
    {path:'registroProductor',component:RegistroProductorComponent},
    {path:'cliente',component:ClienteComponent},
    {path:'productor/:id', component:ProductorComponent}
];
