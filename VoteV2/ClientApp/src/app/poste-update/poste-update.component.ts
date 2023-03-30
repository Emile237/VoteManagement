import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { poste } from '../poste-list/poste-list.component'
@Component({
  selector: 'app-poste-update',
  templateUrl: './poste-update.component.html',
  styleUrls: ['./poste-update.component.css']
})
export class PosteUpdateComponent {

  private httpClient: HttpClient;
  private activeRoute: ActivatedRoute;
  public poste: poste | undefined;
  public router: Router;
  constructor(router: Router, http: HttpClient, activeRoute: ActivatedRoute) {
    this.router = router;
    this.httpClient = http;
    this.activeRoute = activeRoute;
  }

  public getPoste(id: number) {
    console.log(id);
    this.httpClient.get<poste>(`https://localhost:7044/poste/${id}`).subscribe(result => {
      this.poste = result;
    }, error => { console.error(error) }
    );
  }

  save() {
    if (this.poste != undefined) {
      this.httpClient.put(`https://localhost:7044/poste`, this.poste).
        subscribe(result => window.location.reload());
    }
  }

}
