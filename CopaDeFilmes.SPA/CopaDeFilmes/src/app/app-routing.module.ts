import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { CampeonatoComponent } from './views/campeonato/campeonato.component';
import { InicioComponent } from './views/inicio/inicio.component';

const routes: Routes = [
  {
    path: '',
    component: InicioComponent
  },
  {
    path: 'campeonato',
    component: CampeonatoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
