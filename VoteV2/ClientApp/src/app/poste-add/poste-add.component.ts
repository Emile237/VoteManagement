import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-poste-add',
  templateUrl: './poste-add.component.html',
  styleUrls: ['./poste-add.component.css']
})
export class PosteAddComponent {

  private httpClient: HttpClient;
  private activeRoute: ActivatedRoute;
  public poste: poste = new poste();
  public router: Router;

  constructor(router: Router, http: HttpClient, activeRoute: ActivatedRoute) {
    this.router = router;
    this.httpClient = http;
    this.activeRoute = activeRoute;
  }

  addPoste() {
    this.httpClient.post(`https://localhost:7044/poste`, this.poste).
      subscribe(result => window.location.reload());
  }


}
export class poste {
  Appelation: string = null!;
  Description: string = null!;
}
