import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  //#region Selected button
  private selectedButton: string = 'Main Menu';

  isSelected(buttonName: string): boolean {
    return this.selectedButton === buttonName;
  }

  selectButton(buttonName: string): void {
    this.selectedButton = buttonName;
  }
  //#endregion

}
