import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmeListaComponent } from './views/filme-lista/filme-lista.component';
import { CabecalhoComponent } from './views/cabecalho/cabecalho.component';
import { FilmeComponent } from './views/filme/filme.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    FilmeListaComponent,
    CabecalhoComponent,
    FilmeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
