import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AddUserDialogData } from './add-user-dialog-data';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-add-user-dialog',
    templateUrl: './add-user-dialog.component.html',
    styleUrls: ['./add-user-dialog.component.css']
})
export class AddUserDialogComponent {
    form: FormGroup;

    constructor(
        private fb: FormBuilder,
        private dialogRef: MatDialogRef<AddUserDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: AddUserDialogData) {

    }

    cancel() {
        this.dialogRef.close();
    }

    submit() {
        this.dialogRef.close(this.data);
    }

    private initForm() {
        this.form = this.fb.group({
            login: ['', Validators.compose([Validators.minLength(5), Validators.maxLength(20)])],
            password: ['', Validators.compose([Validators.minLength(8), Validators.maxLength(18)])],
            email: ['', Validators.email]
        });
    }
}
