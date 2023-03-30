import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { PosteUpdateComponent } from '../poste-update/poste-update.component'
@Component({
  selector: 'app-poste-list',
  templateUrl: './poste-list.component.html',
  styleUrls: ['./poste-list.component.css']
})
export class PosteListComponent implements OnInit {

  public idPoste: number = 0;
  private httpClient: HttpClient;
  public postes: poste[] | undefined;

  @ViewChild(PosteUpdateComponent) posteUpdate: PosteUpdateComponent | undefined;
  constructor(http: HttpClient, private router: Router) {
    this.httpClient = http;
  }

  ngOnInit() {
    this.httpClient.get<poste[]>('https://localhost:7044/poste').subscribe(result => {
      this.postes = result;
    }, error => { console.error(error) }
    );
  }
  deletePoste(id: number) {
    this.httpClient.delete(`https://localhost:7044/poste/${id}`).
      subscribe(result => window.location.reload());
  }

  updatePoste(id: number) {
    this.idPoste = id;
    this.posteUpdate?.getPoste(id);

  }
}
export interface poste {
  idposte: number;
  appelation: string;
  description: string;
}
