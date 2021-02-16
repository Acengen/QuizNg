import { NumbersItemComponent } from './mathematic/numbersItem/numbersItem.component';
import { QuizGuardGuard } from './quiz/question1/quiz-guard.guard';
import { ScoreItemComponent } from './Score/ScoreItem/ScoreItem.component';
import { Question1Component } from './quiz/question1/question1.component';
import { QuizComponent } from './quiz/quiz.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import {HttpClientModule} from '@angular/common/http'
import { QuizResolverService } from './quiz/quizResolver.service';
import { ScoreComponent } from './Score/Score.component';
import { MathematicComponent } from './mathematic/mathematic.component';

const routes:Routes = [
  {path:"", redirectTo:"/quiz", pathMatch:"full"}, 
  {path:"quiz", component:QuizComponent},
  {path:"question/:id",component:Question1Component,resolve:{data:QuizResolverService}},
  {path:"math",component:MathematicComponent},
  {path:"score", component:ScoreComponent},
]

@NgModule({
  declarations: [			
    AppComponent,
    QuizComponent,
    Question1Component,
    ScoreComponent,
    ScoreItemComponent,
    MathematicComponent,
    NumbersItemComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
