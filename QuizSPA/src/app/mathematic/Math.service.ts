import { tap, map, filter } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Math } from './mathinterface';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MathService {
  bigNumber: Math;
  bigNumberEmitter = new Subject<Math>();
  numbersToSum: any[];

  constructor(private http: HttpClient) {}
  getBigNumber() {
    return this.http.get<Math[]>('http://localhost:5000/math').pipe(
      tap(res => {
        res.map(v => {
          return this.bigNumber = v;
        })
      })
    );
  }

  getNumbers() {
    return this.http
      .get<any[]>('http://localhost:5000/math/numbersToSum')
      .pipe(tap(data => {
        
        this.numbersToSum = data;
      }));
  }
  addNumber(randomValue){
   return this.http.post<any[]>("http://localhost:5000/math/numberGen",randomValue).pipe(tap(res => {
      if(!res) {
        return;
      }
      this.numbersToSum.push(res)
    }))
  }

  addBigNumber() {
    this.http.post<Math>("http://localhost:5000/math/result",{}).subscribe(res => {
        this.bigNumber = res
        this.bigNumberEmitter.next(this.bigNumber);
    })

  }
}
