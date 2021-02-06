import { QuizService } from './Quiz.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Question } from './interface/Question';

@Injectable({
  providedIn: 'root'
})
export class QuizResolverService implements Resolve<Question> {

constructor(private service:QuizService,private router:Router) { }

resolve(route:ActivatedRouteSnapshot,status:RouterStateSnapshot) : Observable<Question> | Promise<Question> | Question{
  return this.service.getQuestion(+route.params['id'])
}

}
