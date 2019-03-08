import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

import { BusyIndicatorService } from '../../../services/busy-indicator/busy-indicator.service';
import { BusyIndicatorState } from '../../../services/busy-indicator/busy-indicator-state';

@Component({
    selector: 'app-busy-indicator',
    templateUrl: 'busy-indicator.component.html',
    styleUrls: ['busy-indicator.component.css']
})
export class BusyIndicatorComponent implements OnInit {

    show = false;

    private subscription: Subscription;

    constructor(
        private busyIndicatorService: BusyIndicatorService
    ) { }

    ngOnInit() {
        this.subscription = this.busyIndicatorService.busyIndicatorState
            .subscribe((state: BusyIndicatorState) => {
                this.show = state.show;
            });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}