import { Component, Input } from '@angular/core';
import { updateDoctorUserQuery } from '../../classes/updateDoctorUserQuery';

@Component({
  selector: 'app-update-doctor-user-data-form',
  templateUrl: './update-doctor-user-data-form.component.html',
  styleUrl: './update-doctor-user-data-form.component.css'
})
export class UpdateDoctorUserDataFormComponent {

  isFailure: boolean = false;
  errorMessage: string;

  @Input("formModel") formModel: updateDoctorUserQuery;

  onSubmit(): void {

  }
}
