import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-waiting-list-item',
  templateUrl: './waiting-list-item.component.html',
  styleUrl: './waiting-list-item.component.css'
})
export class WaitingListItemComponent {

  constructor(private modalService: NgbModal


  ) {}

  onClickDelete(modal: any): void {
    this.modalService.open(modal, {
      centered: true,
      size: 'md'
    });
  }

  onDelete(): void {

  }
}
