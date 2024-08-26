import { Component, OnInit } from '@angular/core';
import { WaitingListRecord } from '../../../classes/waitingList/waiting-list-record';
import { WaitingListService } from '../../../services/waitingList/waiting-list.service';
import { ToastrService } from 'ngx-toastr';
import { UserData } from '../../../classes/authentication/user-data';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { Roles } from '../../../classes/authentication/roles';

@Component({
  selector: 'app-waiting-list',
  templateUrl: './waiting-list.component.html',
  styleUrl: './waiting-list.component.css'
})
export class WaitingListComponent implements OnInit {

  constructor(private waitingListService: WaitingListService,
    private toastrService: ToastrService,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.updateList();
    this.getUserData();
  }

  updateList(): void {
    this.waitingListService.getAll()
    .subscribe(result => {
      if (result === null)
        this.toastrService.error("حدثت مشكلة، يرجى إعادة المحاولة");
      else this.records = result;
    });
  }

  records: WaitingListRecord[] = [];

  onRecordDeleted(): void {
    this.updateList();
  }

  userData: UserData;
  //#region Roles
  readonly ADMIN: string = Roles.Admin;
  readonly DOCTOR: string = Roles.Doctor;
  readonly RECEPTIONIST: string = Roles.Receptionist;
  //#endregion    
  getUserData(): void {
    this.userData = this.authenticationService.getUserData()!;
  }
}
