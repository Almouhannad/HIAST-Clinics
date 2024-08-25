import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { WaitingListRecord } from '../../../classes/waitingList/waiting-list-record';
import { WaitingListService } from '../../../services/waitingList/waiting-list.service';
import { ToastrService } from 'ngx-toastr';
import { DoctorsService } from '../../../services/doctors/doctors.service';

@Component({
  selector: 'app-waiting-list-item',
  templateUrl: './waiting-list-item.component.html',
  styleUrl: './waiting-list-item.component.css'
})
export class WaitingListItemComponent {

  constructor(private modalService: NgbModal,
    private waitingListService: WaitingListService,
    private toastrService: ToastrService,
    private doctorsService: DoctorsService
  ) {}

  @Input("model") model: WaitingListRecord = new WaitingListRecord(0,0,'',true, new Date(Date.now()));
  @Output("deleted") deleted: EventEmitter<any> = new EventEmitter();

  readonly types = {
    Employee: "موظف",
    FamilyMember: "أفراد عائلة"
  }
  getType() {
    if (this.model.isEmployee)
      return this.types.Employee;
    return this.types.FamilyMember;
  }

  openModal(modal: any): void {
    this.modalService.open(modal, {
      centered: true,
      size: 'md'
    });
  }

  onDelete(): void {
    this.waitingListService.delete(this.model.id)
    .subscribe(result => {
      if (result.status === true) {
        this.toastrService.success('تم الحذف بنجاح ✔');
        this.deleted.emit();
      }
      else {
        this.toastrService.error('حدث خطأ، يرجى اعادة المحاولة');
      }
    })
  }


  selectedDoctorId: number = -1;
  doctors: {id: number, name:string}[] = []
  onClickSend(): void {
    this.doctorsService.getAvailable()
    .subscribe(result => {
      if (result === null) {
        this.toastrService.error('حدثت مشكلة، يرجى إعادة المحاولة');
      }
      else {
        this.doctors = result;
      }
    })
  }

  onSendToDoctor(): void {
    this.waitingListService.SendToDoctor(this.model.id, this.model.patientId, this.selectedDoctorId)
    .subscribe(result => {
      if (result.status === true) {
        this.toastrService.success('تم الإرسال بنجاح ✔');
        this.deleted.emit();
      }
      else {
        this.toastrService.error('حدثت مشكلة، يرجى اعادة المحاولة');
      }
    })
  }
}
