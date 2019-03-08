"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const forms_1 = require("@angular/forms");
const auth_service_1 = require("../../services/auth/auth-service");
let LoginComponent = class LoginComponent {
    constructor(fb, authService) {
        this.fb = fb;
        this.authService = authService;
        this.createForm();
    }
    createForm() {
        this.form = this.fb.group({
            Username: ['', forms_1.Validators.compose([forms_1.Validators.minLength(3), forms_1.Validators.maxLength(16)])],
            Password: ['', forms_1.Validators.compose([forms_1.Validators.minLength(8), forms_1.Validators.maxLength(16)])]
        });
    }
    onSubmit() {
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
    hasError(name) {
        let e = this.getFormControl(name);
        return e && (e.dirty || e.touched) && !e.valid;
    }
    getFormControl(name) {
        return this.form.get(name);
    }
};
LoginComponent = __decorate([
    core_1.Component({
        selector: 'login',
        templateUrl: './login.component.html',
        styleUrls: ['./login.component.css']
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, auth_service_1.AuthService])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map