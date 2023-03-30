import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { candidat } from '../candidat-list/candidat-list.component';

@Component({
  selector: 'app-candidat-update',
  templateUrl: './candidat-update.component.html',
  styleUrls: ['./candidat-update.component.css']
})
export class CandidatUpdateComponent {
  private httpClient: HttpClient;
  private activeRoute: ActivatedRoute;
  public candidat: candidat | undefined;
  public router: Router;
  constructor(router: Router, http: HttpClient, activeRoute: ActivatedRoute) {
    this.router = router;
    this.httpClient = http;
    this.activeRoute = activeRoute;
  }

  public getCandidat(id:number) {
   // let id = this.activeRoute.snapshot.paramMap.get('id');
    console.log(id);
    this.httpClient.get<candidat>(`https://localhost:7044/candidat/${id}`).subscribe(result => {
      this.candidat = result;
    }, error => { console.error(error) }
    );
  }

  save() {
    if (this.candidat != undefined) {
      this.httpClient.put(`https://localhost:7044/candidat`, this.candidat).
        subscribe(result => window.location.reload());
    }
  }

}
