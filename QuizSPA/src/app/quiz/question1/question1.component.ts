import { QuizService } from './../Quiz.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Question } from '../interface/Question';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-question1',
  templateUrl: './question1.component.html',
  styleUrls: ['./question1.component.scss'],
})
export class Question1Component implements OnInit {
  currentRoute: number;
  Question: Question;
  constructor(
    private route: ActivatedRoute,
    private srvc: QuizService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((param: Params) => {
      this.currentRoute = +param['id'];
      console.log(this.currentRoute);
      this.srvc.getQuestion(+param['id']).subscribe((res) => {
        this.Question = res;
      });
    });
  }

  onSubmit(f: NgForm) {
    if (f.value.question) {
      this.currentRoute++;
      this.router.navigate(['question', this.currentRoute], {
        queryParams: { hello: 'anotherone' },
      });
      localStorage.setItem("Submitted",f.value.question);
    }
  }
}
