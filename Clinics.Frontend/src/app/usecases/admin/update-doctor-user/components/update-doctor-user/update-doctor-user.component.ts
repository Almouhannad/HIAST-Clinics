import { Component, OnInit } from '@angular/core';
import { DoctorUsersService } from '../../../services/doctor-users.service';
import { DoctorUserResponse } from '../../classes/doctor-user-response';
import { ActivatedRoute } from '@angular/router';
import { UpdateDoctorPersonalDataQuery } from '../../update-doctor-personal-data/classes/update-doctor-personal-data-query';
import { updateDoctorUserQuery } from '../../update-doctor-user-data/classes/update-doctor-user-query';

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
        this.editPersonalDataQuery = new UpdateDoctorPersonalDataQuery(doctorUser!.id,
          this.doctorUser.firstName, this.doctorUser.middleName,
          this.doctorUser.lastName
          );
        this.editUserDataQuery = new updateDoctorUserQuery(doctorUser!.id, doctorUser!.userName);
        }
      )
  }
  // #endregion

  // #region Variables

  doctorUserId: number;
  doctorUser: DoctorUserResponse = new DoctorUserResponse();
  editPersonalDataQuery: UpdateDoctorPersonalDataQuery;
  editUserDataQuery: updateDoctorUserQuery;

  isUserDataSelected: boolean = false;
  isPersonalInfoSelected: boolean = false;

  // #endregion

  // #region Methods
    public getUserFullName(): string {
      return `${this.doctorUser.firstName} ${this.doctorUser.middleName} ${this.doctorUser.lastName}`
    }

  // #endregion
  
}
