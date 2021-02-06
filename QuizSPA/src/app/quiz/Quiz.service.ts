import { filter, map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Question } from './interface/Question';
import { Score } from './interface/Score';

@Injectable({
  providedIn: 'root',
})
export class QuizService {
  
  isDataTrue:boolean;
  transData:Question[];

  constructor(private http: HttpClient,private router:Router) {}

  getQuestions() {
    return this.http.get<Question[]>("http://localhost:5000/quiz").pipe(tap(resData => {
      this.transData = resData.filter(v => !v.isAnswered)
    }))
  }

  getQuestion(id:number) {
    return this.http.get<Question>("http://localhost:5000/quiz/" + id).pipe(
      filter(v => {
        if(v === null) {
          this.router.navigate(['/score'])
        }
      return !v.isAnswered
    }))
  }

  answerAquestion(yourAnswer:string,id:number){
   return this.http.post<any>("http://localhost:5000/quiz/answered/" + id, yourAnswer)
  }

  resetQuiz() {
  return this.http.delete<Question[]>("http://localhost:5000/quiz/deleteData")
  }

  getScore() {
    return this.http.get<Score[]>("http://localhost:5000/quiz/score")
  }

}
