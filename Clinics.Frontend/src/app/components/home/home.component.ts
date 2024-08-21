import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  //#region CTOR DI
  constructor (private modalService: NgbModal) {}
  //#endregion

  //#region Login
  openLoginForm (content: any): void {
    this.modalService.open(content);
  }
  //#endregion
}
