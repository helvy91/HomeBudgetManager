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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const material_1 = require("@angular/material");
const confirm_dialog_data_1 = require("./confirm-dialog-data");
let ConfirmDialogComponent = class ConfirmDialogComponent {
    constructor(dialogRef, data) {
        this.dialogRef = dialogRef;
        this.data = data;
    }
    cancel() {
        this.dialogRef.close(false);
    }
    submit() {
        this.dialogRef.close(true);
    }
};
ConfirmDialogComponent = __decorate([
    core_1.Component({
        selector: 'app-confirm-dialog',
        templateUrl: './confirm-dialog.component.html',
        styleUrls: ['./confirm-dialog.component.css']
    }),
    __param(1, core_1.Inject(material_1.MAT_DIALOG_DATA)),
    __metadata("design:paramtypes", [material_1.MatDialogRef,
        confirm_dialog_data_1.ConfirmDialogData])
], ConfirmDialogComponent);
exports.ConfirmDialogComponent = ConfirmDialogComponent;
//# sourceMappingURL=confirm-dialog.component.js.map