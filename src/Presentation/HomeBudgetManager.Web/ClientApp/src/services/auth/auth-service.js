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
const service_proxies_1 = require("../service-proxies/service-proxies");
const rxjs_1 = require("rxjs");
require("rxjs/Rx");
let AuthService = class AuthService {
    constructor(proxy) {
        this.proxy = proxy;
        this.key = "HBM:Auth";
    }
    login(username, password) {
        let user = new service_proxies_1.CreateUserDto();
        user.login = username;
        user.password = password;
        let request = new service_proxies_1.TokenRequest();
        request.requestType = service_proxies_1.TokenRequestType.Token;
        request.user = user;
        return this.proxy.getToken(request).map(res => {
            if (res) {
                this.setToken(res);
            }
            else {
                return rxjs_1.Observable.throw('Unauthorized');
            }
        }).catch(error => {
            return new rxjs_1.Observable(error);
        });
    }
    logout() {
        this.setToken(null);
    }
    isLoggedIn() {
        return this.getToken() != null;
    }
    getToken() {
        let token = localStorage.getItem(this.key);
        if (token) {
            return JSON.parse(token);
        }
        else {
            return null;
        }
    }
    setToken(token) {
        if (token) {
            localStorage.setItem(this.key, JSON.stringify(token));
        }
        else {
            localStorage.setItem(this.key, null);
        }
    }
};
AuthService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [service_proxies_1.TokenServiceProxy])
], AuthService);
exports.AuthService = AuthService;
//# sourceMappingURL=auth-service.js.map