import { Component, Input, OnInit } from '@angular/core';
import { Score } from 'src/app/quiz/interface/Score';

@Component({
  selector: '.score_item',
  templateUrl: './ScoreItem.component.html',
  styleUrls: ['./ScoreItem.component.scss']
})
export class ScoreItemComponent implements OnInit {
  @Input() scoreItem:Score;
  constructor() { }

  ngOnInit() {
  }

}
