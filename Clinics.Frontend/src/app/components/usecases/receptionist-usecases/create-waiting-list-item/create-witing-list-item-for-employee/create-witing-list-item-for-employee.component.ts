import { Component, Input, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { WaitingListService } from '../../../../../services/waitingList/waiting-list.service';
import { ViewportScroller } from '@angular/common';
import { ConstantMessages } from '../../../../../constants/messages';

@Component({
  selector: 'app-create-witing-list-item-for-employee',
  templateUrl: './create-witing-list-item-for-employee.component.html',
  styleUrl: './create-witing-list-item-for-employee.component.css'
})
export class CreateWitingListItemForEmployeeComponent {

  // #region CTOR DI
  constructor(private toastrService: ToastrService,
    private router: Router,
    private waitingListService: WaitingListService,
    private scroller: ViewportScroller
  ) { }

  // #endregion

  @ViewChild('form') form: NgForm;

  isFailure: boolean = false;
  errorMessage: string;

  @Input("formModel") formModel = { serialNumber: '' };

  onSubmit(): void {
    this.errorMessage = '';
    this.isFailure = false;
    if (this.form.valid) {
      this.waitingListService.createBySerialNumber(this.formModel.serialNumber)
      .subscribe((result => {
        if (result.status === true) {
          this.toastrService.success(ConstantMessages.SUCCESS_ADD);
          this.router.navigateByUrl('receptionist/waitinglist');
        }
        else {
          this.scroller.scrollToPosition([0,0]);
          this.isFailure = true;
          this.errorMessage = result.errorMessage!;
          this.form.form.markAsPristine();
        }
      }))
    }
  }


}
