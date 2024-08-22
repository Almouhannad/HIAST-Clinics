import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserData } from '../../../classes/Authentication/user-data';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { Router } from '@angular/router';
import { Roles } from '../../../classes/Authentication/roles';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  //#region CTOR DI
  constructor(private authenticationService: AuthenticationService,
    private router: Router,
    private modalService: NgbModal) { }
  //#endregion

  //#region Inputs
  @Input("userData") userData: UserData | null = null;
  //#endregion

  //#region Variables

  //#region Roles
    readonly ADMIN: string = Roles.Admin;
    readonly DOCTOR: string = Roles.Doctor;
    readonly RECEPTIONIST: string = Roles.Receptionist;
  //#endregion

  //#region Dropdown
  showDropdown: boolean = false;
  //#endregion

  //#endregion

  //#region Login

  //#region Login form pop-up
  openLoginForm(content: any): void {
    this.modalService.open(content);
  }

  //#endregion

  //#region Login event
  onLogin(userData: UserData)
  {
    this.userData = userData;
  }
  //#endregion

  //#endregion

  //#region On logout
  onLogout(): void {
    this.authenticationService.logout();
    this.userData = null;
    this.showDropdown = false;
    this.router.navigate(['']);
  }
  //#endregion

  //#region Selected button
  private selectedButton: string = 'Home';

  isSelected(buttonName: string): boolean {
    return this.selectedButton === buttonName;
  }

  selectButton(buttonName: string): void {
    this.selectedButton = buttonName;
  }
  //#endregion

}
