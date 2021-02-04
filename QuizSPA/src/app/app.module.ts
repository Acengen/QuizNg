import { Question1Component } from './quiz/question1/question1.component';
import { QuizComponent } from './quiz/quiz.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import {HttpClientModule} from '@angular/common/http'
import { QuizResolverService } from './quiz/quizResolver.service';

const routes:Routes = [
  {path:"", redirectTo:"/quiz", pathMatch:"full"}, 
  {path:"quiz", component:QuizComponent},
  {path:"question/:id",component:Question1Component,resolve:{data:QuizResolverService}},
]

@NgModule({
  declarations: [
    AppComponent,
    QuizComponent,
    Question1Component
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
