import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-candidat-add',
  templateUrl: './candidat-add.component.html',
  styleUrls: ['./candidat-add.component.css']
})
export class CandidatAddComponent  {

  private httpClient: HttpClient;
  private activeRoute: ActivatedRoute;
  public candidat: candidat = new candidat();
  public router: Router;

  constructor(router: Router, http: HttpClient, activeRoute: ActivatedRoute) {
    this.router = router;
    this.httpClient = http;
    this.activeRoute = activeRoute;
  }

  addCandidat() {
    this.httpClient.post(`https://localhost:7044/candidat`, this.candidat).
      subscribe(result => window.location.reload());
  }


}
export class candidat {
  nom:string = null!;
  prenom:string  = null!;
  description:string = null!;
}
