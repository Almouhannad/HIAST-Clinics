import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-ask-for-serial-number',
  templateUrl: './ask-for-serial-number.component.html',
  styleUrl: './ask-for-serial-number.component.css'
})
export class AskForSerialNumberComponent {

  constructor(){}

  @Input("parentModal") parentModal: any;
  @Input("type") type: 'query' | 'command';

  isFailure: boolean = false;
  errorMessage: string = 'الموظف غير موجود';

  serialNumber: string;

  onSubmit(): void {

  }

}
