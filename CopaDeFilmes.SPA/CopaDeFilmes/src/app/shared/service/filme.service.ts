import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Campeonato } from '../model/campeonato.model';
import { Filme } from '../model/filme.model';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  campeonato: Campeonato = new Campeonato();
  campeonatoObservable: Observable<Campeonato>;
  messageSource = new BehaviorSubject<Campeonato>(this.campeonato);

  apiUrl = `${environment.baseUrl}/api/v1/filme`

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  changeMessage(message: Campeonato) {
    this.messageSource.next(message)
  }

  public obterFilmes(): Observable<Filme[]> {
    return this.httpClient.get<Filme[]>(this.apiUrl);
  }

  public gerarCampeonato(filmes: Filme[]): Observable<Campeonato> {
    const body = JSON.stringify(filmes);
    return this.httpClient.post<Campeonato>(this.apiUrl, body, this.httpOptions)
  }
} 
