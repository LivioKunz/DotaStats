import { Component, OnInit } from "@angular/core";
import { HeroSearchService } from "../hero-search.service";
import { HeroCounter } from "../HeroCounter";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  heroName: string;
  heroNames: Array<string> = [];
  public heroes: Array<any>;
  public currentHero: any;
  public heroCounter: HeroCounter;

  constructor(private heroSearchService: HeroSearchService) {
    this.heroCounter = new HeroCounter();
  }

  ngOnInit() {}

  public onKeydown(event) {
    if (event.key === "Enter") {
      this.searchHeroes();
    }
  }
  searchHeroes() {
    if (this.heroNames.indexOf(this.heroName) === -1) {
      this.heroNames.push(this.heroName);
      this.heroName = "";
      this.heroSearchService
        .getCounters(this.heroNames)
        .subscribe((data: HeroCounter) => (this.heroCounter = data));
    }
  }

  // public searchHero(){
  //   this.heroSearchService.getCounters(this.heroName).subscribe((data: HeroCounter) => this.heroCounter = data);
  // }
}
