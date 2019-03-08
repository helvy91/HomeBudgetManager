import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from '../../services/auth/auth-service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent {
    form: FormGroup;

    constructor(private fb: FormBuilder, private authService: AuthService) {
        this.createForm();
    }

    createForm(): void {
        this.form = this.fb.group({
            Username: ['', Validators.compose([Validators.minLength(3), Validators.maxLength(20)])],
            Password: ['', Validators.compose([Validators.minLength(8), Validators.maxLength(18)])]
        });
    }

    onSubmit(): void {
        let username = this.form.value.Username;
        let password = this.form.value.Password;
        this.authService.login(username, password).subscribe(() => {
            window.location.href = "/dashboard";
        }, () => {
            this.form.setErrors({
                "auth": "Incorrect username or password"
            });
        });
    }

    hasError(name: string): boolean {
        let e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    }

    getFormControl(name: string): FormControl {
        return this.form.get(name) as FormControl;
    }
}
