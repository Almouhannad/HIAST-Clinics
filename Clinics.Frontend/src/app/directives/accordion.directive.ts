import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[appAccordion]'
})
export class AccordionDirective {

  @Input('index') index: string;

  constructor(private elementRef: ElementRef) { }

  ngAfterViewInit(): void {
    this.elementRef.nativeElement.setAttribute('data-bs-toggle', 'collapse');
    this.elementRef.nativeElement.setAttribute('data-bs-target', `#collapse${this.index}`);
    this.elementRef.nativeElement.setAttribute('aria-expanded', 'true');
    this.elementRef.nativeElement.setAttribute('aria-controls', `#collapse${this.index}`);
  }

}
