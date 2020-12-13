import { BottleForView } from './../../../x_models/bottle-for-view';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-bottles-list',
  templateUrl: './bottles-list.component.html',
  styleUrls: ['./bottles-list.component.css']
})
export class BottlesListComponent implements OnInit {

  @Input() public bottles: BottleForView[];

  constructor() { }

  ngOnInit(): void {
  }

}
