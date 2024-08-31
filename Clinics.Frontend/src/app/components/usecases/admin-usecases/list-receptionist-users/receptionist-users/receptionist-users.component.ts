import { Component, OnInit } from '@angular/core';
import { ReceptionistUser } from '../../../../../classes/usecases/admin-usecases/list-receptionist-users/receptionist-user';
import { ReceptionistUsersService } from '../../../../../services/receptionist-users/receptionist-users.service';

@Component({
  selector: 'app-receptionist-users',
  templateUrl: './receptionist-users.component.html',
  styleUrl: './receptionist-users.component.css'
})
export class ReceptionistUsersComponent implements OnInit {

  constructor(private usersService: ReceptionistUsersService) {}

  ngOnInit(): void {
    this.usersService.getAllReceptionistUsers()
    .subscribe(result => {
      if (result.status === true) {
        this.receptionistUsers = result.receptionistUsers!;
      }
      else {
        console.error(result.errorMessage!);
      }
    })
  }

  receptionistUsers: ReceptionistUser[];
}
