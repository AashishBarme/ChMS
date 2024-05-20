import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  pageParentLink = 'Member';
  pageTitle = 'Edit Member';
  constructor() { }

  ngOnInit(): void {
  }

}
