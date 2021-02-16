import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-numbersItem',
  templateUrl: './numbersItem.component.html',
  styleUrls: ['./numbersItem.component.scss']
})
export class NumbersItemComponent implements OnInit {
 @Input() numberSum:any;
 numberisadded:boolean;
 
  constructor() { }

  ngOnInit() {
    
  }
  
  addNumber(num) {
    this.numberisadded = !this.numberisadded;
   
    
  }

  setClasses() {
    let classes = null;

    if(this.numberisadded){
      classes = "isAdded"
    }else {
      classes = null
    }

    return classes
  }
}
