import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidatUpdateComponent } from '../candidat-update/candidat-update.component';

@Component({
  selector: 'app-candidat-list',
  templateUrl: './candidat-list.component.html',
  styleUrls: ['./candidat-list.component.css']
})
export class CandidatListComponent {

  public idCandidat: number = 0;
  private httpClient: HttpClient;
  public candidats: candidat[] | undefined;

  @ViewChild(CandidatUpdateComponent) candidatUpdate: CandidatUpdateComponent | undefined;
  constructor(http: HttpClient, private router: Router) {
    this.httpClient = http;
  }

  ngOnInit() {
    this.httpClient.get<candidat[]>('https://localhost:7044/candidat').subscribe(result => {
      this.candidats = result;
    }, error => { console.error(error) }
    );
  }
  deleteCandidat(id: number) {
    this.httpClient.delete(`https://localhost:7044/candidat/${id}`).
      subscribe(result => window.location.reload());
  }

  updateCandidat(id: number) {
    this.idCandidat = id;
    this.candidatUpdate?.getCandidat(id);

  }
}
export interface candidat {
  idCandidat: number;
  nom: string;
  prenom: string;
  description: string;
}
