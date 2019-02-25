import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {HeroCounter} from './HeroCounter'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HeroSearchService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44329/api/hero';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json'})
   }
   
  public get() {
    // Get all heroes
    var test = this.http.get(this.accessPointUrl, {headers: this.headers});
    return test;
  }

  public getHero(name) {
    // Get all heroes
    var testi = this.accessPointUrl + '/' + name;
    var test = this.http.get(this.accessPointUrl + '/' + name, {headers: this.headers});
    return test;
  }

  public getCounters(name): Observable<HeroCounter>{
    var url = 'https://localhost:44329/api/Counters/' + name;
    return this.http.get<HeroCounter>(url, {headers: this.headers});    
  }

  public searchHero(record){
    this.getHero(record);
  }
}