
export class HeroCounter{
    name: string;
    SearchedHero: Hero;
    HeroCounters: Array<Hero>;
  }

  export class Hero
    {
        id :Int32Array;
        name:string;
        localized_name: string;
        primary_attr: string;
        attack_type: string;
        roles: Array<string>; 
        legs: Int32Array;
        winRateFavor: string;
    }