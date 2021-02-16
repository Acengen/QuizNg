import { MathService } from './Math.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Math } from './mathinterface';
import { NgForm } from '@angular/forms';
import { INumber } from './numberInterface';


@Component({
  selector: 'app-mathematic',
  templateUrl: './mathematic.component.html',
  styleUrls: ['./mathematic.component.scss']
})
export class MathematicComponent implements OnInit {
  numbersToSum:INumber[];
  
  isNumberAdded:boolean;
  mathOp = ["(",")","*","+","-","/"];
  bignumber:Math;
  keys:any[] = [];
  result:string = ''
  num:string;
  constructor(private service:MathService) { }

  ngOnInit() {
    this.service.getNumbers().subscribe(res => {
      this.numbersToSum = this.service.numbersToSum;
    });
    this.service.getBigNumber().subscribe(res => {
      this.bignumber = this.service.bigNumber;
    });

    this.service.bigNumberEmitter.subscribe(big => this.bignumber = big);
  }

  postNumber(){
    let num = {
        number:0
    };
    this.service.addNumber(num).subscribe(res => {
    })
  }

  postBigNumber() {
    this.service.addBigNumber();
  }

  onChange(num:NgForm) {
    let key = null;
    key += num.value.number
    console.log(key)
  }

  

}
