import { Component, OnInit } from '@angular/core';
import { UserData } from '../../../../../authentication/classes/user-data';
import { AuthenticationService } from '../../../../../authentication/services/authentication.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit {

  //#region CTOR DI
  constructor(private authenticationService: AuthenticationService){}
  //#endregion

  //#region On init
  ngOnInit(): void {
    this.userData = this.authenticationService.getUserData();
  }
  //#endregion

  //#region Variables
  userData: UserData | null = null;
  //#endregion

}