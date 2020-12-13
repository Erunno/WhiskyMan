import { BottleForView } from './../../../x_models/bottle-for-view';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-bottle-view-card',
  templateUrl: './bottle-view-card.component.html',
  styleUrls: ['./bottle-view-card.component.css']
})
export class BottleViewCardComponent implements OnInit {

  @Input() public bottle: BottleForView;

  constructor() { }

  ngOnInit(): void {
  }

}
