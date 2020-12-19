import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CabecalhoComponent } from './views/cabecalho/cabecalho.component';

const routes: Routes = [
  {
    path: '',
    component: CabecalhoComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
