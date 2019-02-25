import { Component, OnInit } from '@angular/core';
import { HeroSearchService } from '../hero-search.service';
import {HeroCounter} from '../HeroCounter'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {


  heroName: string;
  public heroes: Array<any>;
  public currentHero: any;
  public heroCounter: HeroCounter;

  constructor(private heroSearchService:HeroSearchService) {
    this.heroCounter = new HeroCounter;
   }

  ngOnInit() {
  }

  public onKeydown(event){
    if(event.key === "Enter"){
      this.searchHero();
    }
  }

  public searchHero(){
    this.heroSearchService.getCounters(this.heroName).subscribe((data: HeroCounter) => this.heroCounter = data);
  }
}
