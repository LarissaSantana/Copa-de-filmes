import { Component } from '@angular/core';
import { FilmeService } from './shared/service/filme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [FilmeService]
})
export class AppComponent {
  title = 'CopaDeFilmes';
}
