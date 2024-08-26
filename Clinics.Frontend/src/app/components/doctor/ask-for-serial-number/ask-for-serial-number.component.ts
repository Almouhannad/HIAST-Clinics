import { Component, Input } from '@angular/core';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ask-for-serial-number',
  templateUrl: './ask-for-serial-number.component.html',
  styleUrl: './ask-for-serial-number.component.css'
})
export class AskForSerialNumberComponent {

  constructor(private employeeDataService: EmployeesDataService,
    private router: Router
  ){}

  @Input("parentModal") parentModal: any;
  @Input("type") type: 'query' | 'command';

  isFailure: boolean = false;
  errorMessage: string = 'الموظف غير موجود';

  serialNumber: string;

  onSubmit(): void {
    var id: number;
    this.employeeDataService.getBySerialNumber(this.serialNumber)
    .subscribe(result => {
      if (result.status === false) {
        this.isFailure = true;
        this.errorMessage = result.errorMessage!;
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
