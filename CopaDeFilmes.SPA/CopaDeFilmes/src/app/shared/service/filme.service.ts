import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Campeonato } from '../model/campeonato.model';
import { Filme } from '../model/filme.model';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  apiUrl = `${environment.baseUrl}/api/v1/filme`
  //apiUrl = '/api/v1/filme'

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  public obterFilmes(): Observable<Filme[]> {
    return this.httpClient.get<Filme[]>(this.apiUrl);
  }

  public gerarCampeonato(filmes: any): Observable<Campeonato> {
    const body = JSON.stringify(filmes);
    return this.httpClient.post<Campeonato>(this.apiUrl, body, this.httpOptions);
  }
} 
