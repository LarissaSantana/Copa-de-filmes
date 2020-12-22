import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormArray } from '@angular/forms';
import { Filme } from 'src/app/shared/model/filme.model';
import { FilmeService } from 'src/app/shared/service/filme.service';
import { Campeonato } from 'src/app/shared/model/campeonato.model';
import { NavigationExtras, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-filme-lista',
  templateUrl: './filme-lista.component.html',
  styleUrls: ['./filme-lista.component.css']
})
export class FilmeListaComponent implements OnInit {
  public formulario: FormGroup;
  filmes: Filme[];
  quantidadeDeFilmesSelecionados: number = 0;
  controleDeCheckbox: FormControl = new FormControl();

  constructor(
    public filmeService: FilmeService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.filmes = [];
    this.obterFilmes();
    this.formulario = this.formBuilder.group({
      filmes: this.buildFilmes([])
    });

    this.controleDeCheckbox.valueChanges.subscribe(value => {
      if (value) this.quantidadeDeFilmesSelecionados++
      else this.quantidadeDeFilmesSelecionados--;
    })
  }

  getFilmesControls() {
    return this.formulario.get('filmes') ? (<FormArray>this.formulario.get('filmes')).controls : null;
  }

  buildFilmes(filmes: Filme[]) {
    const values = filmes.map(v => new FormControl(false));
    return this.formBuilder.array(values);
  }

  obterFilmes() {
    this.filmeService.obterFilmes().subscribe(dados => {
      this.filmes = dados;
      console.log(this.filmes);

      this.formulario = this.formBuilder.group({
        filmes: this.buildFilmes(dados)
      });
    });
  }

  onSubmit() {
    let valueSubmit = Object.assign({}, this.formulario.value);

    valueSubmit = Object.assign(valueSubmit, {
      filmes: valueSubmit.filmes
        .map((filme: Filme, index: number) => filme ? this.filmes[index] : null)
        .filter((filme: Filme) => filme !== null)
    });
    console.log(valueSubmit);
    console.log("submit...");

    this.filmeService.gerarCampeonato(valueSubmit).subscribe(dados => {
      this.filmeService.messageSource.next(dados)
      this.navegarParaOCampeonato()
    }, (erro: any) => { console.log(erro); })
  }

  navegarParaOCampeonato(): void {
    this.router.navigate(['/campeonato']);
  }
}
