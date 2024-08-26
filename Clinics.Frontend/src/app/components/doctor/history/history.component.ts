import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeData } from '../../../classes/employeeData/employee-data';
import { VisitView } from '../../../classes/visit/visit-view';
import { VisitsService } from '../../../services/visits/visits.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent  implements OnInit {
  constructor(private employeesDataService: EmployeesDataService,
    private route: ActivatedRoute,
    private toastrService: ToastrService,
    private router: Router,
    private visitsService: VisitsService
  ) {}

  ngOnInit(): void {
      this.setId();
  }

  patientId: number;
  setId(): void {
    this.route.params.subscribe((params: any) => {
      this.patientId = Number(params.id);
      if (isNaN(this.patientId)) {
        this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
        this.router.navigateByUrl('doctor/waitinglist');
      }
      this.getEmployee();
      this.getVisits();

    });
  }

  employee: EmployeeData = new EmployeeData();
  getEmployee(): void {
    this.employeesDataService.getById(this.patientId)
    .subscribe(result => {
      if (result.status === false) {
        this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
        this.router.navigateByUrl('doctor/waitinglist');
      }
      else {
        this.employee = result.employeeData!;
      }
    })
  }
  getEmployeeFullName(): string {
    return `${this.employee.firstName} ${this.employee.middleName} ${this.employee.lastName}`;
  }

  visits: VisitView[];
  getVisits(): void {
    this.visitsService.getAllByPatientId(this.patientId)
    .subscribe(result => {
      if (result.status === false) {
        this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
        this.router.navigateByUrl('doctor/waitinglist');
      }
      else {
        this.visits = result.visits!;
      }
    })
  }

}
