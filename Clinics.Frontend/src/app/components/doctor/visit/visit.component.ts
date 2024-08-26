import { Component, Input } from '@angular/core';
import { VisitView } from '../../../classes/visit/visit-view';

@Component({
  selector: 'app-visit',
  templateUrl: './visit.component.html',
  styleUrl: './visit.component.css'
})
export class VisitComponent {

  @Input("index") index: string;
  @Input("visit") visit: VisitView = new VisitView();

  isSelected: boolean = false;
}
