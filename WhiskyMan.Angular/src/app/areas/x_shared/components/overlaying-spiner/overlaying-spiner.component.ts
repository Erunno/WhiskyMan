import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-overlaying-spiner',
  templateUrl: './overlaying-spiner.component.html',
  styleUrls: ['./overlaying-spiner.component.css']
})
export class OverlayingSpinerComponent implements OnInit {

  @Input() public topPercent = 50;

  constructor() { }

  ngOnInit(): void {
  }

  getStyle() {
    return {
      'top': `${this.topPercent}%`
    };
  }

}
