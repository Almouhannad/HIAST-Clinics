import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-visit',
  templateUrl: './visit.component.html',
  styleUrl: './visit.component.css'
})
export class VisitComponent {

  @Input("index") index: string;

  isSelected: boolean = false;
}
