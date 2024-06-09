import { Component, OnInit } from '@angular/core';
import { MemberService } from '../member.service';
import { ListMember } from '../member.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private service: MemberService) { }
  pageParentLink = 'Member';
  pageTitle = 'List Member';
  items: any[] = [];
  errorMessage: string = '';

  members: ListMember[] = [];

  ngOnInit(): void {
    this.service.list().subscribe(data => {
      this.members = data;
    });
  }

  deleteMember(id: number, index: number): void {
    let res = confirm("Do you really want to delete this member?");
    if(res){
      this.service.delete(id).subscribe(() => {
        this.members = this.members.filter(member => member.id !== id);
      });
      this.deleteLine(index);
    }
  }

  deleteLine(index : number)
  {
    if(index !== -1)
    {
      this.members.splice(index, 1);
    }
  }


}
