import { QuizService } from './../Quiz.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { Question } from '../interface/Question';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-question1',
  templateUrl: './question1.component.html',
  styleUrls: ['./question1.component.scss'],
})
export class Question1Component implements OnInit {
  currentRoute: number;
  questions: Question;
  answerCorrected: boolean = null;
  yourAnswer: string;
  isDataThere:boolean;
  constructor(
    private route: ActivatedRoute,
    private srvc: QuizService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      this.questions = data.data;
      this.currentRoute = data.data.id;
    });
  }

  onSubmit(f: NgForm) {
    this.srvc.answerAquestion(f.value, this.currentRoute).subscribe((res) => {
    });
    this.isCorrect(f.value.yourAnswer);
    if (f.value.yourAnswer) {
      this.currentRoute++;
      this.router.navigate(['question', this.currentRoute]);
    }
  }

  resetQuiz() {
    this.srvc.resetQuiz().subscribe((res) => {
      if (confirm('Are you sure? You will lose all points')) {
        this.router.navigate(['question/1']);
      }
    });
  }

  isCorrect(formvalue: any) {
    this.answerCorrected = true
      ? this.questions.correctAnswer === formvalue
      : false;

    setTimeout(() => {
      this.answerCorrected = null;
    }, 500);
  }
}
