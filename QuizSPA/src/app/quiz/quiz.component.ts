import { transformAll } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Question } from './interface/Question';
import { QuizService } from './Quiz.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {
  routeToContinue:number;
  transData:Question[] = [];
  globalData:Question[] =[];
  imageGallery:any[] = ['../../assets/800px_COLOURBOX20569310.jpg','../../assets/shutterstock_1214717467-900x506.jpg','../../assets/Learning-Styles_SOC-MED_OpenGraphImage1-1200x1199.png'];
  imgCounter:number = 0;
  imageToShow:any;
  constructor(private serivce:QuizService,private router:Router) { }

  ngOnInit() {
    this.imgSlides()
    this.serivce.getQuestions().subscribe(res => {
      this.globalData = res
      this.transData = this.serivce.transData;
      console.log(this.transData)
       if(this.transData.length !== 0){
        this.routeToContinue = this.transData[0].id;
       }
    })
  }

  goToPage() {
    this.router.navigate(['/question', this.routeToContinue])
  }

  resetQuiz() {
    this.serivce.resetQuiz().subscribe(res => {
      this.transData = res;
      this.routeToContinue = this.transData[0].id;
    });
  }

  imgSlides() {
    this.imageToShow = this.imageGallery[this.imgCounter];
    setInterval(() => {
        this.imgCounter++
        this.imageToShow = this.imageGallery[this.imgCounter];
        if(this.imageToShow === undefined){
          this.imgCounter = 0;
          this.imageToShow = this.imageGallery[this.imgCounter]
        }
    },5000)
    
  }

}
