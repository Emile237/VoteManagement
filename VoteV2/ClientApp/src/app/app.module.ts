import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CandidatAddComponent } from './candidat-add/candidat-add.component';
import { CandidatListComponent } from './candidat-list/candidat-list.component';
import { CandidatUpdateComponent } from './candidat-update/candidat-update.component';
import { PosteUpdateComponent } from './poste-update/poste-update.component';
import { PosteListComponent } from './poste-list/poste-list.component';
import { PosteAddComponent } from './poste-add/poste-add.component';
import { CandidatureListComponent } from './candidature-list/candidature-list.component';
import { CandidatureAddComponent } from './candidature-add/candidature-add.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CandidatAddComponent,
    CandidatListComponent,
    CandidatUpdateComponent,
    PosteListComponent,
    PosteUpdateComponent,
    PosteAddComponent,
    CandidatureListComponent,
    CandidatureAddComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'candidat', component: CandidatListComponent },
      { path: 'poste', component: PosteListComponent },
      { path: 'candidature', component: CandidatureListComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
