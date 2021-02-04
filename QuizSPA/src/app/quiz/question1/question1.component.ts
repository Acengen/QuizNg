import { QuizService } from './../Quiz.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Data, Params, Router } from '@angular/router';
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
  incrementAns:number=0;
  constructor(
    private route: ActivatedRoute,
    private srvc: QuizService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      if(data.data === null){
        this.router.navigate(['/'])
      }
      this.currentRoute = data.data.id
      this.srvc.getQuestion(data.data.id).subscribe((res) => {
        this.questions = res;
      });
    });
  }

  onSubmit(f: NgForm) {
    
    this.srvc.answerAquestion(f.value,this.currentRoute)
    if (f.value.yourAnswer) {
      this.currentRoute++;
      this.router.navigate(['question', this.currentRoute], {
        queryParams: { hello: 'anotherone' },
      });
    }
   
  }

}
