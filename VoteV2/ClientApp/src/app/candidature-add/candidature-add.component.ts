import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { candidat } from '../candidat-list/candidat-list.component';
import { poste } from '../poste-list/poste-list.component';

@Component({
  selector: 'app-candidature-add',
  templateUrl: './candidature-add.component.html',
  styleUrls: ['./candidature-add.component.css']
})
export class CandidatureAddComponent implements OnInit {

  private httpClient: HttpClient;
  private activeRoute: ActivatedRoute;
  public candidature: candidature = new candidature();
  public candidats: candidat[] | undefined;
  public postes: poste[] | undefined;
  public router: Router;

  constructor(router: Router, http: HttpClient, activeRoute: ActivatedRoute) {
    this.router = router;
    this.httpClient = http;
    this.activeRoute = activeRoute;
  }
    ngOnInit(): void {
      this.getCandidatPoste();
    }

  getCandidatPoste() {
    this.httpClient.get<candidat[]>('https://localhost:7044/candidat').subscribe(result => {
      this.candidats = result;
    }, error => { console.error(error) }
    );
    this.httpClient.get<poste[]>('https://localhost:7044/poste').subscribe(result => {
      this.postes = result;
    }, error => { console.error(error) }
    );
  }

  addCandidature() {
    console.log(this.candidature);
    this.httpClient.post(`https://localhost:7044/candidature`, this.candidature).
      subscribe(result => window.location.reload());
  }


}
export class candidature {
  
  idCandidat: any = null!;
  idPoste: any = null!;
}
