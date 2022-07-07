import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimerService {

  private _subject = new Subject<any>()

  constructor() { }

  orderTaken(event){
    this._subject.next(event);
  }

  get events$(){
    return this._subject.asObservable()
  }

}
