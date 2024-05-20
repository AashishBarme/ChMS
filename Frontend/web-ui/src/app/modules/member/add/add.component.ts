import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  pageParentLink = 'Member';
  pageTitle = 'Add Member';
  constructor() { }

  ngOnInit(): void {
  }

}
