import { Component, OnInit } from '@angular/core';
import { WaitingListRecord } from '../../../classes/waitingList/waiting-list-record';
import { WaitingListService } from '../../../services/waitingList/waiting-list.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-waiting-list',
  templateUrl: './waiting-list.component.html',
  styleUrl: './waiting-list.component.css'
})
export class WaitingListComponent implements OnInit {

  constructor(private waitingListService: WaitingListService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.updateList();
  }

  updateList(): void {
    this.waitingListService.getAll()
    .subscribe(result => {
      if (result === null)
        this.toastrService.error("حدث خطأ، يرجى إعادة المحاولة");
      else this.records = result;
    });
  }

  records: WaitingListRecord[] = [];

  onRecordDeleted(): void {
    this.updateList();
  }
}
