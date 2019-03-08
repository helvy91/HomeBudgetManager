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
const service_proxies_1 = require("../../services/service-proxies/service-proxies");
const paginator_component_1 = require("../shared/paginator/paginator.component");
let UsersComponent = class UsersComponent {
    constructor(userService) {
        this.userService = userService;
        this.users = [];
        this.totalCount = 0;
        this.showDialog = false;
    }
    ngAfterViewInit() {
        this.paginator.onPageChanged.subscribe((event) => {
            this.getUsers(event.Take, event.Skip);
        });
    }
    ngOnInit() {
        this.paginator.onPageChanged.subscribe((event) => {
            this.getUsers(event.Take, event.Skip);
        });
    }
    remove(user) {
        this.showDialog = true;
        //this.userService.delete(user.id).subscribe(() => console.log('ok'), () => console.log('err'));
    }
    getUsers(take, skip) {
        this.userService.getFiltered({ take: take, skip: skip }).subscribe((response) => {
            this.users = response.items;
            this.totalCount = response.totalCount;
        });
    }
};
__decorate([
    core_1.ViewChild(paginator_component_1.PaginatorComponent),
    __metadata("design:type", paginator_component_1.PaginatorComponent)
], UsersComponent.prototype, "paginator", void 0);
UsersComponent = __decorate([
    core_1.Component({
        selector: 'app-users',
        templateUrl: './users.component.html',
        styleUrls: ['./users.component.css']
    }),
    __metadata("design:paramtypes", [service_proxies_1.UserServiceProxy])
], UsersComponent);
exports.UsersComponent = UsersComponent;
//# sourceMappingURL=users.component.js.map