import { Component, OnInit } from '@angular/core';
import { UserServiceProxy, UserDto, GetPagedDto } from '../../services/service-proxies/service-proxies';
import { MatDialog } from '@angular/material';
import { ConfirmDialogComponent } from '../components/dialogs/confirm-dialog/confirm-dialog.component';
import { BusyIndicatorService } from '../../services/busy-indicator/busy-indicator.service';
import { AddUserDialogComponent } from './add-user-dialog/add-user-dialog.component';
import { AddUserDialogData } from './add-user-dialog/add-user-dialog-data';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
    users: UserDto[] = [];

    constructor(
        private dialog: MatDialog,
        private busyIndicatorService: BusyIndicatorService,
        private userService: UserServiceProxy) { }

    ngOnInit() {
        this.fillData()
    }

    remove(user: UserDto): void {
        let dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: '600px',
            data: {
                title: 'Delete user',
                body: 'Are you sure you want delete user: ' + user.login + '?'
            }
        });

        dialogRef.afterClosed().subscribe((result: boolean) => {
            if (result) {
                this.busyIndicatorService.show();
                this.userService.delete(user.id).subscribe(() => {
                    this.busyIndicatorService.hide();
                    this.fillData();
                }, () => {
                    this.busyIndicatorService.hide();
                });
            }
        });
    }

    addUser(): void {
        let dialogRef = this.dialog.open(AddUserDialogComponent, {
            width: '600px',
            data: new AddUserDialogData()
        });

        dialogRef.afterClosed().subscribe((data: AddUserDialogData) => {
            let user = new UserDto();

        });
    }

    private fillData(): void {
        this.busyIndicatorService.show();
        this.userService.getFiltered(<GetPagedDto>{ take: 100, skip: 0 }).subscribe((response) => {
            this.users = response.items;
            this.busyIndicatorService.hide();
        }, () => {
            this.busyIndicatorService.hide();
        });
    }
}
