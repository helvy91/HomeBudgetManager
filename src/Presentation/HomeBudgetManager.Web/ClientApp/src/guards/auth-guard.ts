import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from '../services/auth/auth-service';

@Injectable()
export class AuthGuard implements CanActivate {
    private key: string = "HBM:Auth";

    constructor(private auth: AuthService, private router: Router) {
    }

    canActivate(): boolean {
        if (!this.auth.isLoggedIn()) {
            this.router.navigate(['login']);
            return false;
        }
        return true;
    }
}