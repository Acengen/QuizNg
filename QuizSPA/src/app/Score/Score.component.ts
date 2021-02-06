import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Score } from '../quiz/interface/Score';
import { QuizService } from '../quiz/Quiz.service';

@Component({
  selector: 'app-Score',
  templateUrl: './Score.component.html',
  styleUrls: ['./Score.component.scss']
})
export class ScoreComponent implements OnInit {
  score:Score[]
  points:number = 0;
  totalPoints:number=0;
  constructor(private service:QuizService,private router:Router) { }

  ngOnInit() {
    this.service.getQuestions().subscribe(resdata => {
      
      resdata.map(v => {
        this.totalPoints += v.points
      })
    })
    this.service.getScore().subscribe(res => {
      this.score = res;
      this.score.map(v => {
        this.points += v.pointEarned
      })
    })
  }

}
