import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { BusyIndicatorState } from './busy-indicator-state';

@Injectable()

export class BusyIndicatorService {

    private busyIndicatorSubject = new Subject<BusyIndicatorState>();

    busyIndicatorState = this.busyIndicatorSubject.asObservable();

constructor() { }

show() {
    this.busyIndicatorSubject.next(<BusyIndicatorState>{show: true});
    }

hide() {
    this.busyIndicatorSubject.next(<BusyIndicatorState>{show: false});
    }
}