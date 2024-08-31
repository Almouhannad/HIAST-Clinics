import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeesDataService } from '../../../services/employees/employees-data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeData } from '../../../classes/employeeData/employee-data';
import { ToastrService } from 'ngx-toastr';
import { MedicineView } from '../../../classes/medicine/medicine-view';
import { VisitMedicine } from '../../../classes/medicine/visit-medicine';
import { VisitsService } from '../../../services/visits/visits.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { DoctorsService } from '../../../services/doctors/doctors.service';
import { ConstantMessages } from '../../../constants/messages';

@Component({
  selector: 'app-create-visit',
  templateUrl: './create-visit.component.html',
  styleUrl: './create-visit.component.css'
})
export class CreateVisitComponent implements OnInit {
  constructor(private modalService: NgbModal,
    private employeesDataService: EmployeesDataService,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router,
    private doctorsService: DoctorsService,
    private authenticationService: AuthenticationService,
    private visitsService: VisitsService
  ) {}

  ngOnInit(): void {
      this.listenToRouteChanges();
  }

  employeeId: number;
  listenToRouteChanges(): void {
    this.activatedRoute.params.subscribe(params => {
      this.employeeId = params['id'];
      if (isNaN(this.employeeId)) {
        this.toastr.error(ConstantMessages.ERROR);
        this.router.navigateByUrl('doctor/waitinglist');
      }
      this.setEmployee();
    })
  }

  employee: EmployeeData = new EmployeeData;
  setEmployee(): void {
    this.employeesDataService.getById(this.employeeId)
    .subscribe(result => {
      if (result.status === false) {
        this.toastr.error(ConstantMessages.ERROR);
        this.router.navigateByUrl('doctor/waitinglist');
      }
      else {
        this.employee = result.employeeData!;
      }
    })
  }
  getEmployeeFullName(): string {
    return `${this.employee.firstName} ${this.employee.middleName} ${this.employee.lastName}`
  }

  openMedicinesModal(modal: any): void {
    this.modalService.open(modal, {
      centered: true,
      size: 'md'
    });
  }

  openVisitsModal(modal: any): void {
    this.modalService.open(modal, {
      centered: true,
      size: 'lg'
    });
  }

  isMedicinesSectionOpen: boolean = false;
  isOptionsSectionOpen: boolean = false;

  diagnosis: string;
  medicines: VisitMedicine[] = [];
  onAddMedicine(visitMedicine: VisitMedicine) {
    const existingMedicine = this.medicines.find(medicine => medicine.id === visitMedicine.id);
    if (!existingMedicine) {
      this.medicines.push(visitMedicine);
    }
    else {
      this.toastr.error(ConstantMessages.ERROR_ALREADY_ADDED_MEDICINE);
    }
  }
  onDeleteMedicine(index: number) {
    this.medicines.splice(index, 1);
  }

  onSubmit(): void {
    if (this.medicines.length !== 0) {
      var userId = this.authenticationService.getUserData()!.id;
      this.visitsService.create(userId,
      this.employeeId, this.diagnosis, this.medicines)
      .subscribe(result => {
        if(result.status === false) {
          this.toastr.error(ConstantMessages.ERROR);
          this.router.navigateByUrl('doctor/waitinglist');
        }
        else {
          this.doctorsService.changeStatusByUserId(userId, 'متاح')
          .subscribe(_ => {});
          this.toastr.success(ConstantMessages.SUCCESS_ADD_VISIT);
          this.router.navigateByUrl(`doctor/history/${this.employeeId}`);
        }
      })
    }
    else {
      this.toastr.error(ConstantMessages.ERROR_NO_MEDICINES);
    }


  }
}
