import { Injectable } from '@angular/core';
import { TokenServiceProxy, TokenRequest, TokenResponse, TokenRequestType, CreateUserDto } from '../service-proxies/service-proxies';
import { Observable } from 'rxjs';
import 'rxjs/Rx';

@Injectable()
export class AuthService {
    private key: string = "HBM:Auth";

    constructor(private proxy: TokenServiceProxy) {
    }

    login(username: string, password: string): Observable<void> {
        let user = new CreateUserDto();
        user.login = username;
        user.password = password;

        let request = new TokenRequest();
        request.requestType = TokenRequestType.Token;
        request.user = user;

        return this.proxy.getToken(request).map(res => {
            if (res) {
                this.setToken(res);
            } else {
                return Observable.throw('Unauthorized');
            }
        }).catch(error => {
            return new Observable<any>(error);
        });
    }

    logout(): void {
        this.setToken(null);
    }

    isLoggedIn(): boolean {
        return this.getToken() != null;
    }

    getToken(): TokenResponse | null {
        let token = localStorage.getItem(this.key);
        if (token) {
            return JSON.parse(token);
        } else {
            return null;
        }
    }

    private setToken(token: TokenResponse | null): void {
        if (token) {
            localStorage.setItem(this.key, JSON.stringify(token));
        } else {
            localStorage.setItem(this.key, null);
        }
    }
}