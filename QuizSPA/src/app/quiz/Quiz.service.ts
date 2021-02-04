import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Question } from './interface/Question';

@Injectable({
  providedIn: 'root',
})
export class QuizService {
  constructor(private http: HttpClient) {}

  getQuestion(id:number) {
    return this.http.get<Question>("http://localhost:5000/quiz/" + id);
  }

  answerAquestion(yourAnswer:string,id:number){
    this.http.post<any>("http://localhost:5000/quiz/answered/" + id, yourAnswer).subscribe(resData => {
    })
  }
}
