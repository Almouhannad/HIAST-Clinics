import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginCommand } from '../../../../../classes/usecases/shared-usecases/login/login-command';
import { AuthenticationService } from '../../../../../services/authentication/authentication.service';
import { UserData } from '../../../../../classes/authentication/user-data';
import { ToastrService } from 'ngx-toastr';
import { ConstantMessages } from '../../../../../constants/messages';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent {

  //#region CTOR DI
  constructor(private authenticationService: AuthenticationService,
    private toastrService: ToastrService
  ) {}
  //#endregion

  //#region Inputs
  @Input("parentModal") parentModal : any;
  //#endregion

  //#region Outputs
  @Output("loggedIn") loggedIn: EventEmitter<UserData> = new EventEmitter();
  //#endregion

  //#region Variables
  @ViewChild("loginForm") loginForm: NgForm;
  formModel: LoginCommand = new LoginCommand();

  isFailure: boolean = false;
  errorMessage: string = '';
  //#endregion

  //#region On submit
  onSubmit(): void
  {
    if (this.loginForm.valid){
      this.isFailure = false;
      this.errorMessage = '';
  
      this.authenticationService.login(this.formModel)
      .subscribe(
        result => {
          if (result.status === false){
            this.isFailure = true;
            this.errorMessage = result.errorMessage!;
          }
          else{
            this.toastrService.success(ConstantMessages.SUCCESS_LOGIN);
            this.loggedIn.emit(this.authenticationService.getUserData()!);
          }
        }
      );
      this.loginForm.form.markAsPristine();
    }
  }
  //#endregion 

}
