import { Component, OnInit } from '@angular/core';
import {state} from "@angular/animations";
import {State} from "../../state";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-table-of-content',
  templateUrl: './table-of-content.component.html',
  styleUrls: ['./table-of-content.component.scss'],
})
export class TableOfContentComponent  implements OnInit {

  constructor(private http: HttpClient, public state: State) {

  }
  ngOnInit() {}

}
