import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  constructor(private modalService: NgbModal, private toastrService: ToastrService) {
  }

  public open(modal: any): void {
    this.modalService.open(modal);
  }

  public showToast(): void {
    this.toastrService.success("world!", "Hello");
    this.toastrService.info("world!", "Hello");
    this.toastrService.warning("world!", "Hello");
    this.toastrService.error("world!", "Hello");
  }

}