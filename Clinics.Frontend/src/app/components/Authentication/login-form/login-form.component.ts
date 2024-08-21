import { Component, Input, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginCommand } from '../../../classes/Authentication/login-command';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent {

  //#region Inputs
  @Input("parentModal") parentModal : any;
  //#endregion

  //#region Variables
  @ViewChild("loginForm") loginForm: NgForm;
  formModel: LoginCommand = new LoginCommand();
  //#endregion

  //#region On submit
  onSubmit(): void {}
  //#endregion 


}
