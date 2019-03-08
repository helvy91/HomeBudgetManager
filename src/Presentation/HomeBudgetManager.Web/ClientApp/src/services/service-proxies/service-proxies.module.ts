import { NgModule } from '@angular/core';

import * as ApiServiceProxies from './service-proxies';

@NgModule({
    providers: [
        ApiServiceProxies.TokenServiceProxy,
        ApiServiceProxies.UserServiceProxy
    ]
})
export class ServiceProxyModule { }
