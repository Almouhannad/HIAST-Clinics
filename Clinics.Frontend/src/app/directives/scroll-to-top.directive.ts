import { Directive } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { ViewportScroller } from '@angular/common';

@Directive({
  selector: '[appScrollToTop]'
})
export class ScrollToTopDirective {
  constructor(private viewportScroller: ViewportScroller, private router: Router) { }

  ngAfterViewInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.viewportScroller.scrollToPosition([0, 0]);
      }
    });
  }
}