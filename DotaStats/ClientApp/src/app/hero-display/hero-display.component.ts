import { Component, EventEmitter, Input, Output, OnInit} from '@angular/core';
import { HeroSearchService } from '../hero-search.service';
import {HeroCounter} from '../HeroCounter'

@Component({
  selector: 'app-hero-display',
  templateUrl: './hero-display.component.html',
  styleUrls: ['./hero-display.component.scss']
})
export class HeroDisplayComponent implements OnInit {

  @Output() heroSearched = new EventEmitter<any>();
  @Input() heroes: Array<any>;
  @Input() heroCounter: HeroCounter;

  constructor(private heroSearchService: HeroSearchService) { 
  }

  ngOnInit() {
  }




}
