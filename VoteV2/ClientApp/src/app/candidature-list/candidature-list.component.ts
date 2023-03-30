import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { candidat } from '../candidat-list/candidat-list.component';
import { poste } from '../poste-list/poste-list.component';
@Component({
  selector: 'app-candidature-list',
  templateUrl: './candidature-list.component.html',
  styleUrls: ['./candidature-list.component.css']
})
export class CandidatureListComponent  {

  private httpClient: HttpClient;
  public candidatures: Candidature[] | undefined;

  constructor(http: HttpClient, private router: Router) {
    this.httpClient = http;
  }

  ngOnInit(): void {
    this.httpClient.get<Candidature[]>('https://localhost:7044/candidature').subscribe(result => {
      this.candidatures = result;
      console.table(result);
    }, error => { console.error(error); }
    );
  }
  deleteCandidature(id: number) {
    this.httpClient.delete(`https://localhost:7044/candidature/${id}`).
      subscribe(result => window.location.reload());
  }

}
export interface Candidature {
  idcandidature: number;
  idcandidat: number;
  idPoste: number;
  poste: poste;
  candidat: candidat;
}
