import { Component, Input, ViewChild } from '@angular/core';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { DoctorsService } from '../../../services/doctors/doctors.service';

@Component({
  selector: 'app-ask-for-serial-number',
  templateUrl: './ask-for-serial-number.component.html',
  styleUrl: './ask-for-serial-number.component.css'
})
export class AskForSerialNumberComponent {

  constructor(private employeeDataService: EmployeesDataService,
    private doctorsService: DoctorsService,
    private router: Router
  ){}

  @Input("parentModal") parentModal: any;
  @Input("type") type: 'query' | 'command';

  @ViewChild("form") form: NgForm;

  isFailure: boolean = false;
  errorMessage: string = 'الموظف غير موجود';

  serialNumber: string;

  onSubmit(): void {
    this.isFailure = false;
    this.errorMessage = '';
    
    var id: number;
    this.employeeDataService.getBySerialNumber(this.serialNumber)
    .subscribe(result => {
      if (result.status === false) {
        this.isFailure = true;
        this.errorMessage = result.errorMessage!;
        this.form.form.markAsPristine();
      }
      else {
        id = result.employeeData!.id;
        if (this.type === 'query') {
          this.router.navigateByUrl(`doctor/history/${id}`)
        }
        else {
          this.router.navigateByUrl(`doctor/visits/create/${id}`)
        }
        this.parentModal.dismiss();
      }
    })
  }

}
