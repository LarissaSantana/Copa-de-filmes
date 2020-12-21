import { Component, OnInit } from '@angular/core';
import { FilmeService } from 'src/app/shared/service/filme.service';

@Component({
  selector: 'app-campeonato',
  templateUrl: './campeonato.component.html',
  styleUrls: ['./campeonato.component.css']
})
export class CampeonatoComponent implements OnInit {

  public campeao: String;
  public viceCampeao: String;

  constructor(
    private filmeService: FilmeService
  ) { }

  ngOnInit() {
    this.filmeService.messageSource.subscribe(
      dados => { 
        this.campeao = dados.campeao.titulo;
        this.viceCampeao = dados.viceCampeao.titulo;
      }
    )
  }
} 
