import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserData } from '../../../../classes/authentication/user-data';
import { AuthenticationService } from '../../../../services/authentication/authentication.service';
import { Router } from '@angular/router';
import { Roles } from '../../../../classes/authentication/roles';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ViewportScroller } from '@angular/common';
import { ConstantMessages } from '../../../../constants/messages';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  //#region CTOR DI
  constructor(private authenticationService: AuthenticationService,
    private router: Router,
    private modalService: NgbModal,
    private toastrService: ToastrService,
    private scroller: ViewportScroller
  ) { }
  //#endregion

  //#region Inputs
  @Input("userData") userData: UserData | null = null;
  //#endregion

  // #region Outputs
  @Output("loggedIn") loggedIn: EventEmitter<any> = new EventEmitter();
  
  // #endregion

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

  //#region Open pop-up
  openPopUp(content: any): void {
    this.modalService.open(content, {
      centered: true,
      size: 'md'
    });
  }

  //#endregion

  //#region Login event
  onLogin(userData: UserData)
  {
    this.userData = userData;
    this.router.navigate(['']);
    this.selectedButton = 'Home';
    this.scroller.scrollToPosition([0,0]);
    this.loggedIn.emit();
  }
  //#endregion

  //#endregion

  //#region On logout
  onLogout(): void {
    this.authenticationService.logout();
    this.toastrService.success(ConstantMessages.SUCCESS_LOGOUT);
    this.userData = null;
    this.showDropdown = false;
    this.selectedButton = 'Home';
    this.router.navigate(['']);
    this.scroller.scrollToPosition([0,0]);
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
