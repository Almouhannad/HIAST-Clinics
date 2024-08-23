import { Component, OnInit } from '@angular/core';
import { DoctorUsersService } from '../../../services/doctor-users.service';
import { DoctorUserResponse } from '../../classes/doctor-user-response';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-doctor-user',
  templateUrl: './update-doctor-user.component.html',
  styleUrl: './update-doctor-user.component.css'
})
export class UpdateDoctorUserComponent implements OnInit{

  // #region CTOR DI
  constructor(private doctorUsersService: DoctorUsersService,
    private route: ActivatedRoute
  ){}
  // #endregion

  // #region On init
  ngOnInit(): void {
      this.doctorUserId = Number(this.route.snapshot.paramMap.get('id'));
      this.doctorUsersService.getDoctorUserById(this.doctorUserId)
      .subscribe( doctorUser => {
        this.doctorUser = doctorUser!;
          }
      )
  }
  // #endregion

  // #region Variables

  doctorUserId: number;
  doctorUser: DoctorUserResponse;

  isUserDataSelected: boolean = false;
  isPersonalInfoSelected: boolean = false;

  // #endregion

  // #region Methods
    public getUserFullName(): string {
      return `${this.doctorUser.firstName} ${this.doctorUser.middleName} ${this.doctorUser.lastName}`
    }

  // #endregion
  
}
