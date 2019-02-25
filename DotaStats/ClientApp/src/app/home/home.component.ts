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
    //heroSearchService.get().subscribe((data: any) => this.heroes = data);
   }

  ngOnInit() {
  }

  public searchHero(){
    //var result = this.heroSearchService.getCounters(this.heroName);
    //this.heroCounter.name = result.
    // var testi = this.heroSearchService.get();
    this.heroSearchService.getCounters(this.heroName).subscribe((data: HeroCounter) => this.heroCounter = data);
    // this.heroSearched.emit(this.heroName);
    // this.heroName = "";
    var testi = this.heroCounter;
    var blup = testi.SearchedHero;
    var blup2 = testi.HeroCounters;
    var blep = testi.name;
  }
}
